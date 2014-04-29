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
            _publisher = JustSaying.CreateMe.ABus(config =>
            {
                config.Region = "eu-west-1";
            })
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
            _publisher.Publish(new PlaceOrder(new List<string>{orderDetails.Item1, orderDetails.Item2}, orderDetails.Price, orderDetails.CustomerName));
            return View("Placed");
        }

	}
}