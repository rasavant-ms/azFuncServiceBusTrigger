namespace ServiceBusSender
{
    using System;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus;
    using Newtonsoft.Json;

    class Program
    {
        const string ServiceBusConnectionString = "<your service bus connection string>";
        const string TopicName = "<your service bus topic>";
        static ITopicClient topicClient;

        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            const int numberOfMessages = 50;
            topicClient = new TopicClient(ServiceBusConnectionString, TopicName);

            Console.WriteLine("======================================================");
            Console.WriteLine("Press ENTER key to exit after sending all the messages.");
            Console.WriteLine("======================================================");

            // Send messages.
            await SendMessagesAsync(numberOfMessages, new CarMessage("car0", "car0"));
            await SendMessagesAsync(numberOfMessages, new CarMessage("car1", "car1"));
            await SendMessagesAsync(numberOfMessages, new CarMessage("car2", "car2"));

            Console.ReadKey();

            await topicClient.CloseAsync();
        }

        static async Task SendMessagesAsync(int numberOfMessagesToSend, CarMessage carMessage)
        {
            try
            {
                for (var i = 0; i < numberOfMessagesToSend; i++)
                {
                    carMessage.CarDetails = new CarDetails();
                    carMessage.MessageNumber = i + 1;
                    // Create a new message to send to the topic
                    var message = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(carMessage)))
                    {
                        CorrelationId = carMessage.CorrelationId,
                        Label = carMessage.Label,
                        UserProperties =
                        {
                            { "messageNumber", i+1 },
                            { "color", carMessage.CarDetails.Color },
                            { "location", carMessage.CarDetails.Location },
                            { "randomField", carMessage.CarDetails.RandomField }
                        }
                    };

                    // Write the body of the message to the console
                    Console.WriteLine($"Sending message: {Encoding.ASCII.GetString(message.Body)}");

                    // Send the message to the topic
                    await topicClient.SendAsync(message);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }
        }
    }
}
