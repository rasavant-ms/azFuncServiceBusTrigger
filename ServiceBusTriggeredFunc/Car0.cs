using System;
using System.Text;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ServiceBusTriggeredFunc
{
    public static class Car0
    {
        [FunctionName("Car0")]
        public static void Run([ServiceBusTrigger("mytopic", "car0", Connection = "ServiceBusConnectionString")]Message[] mySbMsg, ILogger log)
        {
            foreach (var msg in mySbMsg)
            {
                var body = Encoding.UTF8.GetString(msg.Body);
                var enqueuedTimeUtc = msg.SystemProperties.EnqueuedTimeUtc;
                log.LogInformation($"C# ServiceBus topic trigger function processed message: {body}");
                log.LogInformation($"Message enqueued at: {enqueuedTimeUtc}");
            }

            //log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
            //log.LogInformation($"Message enqueued at: {enqueuedTimeUtc}");

        }
    }
}
