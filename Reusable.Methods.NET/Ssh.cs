using Microsoft.Azure.Management.ResourceManager.Fluent;
using Renci.SshNet;

namespace Reusable.Methods.NET
{
    public static partial class Reuse
    {
       
       private static string TrySsh(
            string host,
            int port,
            string userName,
            string password,
            string commandToExecute)
        {
            string commandOutput = null;
            var backoffTime = 30 * 1000;
            var retryCount = 3;

            while (retryCount > 0)
            {
                using (var sshClient = new SshClient(host, port, userName, password))
                {
                    try
                    {
                        sshClient.Connect();
                        if (commandToExecute != null)
                        {
                            using (var command = sshClient.CreateCommand(commandToExecute))
                            {
                                commandOutput = command.Execute();
                            }
                        }
                        break;
                    }
                    catch (Exception exception)
                    {
                        retryCount--;
                        if (retryCount == 0)
                        {
                            throw exception;
                        }
                    }
                    finally
                    {
                        try
                        {
                            sshClient.Disconnect();
                        }
                        catch { }
                    }
                }
                SdkContext.DelayProvider.Delay(backoffTime);
            }

            return commandOutput;
        }

    }
}