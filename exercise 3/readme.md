#Exercise 3:
In this exercise we're going to demonstrate how JustSaying enables you to cope with intermittent issues in your application. We're going to simulate an intermittent DB outage in OrderProcessor project that throws an Exception for 50% of incoming orders. 

##Prerequisites: 
* Ensure you have set up 'multiple startup projects' for your solution of: ConsumerSite and OrderProcesor.

1. Simulate intermittent DB outage
* Locate OrderPlacementWithIntermittentDbError 
* Modify it so that it throws an Exception for 50% of incoming messages
* Write all errors to the console  `Console.WriteLine("Oops. Unable to to process the order id {0}", message.OrderId);`

2. Swap the handler of PlaceOrder message 
 * In OrderProcessor project, locate the bus declaration
 * Swap the handler of PlaceOrder message with OrderPlacementWithIntermittentDbError


##Place a couple of Orders...

You should see that there are Oops messages indicating intermittent DB errors but they get retried and eventually get processed.