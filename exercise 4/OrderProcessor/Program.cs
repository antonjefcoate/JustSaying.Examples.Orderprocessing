using System;
using Messages;
using Messages.Commands;
using Messages.Events;

namespace JustSaying.Examples.OrderProcessing.OrderProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = JustSaying.CreateMeABus.InRegion("eu-west-1");

               bus.WithSqsTopicSubscriber(Constants.OrderProcessingTopic)
                .IntoQueue("OrderProcessorOrders")
                .ConfigureSubscriptionWith(config =>
                {
                    config.MessageRetentionSeconds = 120;
                    /*
                     *TODO UNCOMMENT THE FOLLOWING
                    config.RetryCountBeforeSendingToErrorQueue = 1;
                     */
                })
            
            // Add a handler for the place order command
            .WithMessageHandler(new OrderPlacement(bus))

            // Start listening for messages
            .StartListening();

            Console.Read();
        }
    }
}
