using System;
using System.Text;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ServiceBusTriggeredFunc
{
    public static class Car2
    {
        [FunctionName("Car2")]
        public static void Run([ServiceBusTrigger("mytopic", "car2", Connection = "ServiceBusConnectionString")]Message mySbMsg, 
            ILogger log)
        {
                var body = Encoding.UTF8.GetString(mySbMsg.Body);
                var enqueuedTimeUtc = mySbMsg.SystemProperties.EnqueuedTimeUtc;
                log.LogInformation($"C# ServiceBus topic trigger function processed message: {body}");
                log.LogInformation($"Message enqueued at: {enqueuedTimeUtc}");
        }
    }
}
