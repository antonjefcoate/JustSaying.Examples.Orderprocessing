using System;
using System.Windows.Forms;
using Messages.Events;

namespace Restaurant
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var bus = JustSaying.CreateMeABus.InRegion(Amazon.RegionEndpoint.EUWest1.SystemName);

            var form = new Form1(bus);

                bus.WithSqsTopicSubscriber(Messages.Constants.OrderProcessingTopic)
                .IntoQueue("RestaurantOrders")
                .WithMessageHandler(form)
                
                .ConfigurePublisherWith(config => { config.PublishFailureReAttempts = 3; config.PublishFailureBackoffMilliseconds = 50; })
                .WithSnsMessagePublisher<OrderAccepted>(Messages.Constants.RestaurantOrdersTopic)
                .WithSnsMessagePublisher<OrderRejected>(Messages.Constants.RestaurantOrdersTopic)
                
                .StartListening();



            Application.Run(form);
        }
    }
}
