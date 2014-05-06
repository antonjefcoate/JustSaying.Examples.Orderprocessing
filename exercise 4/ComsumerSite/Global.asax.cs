using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using JustSaying.Messaging;
using Messages;
using Messages.Commands;
using Messages.Events;

namespace ComsumerSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var dispatcher = new OrderResolutionDispatcher();
            JustSaying.CreateMeABus.InRegion("eu-west-1")
                .WithSqsTopicSubscriber(Constants.RestaurantOrdersTopic)
                .IntoQueue("OrderResolution")
                .WithMessageHandler<OrderAccepted>(dispatcher)
                .WithMessageHandler<OrderRejected>(dispatcher)
                .StartListening();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
