#Exercise 1:

**Covers:**
Basic usage of JustSaying. Wiring up a publisher and a consumer.

We are going to instruct the OrderProcessor component to place an order made by the ConsumerSite.
ConsumerSite will publish a command and OrderProcessor will pick it up and do some work on it.


**Open /Exercise 1/JustSaying.Examples.OrderProcessing.sln**

Prerequisite: Ensure you have setup 'multiple startup projects' for your solution of: ConsumerSite and OrderProcesor.


1. Install the JustSaying package into **each** of the projects
 * install-package JustSaying
 * Note: Ensure you have the Just Eat package source configured (http://packages.je-labs.com/nuget/Default)

2. Create a command
 * We've created the command (message) for you
 * Ensure the command can be published by inheriting the JustSaying message type on the PlaceOrder command

3. Publish the command from your ConsumerSite / Order controller HttpPost action
 * Create a bus & configure for publishing
 * Populate the 'PlaceOrder' command
 * Publish

4. Consume the command in OrderProcessor and get the OrderPlacement class to do it's bit
 * Tell OrderPlacement that it can handle OrderPlaced commands
		`: IHandler<PlaceOrder>`
 * Handle the message as required by the interface (Return true - Assuming all orders get placed ok for now) by wiring up the private processing method 'PlaceAnOrder'
 * Setup a subscription in the OrderProcessor Program.cs to listen in to PlaceOrder commands and send them to the OrderProcessor
		
	
	

##Place an Order...

You should now have your order processing details displaying in the OrderProcessor console.

##Hints:
Publisher bus config:

    _publisher = JustSaying.CreateMeABus.InRegion("eu-west-1")
         .ConfigurePublisherWith(conf => conf.PublishFailureReAttempts = 1)
         .WithSnsMessagePublisher<PlaceOrder>(Constants.OrderProcessingTopic);

     _publisher.Publish(placeOrderCommand);

Subscriber Bus Config:

    JustSaying.CreateMeABus.InRegion("eu-west-1")
                .WithSqsTopicSubscriber(Constants.OrderProcessingTopic)
                .IntoQueue("OrderProcessorOrders")
                .WithMessageHandler(new OrderPlacement())
            .StartListening();
