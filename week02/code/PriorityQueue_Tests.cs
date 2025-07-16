using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: FredLow, JohnHigh, SueMedium will be enqueued. Where JohnHigh have the highest priority then, SueMedium and then FredLow
    // Expected Result: The Item that should be dequed first is JohnHigh
    // Defect(s) Found: The test doesnt end, I thought it might be because it was not removing anything.
    // I added  _queue.RemoveAt(highPriorityIndex); to the dequeue function and also a -1 in the for loop


    public void TestEnqueueAndDequeue()
    {

        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("FredLow", 1);
        priorityQueue.Enqueue("JohnHigh", 6);
        priorityQueue.Enqueue("SueMedium", 3);

        var result = new List<string>();
        while (priorityQueue.Length > 0)
        {

            result.Add(priorityQueue.Dequeue());
        }
        var expectOrder = new List<string> { "JohnHigh", "SueMedium", "FredLow" };

        CollectionAssert.AreEqual(expectOrder, result);
    }

    [TestMethod]
    // Scenario: FredLow, JohnHighFirst, SueMediumSecond will be enqueued. Where JohnHighFirst was enqueued before Sue that has the same priority, JohnHighFirst should be dequeued.
    // Expected Result: JohnHighFirst should be dequeued first
    // Defect(s) Found: It came first Sue that had the same priority as John, it should be John because it was in the queue first.
    //I found that this if statement should be changed from >= to this > so it just takes in account priority if the priority is higher and not equal.
    public void TestSamePriority()
    {

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("FredLow", 1);
        priorityQueue.Enqueue("JohnHighFirst", 6);
        priorityQueue.Enqueue("SueHighSecond", 6);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("JohnHighFirst", result);
    }

    // Add more test cases as needed below.
}