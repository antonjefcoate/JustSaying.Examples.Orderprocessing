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
                .WithSqsTopicSubscriber(config =>
                {
                    config.Topic = Constants.OrderProcessingTopic;
                    config.MessageRetentionSeconds = 120;
                });
            
            bus.WithMessageHandler(new OrderPlacement(bus));
        }
    }
}
