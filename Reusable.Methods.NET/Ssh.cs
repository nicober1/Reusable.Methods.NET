namespace Reusable.Methods.NET
{
    public static partial class Reuse
    {
       
       public static string? TrySsh(
            string host,
            int port,
            string userName,
            string password,
            string commandToExecute)
        {
            string? commandOutput = null;
            const int backOffTime = 30 * 1000;
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
                            using var command = sshClient.CreateCommand(commandToExecute);
                            commandOutput = command.Execute();
                        }
                        break;
                    }
                    catch (Exception)
                    {
                        retryCount--;
                        if (retryCount == 0)
                        {
                            throw;
                        }
                    }
                    finally
                    {
                        try
                        {
                            sshClient.Disconnect();
                        }
                        catch
                        {
                            // ignored
                        }
                    }
                }
                SdkContext.DelayProvider.Delay(backOffTime);
            }

            return commandOutput;
        }

    }
}