using System;
using Messages;
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
                })
            
            // Add a handler for the place order command
            .WithMessageHandler<OrderAccepted>(new OrderPlacement(bus))
            .ConfigurePublisherWith(conf => conf.PublishFailureReAttempts = 2)

            // State our intent to publish Order Accepted events
            .WithSnsMessagePublisher<OrderAccepted>(Constants.OrderProcessingTopic)

            // Start listening for messages
            .StartListening();

            Console.Read();
        }
    }
}
