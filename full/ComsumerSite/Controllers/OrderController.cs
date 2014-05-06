using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComsumerSite.Models;
using JustSaying.Messaging;
using Messages;
using Messages.Commands;

namespace ComsumerSite.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMessagePublisher _publisher;

        public OrderController()
        {
            _publisher = JustSaying.CreateMeABus.InRegion("eu-west-1")
                .ConfigurePublisherWith(conf => conf.PublishFailureReAttempts = 1)
                .WithSnsMessagePublisher<PlaceOrder>(Constants.OrderProcessingTopic);
        }

        //
        // GET: /Order/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(OrderDetails orderDetails)
        {
            var placeOrderCommand = new PlaceOrder(new List<string>{orderDetails.Item1, orderDetails.Item2}, orderDetails.Price, orderDetails.CustomerName);
            _publisher.Publish(placeOrderCommand);
            return View("Placed", placeOrderCommand);
        }

	}
}