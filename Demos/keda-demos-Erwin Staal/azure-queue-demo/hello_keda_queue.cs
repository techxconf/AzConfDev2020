using System;
using System.Threading;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace hello_keda2
{
    public static class hello_keda_queue
    {
        [FunctionName("hello_keda_queue")]
        public static void Run([QueueTrigger("myqueue-items", Connection = "AzureWebJobsStorage")]string myQueueItem, ILogger log)
        {
            Thread.Sleep(5000);

            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
