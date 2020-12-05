using System;
using System.Threading.Tasks;
using Microsoft.Azure.Storage; // Namespace for CloudStorageAccount
using Microsoft.Azure.Storage.Queue; // Namespace for Queue storage types

namespace queuefiller
{
    class Program
    {
        const string StorageConnectionString = "<storage-connection-string>";
        
        static async Task Main(string[] args)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(StorageConnectionString);

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            CloudQueue queue = queueClient.GetQueueReference("myqueue-items");

            int numberOfMessages = 40;
            string[] messages = new string[numberOfMessages];

            for(int i = 1; i< numberOfMessages; i++)
            {
                messages[i] = "" + i;
            }

            Task[] tasks = new Task[numberOfMessages];
            int counter = 0;

            Console.WriteLine("Filling...");

            foreach (string record in messages) {
                tasks[counter] = queue.AddMessageAsync( new CloudQueueMessage(record));
                counter++;
            }
            await Task.WhenAll(tasks);

            Console.WriteLine("Done!");
        }
    }
}
