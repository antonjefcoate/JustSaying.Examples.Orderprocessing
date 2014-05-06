using System;

namespace Messages
{
    public static class Constants
    {
        private static readonly string TeamName = Environment.MachineName;
        public static string OrderProcessingTopic = TeamName + "OrderProcessing";
        public static string RestaurantOrdersTopic = TeamName + "RestaurantProcessing";
    }
}
