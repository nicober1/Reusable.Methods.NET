using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.AppService.Fluent.Models;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.ContainerRegistry.Fluent;
using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
using Microsoft.Azure.Management.ContainerService.Fluent;
using Microsoft.Azure.Management.ContainerService.Fluent.Models;
using Microsoft.Azure.Management.KeyVault.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Redis.Fluent;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Azure.Management.Storage.Fluent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.Management.Sql.Fluent;
using Microsoft.Azure.Management.TrafficManager.Fluent;
using Microsoft.Azure.Management.Dns.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using CoreFtp;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using Renci.SshNet;
using Microsoft.Azure.Management.Search.Fluent;
using Microsoft.Azure.Management.Search.Fluent.Models;
using Microsoft.Azure.Management.ServiceBus.Fluent;
using Microsoft.Azure.ServiceBus;
using System.Threading;
using System.Net.Http.Headers;
using Microsoft.Azure.Management.BatchAI.Fluent;
using Microsoft.Azure.Management.CosmosDB.Fluent;
using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ContainerInstance.Fluent;
using Microsoft.Azure.Management.Locks.Fluent;
using Microsoft.Azure.Management.Msi.Fluent;
using Microsoft.Azure.Management.Eventhub.Fluent;
using Microsoft.Azure.Management.Monitor.Fluent;
using Microsoft.Azure.Management.PrivateDns.Fluent;

namespace Reusable.Methods.NET
{
    public static partial class Reuse
    {
       
        public static void SendMessageToTopic(string connectionString, string topicName, string message)
        {
            if (!IsRunningMocked)
            {
                try
                {
                    var topicClient = new TopicClient(connectionString, topicName);
                    topicClient.SendAsync(new Message(Encoding.UTF8.GetBytes(message))).Wait();
                    topicClient.Close();
                }
                catch (Exception)
                {
                }
            }
        }

        public static void SendMessageToQueue(string connectionString, string queueName, string message)
        {
            if (!IsRunningMocked)
            {
                try
                {
                    var queueClient = new QueueClient(connectionString, queueName, ReceiveMode.PeekLock);
                    queueClient.SendAsync(new Message(Encoding.UTF8.GetBytes(message))).Wait();
                    queueClient.Close();
                }
                catch (Exception)
                {
                }
            }
        }


    }
}