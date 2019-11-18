namespace Debug.Kubernetes.Extension.Kubernetes
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;

    /// <summary>
    /// Encapsulates KubeCtl.exe application calls.
    /// This class is not intended to encapsulate all functionalities besides
    /// the ones used by the extension (but it is a good idea for a GitHub project...)
    /// </summary>
    public class KubeCtl
    {
        const int DEFAULT_TIMEOUT = 500000;

        /// <summary>
        /// Default timeout when executing EXEC command in a container, in miliseconds.
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// Namespace used to execute the commands
        /// </summary>
        public string DefaultNamespace { get; set; }

        /// <summary>
        /// Create a new instance of KubeCtl
        /// </summary>
        public KubeCtl()
        {
            Timeout = DEFAULT_TIMEOUT;
        }

        /// <summary>
        /// Get all contexts configured for kubectl.exe application.
        /// </summary>
        /// <returns>String list containing all context names.</returns>
        public IEnumerable<string> ListContexts()
        {
            return StringToList(ExecuteCmdKubeCtl("config get-contexts -o name"));
        }

         /// <summary>
        /// Get the current context configured for kubectl.exe application.
        /// </summary>
        /// <returns>String containing the current context name.</returns>
        public string GetContext()
        {
            return ExecuteCmdKubeCtl("config current-context");
        }

       /// <summary>
        /// Switch the current context and namespace for kubectl.exe application.
        /// This command changes the context and namespace globally in the current system, not only in this instance.
        /// </summary>
        /// <param name="contextName">Context name to switch to.</param>
        /// <param name="defaultNamespace">Default namespace to use.</param>
        public void SetContext(string contextName, string defaultNamespace)
        {
            if (string.IsNullOrWhiteSpace(contextName))
            {
                throw new ArgumentException("The name of the context can't be empty or null.", "contextName");
            }

            if (!string.IsNullOrWhiteSpace(defaultNamespace))
            {
                defaultNamespace = "--namespace=" + defaultNamespace;
            }

            ExecuteCmdKubeCtl($"config set-context {contextName} {defaultNamespace}");
        }

        /// <summary>
        /// Switch the current context for kubectl.exe application.
        /// This command changes the context globally in the current system, not only in this instance.
        /// </summary>
        /// <param name="contextName">Context name to switch to.</param>
        public void SetContext(string contextName)
        {
            SetContext(contextName, null);
        }

        /// <summary>
        /// Get all namespaces configured for the current context.
        /// </summary>
        /// <returns>String list containing all namespaces in the current context.</returns>
        public IEnumerable<string> ListNamespaces()
        {
            return StringToList(ExecuteCmdKubeCtl("get namespaces -o=jsonpath=\"{range.items[*]}{.metadata.name}{'\\n'}\""));
        }


        /// <summary>
        /// Get the cluster name configured for the giving context.
        /// </summary>
        /// <param name="contextName">Name of the context of the cluster.</param>
        /// <returns>String containing the cluster name.</returns>
        public string GetCluster(string contextName)
        {
            return ExecuteCmdKubeCtl("config view -o jsonpath=\"{.contexts[?(@.name == '" + contextName + "')].context.cluster}\"");
        }

        /// <summary>
        /// Get the current cluster where the commands will run.
        /// </summary>
        /// <returns>String containing the cluster name.</returns>
        public string GetClusterName()
        {
            return GetCluster(GetContext());
        }

        /// <summary>
        /// Get the server address configured for the giving cluster.
        /// </summary>
        /// <param name="clusterName">Name of the cluster hosted by the server.</param>
        /// <returns>String containing the cluster name.</returns>
        public string GetServer(string clusterName)
        {
            return ExecuteCmdKubeCtl("config view -o jsonpath=\"{.clusters[?(@.name == '" + clusterName + "')].cluster.server}\"");
        }

        /// <summary>
        /// Get the server address hosting the cluster where the commands will run.
        /// </summary>
        /// <returns>String containing the server address/IP and port.</returns>
        public string GetServer()
        {
            return GetServer(GetClusterName());
        }

        /// <summary>
        /// Gets all pod names in the current context.
        /// </summary>
        /// <returns>String list with the name of all pods in the current context.</returns>
        public IEnumerable<string> ListPodNames()
        {
            return StringToList(ExecuteCmdKubeCtl($"get pods -o \"jsonpath={{.items[0].metadata.name}}\""));
        }

        /// <summary>
        /// Gets pod names in the current context running the specified application.
        /// </summary>
        /// <param name="appName">Application name</param>
        /// <returns>String list with the name of all pods in the current context.</returns>
        public IEnumerable<string> ListPods(string appName)
        {
            return StringToList(ExecuteCmdKubeCtl($"get pods --selector=\"app={appName}\" -o \"jsonpath={{.items[*].metadata.name}}\""));
        }

        /// <summary>
        /// Gets pod information in the current context running the specified application.
        /// </summary>
        /// <param name="selector">String containing field selector expression used to filter pods. Example: "app=MyAppName"</param>
        /// <param name="jsonPath">String containing the json path to the field to be returned.</param>
        /// <returns>String list with the specified field value of all pods in the current context.</returns>
        public IEnumerable<string> ListPods(string selector, string jsonPath)
        {
            return StringToList(ExecuteCmdKubeCtl($"get pods --selector=\"{selector}\" -o \"jsonpath={{.{jsonPath}}}\""));
        }

        /// <summary>
        /// Gets all pod names in the current context.
        /// </summary>
        /// <returns>String list with the name of all pods in the current context.</returns>
        public IEnumerable<string> GetServiceNames()
        {
            return StringToList(ExecuteCmdKubeCtl($"get svc -o \"jsonpath={{.items[*].metadata.name}}\""));
        }

        /// <summary>
        /// Gets pod names in the current context running the specified application.
        /// </summary>
        /// <param name="appName">Application name</param>
        /// <returns>String list with the name of all pods in the current context.</returns>
        public IEnumerable<string> GetServiceNames(string appName)
        {
            return StringToList(ExecuteCmdKubeCtl($"get svc --selector=\"app={appName}\" -o jsonpath={{.items[*].metadata.name}}"));
        }

        /// <summary>
        /// Gets pod names in the current context running the specified application.
        /// </summary>
        /// <param name="selector">String containing field selector expression used to filter pod name. Example: "app=MyAppName"</param>
        /// <param name="jsonPath">String containing the json path to the field to be returned.</param>
        /// <returns>String list with the name of all pods in the current context.</returns>
        public IEnumerable<string> GetServiceInfo(string selector, string jsonPath)
        {
            return StringToList(ExecuteCmdKubeCtl($"get pods --selector=\"{selector}\" -o \"jsonpath={{.{jsonPath}}}\""));
        }

        /// <summary>
        /// Execute a shell command inside a container.
        /// </summary>
        /// <param name="podName">Name of the pod where the container is.</param>
        /// <param name="containerName">Name of the container the command will be executed.
        /// If omitted, the command will be executed in the first container found.</param>
        /// <param name="cmdLine">Shell command to be executed inside the container.</param>
        /// <param name="timeout">Time, in miliseconds, to wait before stopping wait for the end of the execution (Int.MaxValue = infinite).</param>
        /// <returns>String containing the command output.</returns>
        public string Exec(string podName, string containerName, string cmdLine, int timeout)
        {
            if (!string.IsNullOrEmpty(containerName))
            {
                containerName = "-c " + containerName;
            }

            return ExecuteCmdKubeCtl($"exec {podName} {containerName} -i -t -- {cmdLine}");
        }

        #region Private Members

        private string ExecuteCmdKubeCtl(string command)
        {
            return ExecuteCmdKubeCtl(DefaultNamespace, command, Timeout);
        }

        private string ExecuteCmdKubeCtl(string nameSpace, string command)
        {
            return ExecuteCmdKubeCtl(nameSpace, command, Timeout);
        }

        // TODO: Make an Async version
        private string ExecuteCmdKubeCtl(string nameSpace, string command, int timeout)
        {
            if (!string.IsNullOrEmpty(nameSpace))
            {
                nameSpace = "--namespace=" + nameSpace;
            }

            command = $"{nameSpace} {command}";

            using (var cmd = new Process())
            {
                cmd.StartInfo.FileName = "kubectl.exe";
                cmd.StartInfo.Arguments = command;

                // Redirect the output stream of the child process.
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.RedirectStandardError = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.Start();
                cmd.WaitForExit(timeout);

                var result = cmd.StandardOutput.ReadToEnd().Trim();
                var errors = cmd.StandardError.ReadToEnd();

                if (cmd.ExitCode != 0)
                {
                    throw new Exception(errors);
                }

                return result;
            }
        }

        private string[] StringToList(string text)
        {
            return text.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        }

        #endregion
    }
}
