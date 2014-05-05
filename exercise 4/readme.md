#Exercise 4:
In this exercise we're going to demonstrate how JustSaying enables you to recover from failure by moving unhandled messages from a dead letter queue and into the incoming queue.
The scenario we are going to implement is for OrderProcessor to throw an exception when handling PlaceOrder command. Then we use JustSaying.Tools.exe to move the dead messages into the incoming queue after the bug (exceptiom) is fixed.

##Prerequisites: 
* Ensure you have set up 'multiple startup projects' for your solution of: ConsumerSite and OrderProcesor.

1. Simulate a bug in OrderProcessor during handling PlaceOrder command.
* Locate OrderPlacement 
* Modify it so that it throws an Exception while handling PlaceOrder.

2. Update the bus declaration in OrderProcessor so that failed messages go straight to dead letter queue without retrying. This step will speed up the exercise.
* You need to add `config.RetryCountBeforeSendingToErrorQueue = 1;` to `ConfigureSubscriptionWith(config => {})`

3. Run the solution without debugging and place a few orders and verify that messages are moved to the dead letter queue.
* Hint: The convention for dead letter queue name is 'queuename_error'

4. Fix the bug in the application by removing the Exception you introduced earlier.

5. Now install JustSaying power tools from nuget in Tools project. `Installl-Package JustSaying.Tools`

6. Build the solution

7. CD into {solution-folder}\Tools\bin\debug

8. Run JustSaying.Tools.exe move -from "source" -to "destination" -count "number-of-messages"

9. Run OrderProcesser if it's not running and verify the messages you moved from the dead letter queue has been processed.


Well-done you have just recovered from failure and didn't lose a single order!