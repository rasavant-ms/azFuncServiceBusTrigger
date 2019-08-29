# Sample Service Bus Producer and 3 ServiceBus Topic triggered Azure Functions

## Pre-req :
* Service Bus with a topic and 3 subscriptions - car0, car1 and car2
* Default filter set as Correlation filter on all three subscriptions with CorrelationId and Label set as car0, car1 and car2 respectively
Refer to this link to create correlation filter - [Create ServiceBus Rule for Subscription using Az CLI](https://docs.microsoft.com/en-us/cli/azure/servicebus/topic/subscription/rule?view=azure-cli-latest#az-servicebus-topic-subscription-rule-create)

### Sample Producer :
* Will send 50 messages (number can be changed) to 3 different subscriptions on 1 single service bus topic - total messages = 50 * 3 =150
* CorrelationId and Label is used to filter the message to the right subscription on the service bus side
* Each message has additional properties set randomly - color, location, randomField

### Function 1 - Car0 :
* Processes messages in batches from subscription Car0
* Could not print the Enqueued time since that property is not available in the beta release nuget package - raised feedback here - https://github.com/Azure/azure-functions-servicebus-extension/issues/15#issuecomment-526010126
* Observation - Order is not maintained

### Function 2 - Car1 : (same as above for subscription Car1)

### Function 3 - Car2 :
* Processes messages individually from subscription Car2
* Prints out enqueued time in UTC as well as current time
* Observation - Message order is mostly maintained but not guaranteed to be in order.
* Observation - Latency was observed to be around 150-200ms for this test case between Enqueued time and time message was read in the Azure function

## Next Steps:
* Deploying functions to Azure and adding Application Insights for better latency observations - we may be able to observe the EnqueuedTime in milliseconds for the Function 1 and 2 as well here
* Creating script to automate creation subscriptions and adding rules to it
