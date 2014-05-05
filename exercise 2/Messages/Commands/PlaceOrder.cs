using System;
using System.Collections.Generic;
using JustSaying.Messaging.Messages;

namespace Messages.Commands
{
    public class PlaceOrder: Message
    {
        public PlaceOrder(List<string> orderContents, double price, string customerName)
        {
            OrderId = Guid.NewGuid();
            CustomerName = customerName;
            Price = price;
            OrderContents = orderContents;
        }

        public Guid OrderId { get; private set; }
        public List<string> OrderContents { get; private set; }
        public double Price { get; private set; }
        public string CustomerName { get; private set; }
    }
}
