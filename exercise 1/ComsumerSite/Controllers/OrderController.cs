using System.Collections.Generic;
using System.Web.Mvc;
using ComsumerSite.Models;
using Messages.Commands;

namespace ComsumerSite.Controllers
{
    public class OrderController : Controller
    {
        //private readonly IMessagePublisher _publisher;

        public OrderController()
        {
            // Setup your bus here for publishing.
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(OrderDetails orderDetails)
        {
            var placeOrderCommand = new PlaceOrder(new List<string>{orderDetails.Item1, orderDetails.Item2}, orderDetails.Price, orderDetails.CustomerName);
            
            // Publish the PlaceOrder command here.

            return View("Placed", placeOrderCommand);
        }

	}
}