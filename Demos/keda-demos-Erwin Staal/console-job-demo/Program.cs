using System;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;

namespace consolejob
{
    class Program
    {
        static void Main(string[] args)
        {
            var storageConnectionString = "<storage-connection-string>";
            var queueName  = "job-items";

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            CloudQueue queue = queueClient.GetQueueReference(queueName);

            CloudQueueMessage retrievedMessage = queue.GetMessage();

            Console.WriteLine($"The message in the queue: {retrievedMessage.AsString}");

            queue.DeleteMessage(retrievedMessage);
        }
    }
}