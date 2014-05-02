using System;
using System.Collections.Generic;
using JustSaying.Messaging.Messages;

namespace Messages.Events
{
    public class OrderValidatedOk : Message
    {
        public OrderValidatedOk(Guid orderId, string orderContents, double price, string customerName)
        {
            CustomerName = customerName;
            Price = price;
            OrderContents = orderContents;
            OrderId = orderId;
        }

        public Guid OrderId { get; private set; }
        public string OrderContents { get; private set; }
        public double Price { get; private set; }
        public string CustomerName { get; private set; }
    }

    public class OrderAccepted : Message
    {
        public OrderAccepted(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; private set; }
    }

    public class OrderRejected : Message
    {
        public OrderRejected(Guid orderId, string rejectReason)
        {
            RejectReason = rejectReason;
            OrderId = orderId;
        }

        public Guid OrderId { get; private set; }
        public string RejectReason { get; private set; }
    }
}
