using Microsoft.AspNet.SignalR;

namespace ComsumerSite.Hubs
{
    public class OrderResolutionHub : Hub
    {
        public void SendOrderResolution(string orderResolution)
        {
            Clients.All.UpdateOrderResolution(orderResolution);
        }
    }
}