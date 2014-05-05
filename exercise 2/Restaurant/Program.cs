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

            
            // Configure JustSaying here for subscriptions and publications.


            Application.Run(form);
        }
    }
}
