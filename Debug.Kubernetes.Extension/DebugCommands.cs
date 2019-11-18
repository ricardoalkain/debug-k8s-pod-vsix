using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace Debug.Kubernetes.Extension
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class DebugCommands: IWin32Window
    {
        private string DEBUG_SCRIPT = "Resources\\DebugK8s.ps1";
        private string XML_TEMPLATE = "Resources\\DebugK8s.xml";

        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("23416ee3-2ce6-4d89-ad89-8d46b208c8af");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;
        private readonly DTE dte;

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugCommands"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private DebugCommands(AsyncPackage package, OleMenuCommandService commandService, DTE _dte)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(this.Execute, menuCommandID);
            commandService.AddCommand(menuItem);
            dte = _dte;
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static DebugCommands Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Allows to correctly shows the modal dialog in front of Visual Studio IDE
        /// </summary>
        public IntPtr Handle => new IntPtr(dte.MainWindow.HWnd);

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package, DTE _dte)
        {
            // Verify the current thread is the UI thread - the call to AddCommand in DebugCommands's constructor requires
            // the UI thread.
            ThreadHelper.ThrowIfNotOnUIThread();

            OleMenuCommandService commandService = await package.GetServiceAsync((typeof(IMenuCommandService))) as OleMenuCommandService;
            Instance = new DebugCommands(package, commandService, _dte);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            if (!dte.Solution.IsOpen)
            {
                throw new InvalidOperationException("No project open to debug!");
            }

            var suggestedApps = new List<string>();
            var helmDir = Path.Combine(Path.GetDirectoryName(dte.Solution.FileName), "helm");

            if (Directory.Exists(helmDir))
            {
                // If there's a Helm project into solution, look for all chart names.
                // By convention, chart names are the same as application names inside Kubernetes.
                var helmCharts = Directory.GetFiles(helmDir, "Chart.yaml", SearchOption.AllDirectories);
                foreach (var chartFile in helmCharts)
                {
                    var content = File.ReadAllText(chartFile);
                    var match = Regex.Match(content, @"^name\s*:\s*(.*)", RegexOptions.Multiline);
                    if (match.Success)
                    {
                        suggestedApps.Add(match.Groups[1].Value.Trim());
                    }
                }
            }
            else
            {
                // When solution has no Helm folder, it assumes the deploy was made manually or by a different tool.
                // In this case, suggest the App Name based upon startup project.
                var solutionName = Path.GetFileNameWithoutExtension(dte.Solution.FileName);
                var matches = Regex.Match(solutionName, @"([\w]*?)\.([\w]*?)$");

                if (matches.Success)
                {
                    suggestedApps.Add((matches.Groups[1].Value.Trim() + "-" + matches.Groups[2].Value.Trim()).ToLower());
                }
                else
                {
                    suggestedApps.Add(solutionName.ToLower());
                }
            }

            // Generates PowerShell script to be executed by MIEngine
            string args;
            string rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string tempPath = Path.GetTempPath();
            string scriptPath = Path.Combine(rootPath, DEBUG_SCRIPT);

            // Shows config dialog
            using (var config = new ConfigDialog())
            {
                if (File.Exists(scriptPath))
                {
                    config.DefaultScriptFileName = scriptPath;
                }

                config.SetAppNames(suggestedApps);
                if (config.ShowDialog() != DialogResult.OK)
                {
                    return;
                }


                if (config.UseCustomScript)
                {
                    var content = config.CustomScriptContent;
                    scriptPath = Path.Combine(tempPath, "custom_debug_k8s.ps1");
                    File.WriteAllText(scriptPath, content);
                    args = "";
                }
                else
                {
                    args = $"-app {config.AppName} -pod {config.SelectedPodName}";
                }

                if (!File.Exists(scriptPath))
                {
                    throw new Exception($"File '{scriptPath}' can't be found. Please try reinstalling the extension to restore the missing file.");
                }

                // Load debugger options XML file and replace the place holders
                var xmlPath = Path.Combine(rootPath, XML_TEMPLATE);
                var xml = File.ReadAllText(xmlPath)
                            .Replace("{PATH}", scriptPath)
                            .Replace("{ARGS}", args);
                File.WriteAllText(xmlPath, xml);

                // Start the MIEngine debugger from command window
                var cw = (dte.Windows.Item(EnvDTE.Constants.vsWindowKindCommandWindow).Object as CommandWindow);
                cw.SendInput($"Debug.MIDebugLaunch /Executable:dotnet /OptionsFile:{xmlPath}", true);
            }
        }
    }
}
