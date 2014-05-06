using ComsumerSite.Hubs;
using JustSaying.Messaging.MessageHandling;
using Messages.Events;
using Microsoft.AspNet.SignalR;

namespace ComsumerSite
{
    public class OrderResolutionDispatcher : IHandler<OrderAccepted>, IHandler<OrderRejected>
    {
        public bool Handle(OrderAccepted message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<OrderResolutionHub>();
            context.Clients.All.UpdateOrderResolution("Order Acceppted.");
            return true;
        }

        public bool Handle(OrderRejected message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<OrderResolutionHub>();
            context.Clients.All.UpdateOrderResolution("Order Rejected.");
            return true;
        }
    }
}