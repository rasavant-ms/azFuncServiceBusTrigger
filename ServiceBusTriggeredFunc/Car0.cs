using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ServiceBusTriggeredFunc
{
    public static class Car0
    {
        [FunctionName("Car0")]
        public static void Run([ServiceBusTrigger("mytopic", "car0", Connection = "ServiceBusConnectionString")]string[] mySbMsg, ILogger log)
        {
            foreach (var msg in mySbMsg)
            {
                log.LogInformation($"C# ServiceBus topic trigger function processed message: {msg}");
                //log.LogInformation($"Message enqueued at: {enqueuedTimeUtc}");
            }

            //log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
            //log.LogInformation($"Message enqueued at: {enqueuedTimeUtc}");

        }
    }
}
