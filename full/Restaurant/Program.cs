using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using JustSaying.Messaging.MessageHandling;
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
            var form = new Form1();
            Application.Run(form);

            JustSaying.CreateMeABus.InRegion(Amazon.RegionEndpoint.EUWest1.SystemName)
                .WithSqsTopicSubscriber(Messages.Constants.OrderProcessingTopic)
                .IntoQueue("RestaurantOrders")
                .WithMessageHandler(form);

        }
    }
}
