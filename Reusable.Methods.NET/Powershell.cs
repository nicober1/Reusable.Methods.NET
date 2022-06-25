namespace Reusable.Methods.NET
{
    public static partial class Reuse
    {

      
        /// <summary>
        /// Runs a PowerShell script taking it's path and parameters.
        /// </summary>
        /// <param name="scriptFullPath">The full file path for the .ps1 file.</param>
        /// <param name="parameters">The parameters for the script, can be null.</param>
        /// <returns>The output from the PowerShell execution.</returns>
        public static IEnumerable<PSObject> RunPowerShellScript(string scriptFullPath, ICollection<CommandParameter>? parameters = null)
        {
            var runSpace = RunspaceFactory.CreateRunspace();
            runSpace.Open();
            var pipeline = runSpace.CreatePipeline();
            var cmd = new Command(scriptFullPath);
            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    cmd.Parameters.Add(p);
                }
            }
            pipeline.Commands.Add(cmd);
            var results = pipeline.Invoke();
            pipeline.Dispose();
            runSpace.Dispose();
            return results;
        }

        public static IEnumerable<PSObject> RunPowerShellCommandFromInputFile(string scriptFullPath, ICollection<CommandParameter>? parameters = null)
        {
            var content = File.ReadAllText(scriptFullPath);
            var runSpace = RunspaceFactory.CreateRunspace();
            runSpace.Open();
            var pipeline = runSpace.CreatePipeline();
            
            pipeline.Commands.AddScript(content);
            var results = pipeline.Invoke();
            pipeline.Dispose();
            runSpace.Dispose();
            return results;
        }

        public static IEnumerable<PSObject> RunPowerShellCommand(string command, ICollection<CommandParameter>? parameters = null)
        {
            var runSpace = RunspaceFactory.CreateRunspace();
            runSpace.Open();
            var pipeline = runSpace.CreatePipeline();
            var cmd = new Command(command,false);
            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    cmd.Parameters.Add(p);
                }
            }
            pipeline.Commands.AddScript(cmd.ToString());
            var results = pipeline.Invoke();
            pipeline.Dispose();
            runSpace.Dispose();
            return results;
        }


       
    }

    
}