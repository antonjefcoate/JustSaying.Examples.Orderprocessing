using System;
using JustSaying.Messaging;
using Messages.Commands;

namespace JustSaying.Examples.OrderProcessing.OrderProcessor
{
    internal class OrderPlacementWithIntermittentDbError : OrderPlacement
    {
        private int _i;

        internal OrderPlacementWithIntermittentDbError(IMessagePublisher publisher) : base(publisher)
        {
        }

        public override bool Handle(PlaceOrder message)
        {
            _i ++;

            if (_i%2 == 0) // Process 50% of order requests successfully
            {
                Console.WriteLine("OOPS, DB error processing order for {0}", message.CustomerName);
                throw new Exception("DB BLEW UP!");
            }

            return base.Handle(message);
        }
    }
}