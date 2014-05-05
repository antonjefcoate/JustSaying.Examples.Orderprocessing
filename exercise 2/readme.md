#Exercise 2:

We are going to demonstrate that aync processes can easily be managed. In this case, we don't know how long it will be before the restaurant responds and we assume that restaurants can only view one order at a time.
This exercise should also demonstrate the difference between commands and events.


Prerequisites: Ensure you have setup 'multiple startup projects' for your solution of: ConsumerSite and OrderProcesor.


1. Publish an event which states that OrderProcessor has successfully validated an order: 'OrderValidatedOk'.
 * In the OrderPlacement Class, once the 'work' is complete...
 * `_publisher.Publish(new OrderValidatedOk(message.OrderId, string.Join(", ", message.OrderContents), message.Price, message.CustomerName));`


2. Listen to that event in the Restaurant (sho
 * Tell the Form1 class in Restaurant tht it will be handling OrderValidatedOk messages
 * `, IHandler<OrderValidatedOk>`
 * Implement the IHandler interface, and pass the arriving message through to the ShowOrder() method
 * `return ShowOrder(message);`
 * Tell JustSaying to pass OrderValidatedOk events through to Form1 so that we can see incoming messages.
 * `.WithSqsTopicSubscriber(Messages.Constants.OrderProcessingTopic)
                .IntoQueue("RestaurantOrders")
                .ConfigureSubscriptionWith(config => config.ErrorQueueOptOut = true)
                .WithMessageHandler(form)`
 * Tell JustSaying to start listening for mesages now. `.StartListening();`
 * Running the project now & placing an order should display order details in the Restaurant's form and show on the front end as 'sending order to restaurant'


3. Restaurant needs to publish events when they accept / reject orders
 * Tell JustSaying that we will be publishing OrderAccepted and OrderRejected events into the RestaurantOrders topic
 * `.ConfigurePublisherWith(config => { config.PublishFailureReAttempts = 3; config.PublishFailureBackoffMilliseconds = 50; })
                .WithSnsMessagePublisher<OrderAccepted>(Messages.Constants.RestaurantOrdersTopic)
                .WithSnsMessagePublisher<OrderRejected>(Messages.Constants.RestaurantOrdersTopic)`
 * Publish the appropriate accepted / rejected event from the form's buttons:
 * `_publisher.Publish(new OrderAccepted(_currentOrderId.Value));`
 * `_publisher.Publish(new OrderREjected(_currentOrderId.Value));`

4. ConsumerSite is already setup to listen to these events.
	
	

##Place an Order...

Running the app and placing an order now should result in an end --> end flow, where orders get

* Placed
* Validated
* Accepted / rejected,
* Consumer is informed of progress
