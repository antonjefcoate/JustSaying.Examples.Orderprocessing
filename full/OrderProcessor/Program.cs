using System;
using Messages;

namespace JustSaying.Examples.OrderProcessing.OrderProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = CreateMe.ABus(config =>
            {
                config.Region = "eu-west-1";
            })  
                // Subscribe to order processing topic
                .WithSqsTopicSubscriber(config =>
                {
                    config.Topic = Constants.OrderProcessingTopic;
                    config.MessageRetentionSeconds = 120;
                });
            
            // Add a handler for the place order command
            bus.WithMessageHandler(new OrderPlacement(bus));

            // Start listening for messages
            bus.StartListening();

            Console.Read();
        }
    }
}
