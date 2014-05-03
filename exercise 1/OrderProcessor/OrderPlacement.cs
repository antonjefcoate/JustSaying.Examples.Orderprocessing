using System;
using System.Threading;
using Messages.Commands;

namespace JustSaying.Examples.OrderProcessing.OrderProcessor
{
    internal class OrderPlacement
    {
        internal OrderPlacement()
        {

        }

        // Order processing method. Needs to be called with a PlaceOrder message from the JustSaying bus.
        private bool PlaceAnOrder(PlaceOrder message)
        {
            Console.WriteLine("I've been asked to place an order for '{0}' costing '{1}'", message.CustomerName, message.Price);

            Console.WriteLine("Saving to DB order for '{0}'", message.CustomerName);
            Thread.Sleep(50); // pretend to do some work

            Console.WriteLine("Validating order for '{0}' against some rules", message.CustomerName);
            Thread.Sleep(100); // pretend to do some work

            // Order Validated.
            Console.WriteLine("VALIDATED OK: order for '{0}'", message.CustomerName);

            return true;
        }
    }
}