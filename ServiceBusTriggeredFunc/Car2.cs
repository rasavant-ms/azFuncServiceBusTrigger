using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ServiceBusTriggeredFunc
{
    public static class Car2
    {
        [FunctionName("Car2")]
        public static void Run([ServiceBusTrigger("mytopic", "car2", Connection = "ServiceBusConnectionString")]string mySbMsg, 
            DateTime enqueuedTimeUtc,
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg} \nEnqueued at time: {enqueuedTimeUtc.Hour}:{enqueuedTimeUtc.Minute}:{enqueuedTimeUtc.Second}:{enqueuedTimeUtc.Millisecond}" +
                $"\nCurrent time: {DateTime.UtcNow.Hour}:{DateTime.UtcNow.Minute}:{DateTime.UtcNow.Second}:{DateTime.UtcNow.Millisecond}");
        }
    }
}
