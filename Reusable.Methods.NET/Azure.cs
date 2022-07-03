namespace Reusable.Methods.NET
{
    public static partial class Reuse
    {
       
        public static void SendMessageToTopic(string connectionString, string topicName, string message)
        {
            
                try
                {
                    var topicClient = new TopicClient(connectionString, topicName);
                    topicClient.SendAsync(new Message(Encoding.UTF8.GetBytes(message))).Wait();
                    topicClient.CloseAsync().Wait();
                }
                catch
                {
                    //
                }
            
        }

        public static void SendMessageToQueue(string connectionString, string queueName, string message)
        {
           
                try
                {
                    var queueClient = new QueueClient(connectionString, queueName, ReceiveMode.PeekLock);
                    queueClient.SendAsync(new Message(Encoding.UTF8.GetBytes(message))).Wait();
                    queueClient.CloseAsync().Wait();
                }
                catch
                {
                    //
                }
            
        }


    }
}