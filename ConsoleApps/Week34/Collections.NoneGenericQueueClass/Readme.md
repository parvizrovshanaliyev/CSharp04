# Non-Generic Queue in C# – A Complete Guide

Welcome to your comprehensive guide to mastering the non-generic **Queue** data structure in **C#**. This guide covers everything from basic concepts to advanced implementations, with a focus on practical applications.

---

## What Is a Non-Generic Queue?

A non-generic **Queue** is a linear data structure that follows the **FIFO** (First In, First Out) principle, where elements are stored as `object` type.

> The first element added is the first one to be removed, and all elements are stored as objects.

---

## Real-World Applications

* **Print Job Management** (as demonstrated in our example)
* **Message Processing Systems**
* **Task Scheduling**
* **Event Handling**
* **Order Processing Systems**

---

## Queue Implementation Details

| Component   | Description                                    |
|------------|------------------------------------------------|
| Namespace  | `System.Collections`                           |
| Base Type  | `object`                                       |
| Interface  | `ICollection`, `IEnumerable`, `ICloneable`     |

---

## Core Queue Operations

| Method           | Description                                      | Example                                    |
|-----------------|--------------------------------------------------|--------------------------------------------|
| `Enqueue()`     | Adds an item to the end of the queue            | `queue.Enqueue("Document1.pdf")`          |
| `Dequeue()`     | Removes and returns the item at the front        | `var job = queue.Dequeue()`               |
| `Peek()`        | Returns the item at the front without removing   | `var nextJob = queue.Peek()`              |
| `Count`         | Gets the number of elements in the queue         | `int jobsCount = queue.Count`             |
| `Clear()`       | Removes all items from the queue                 | `queue.Clear()`                           |
| `Contains()`    | Checks whether an item exists in the queue       | `bool exists = queue.Contains("job1")`    |

---

## Basic Example

```csharp
using System.Collections;

Queue printQueue = new Queue();
printQueue.Enqueue("Document1.pdf");
printQueue.Enqueue("Document2.pdf");
printQueue.Enqueue("Document3.pdf");

Console.WriteLine(printQueue.Peek());    // Output: Document1.pdf
Console.WriteLine(printQueue.Dequeue()); // Output: Document1.pdf
Console.WriteLine(printQueue.Count);     // Output: 2
```

---

## Iterating Through a Queue

```csharp
foreach (object item in printQueue)
{
    Console.WriteLine(item); // Output: front to back
}
```

> Note: Non-generic Queue stores items as `object`, so type casting may be needed.

---

## Practical Example: Print Job Management System

Here's a simplified version of our print job management system using non-generic Queue:

```csharp
public class PrintJob
{
    public string Name { get; set; }
    public int PrintTime { get; set; }

    public PrintJob(string name, int printTime)
    {
        Name = name;
        PrintTime = printTime;
    }
}

public class PrintQueueManager
{
    private Queue _printQueue;

    public PrintQueueManager()
    {
        _printQueue = new Queue();
    }

    public void AddJob(PrintJob job)
    {
        _printQueue.Enqueue(job);
    }

    public PrintJob ProcessNextJob()
    {
        return (PrintJob)_printQueue.Dequeue();
    }

    public void DisplayQueue()
    {
        foreach (PrintJob job in _printQueue)
        {
            Console.WriteLine($"Job: {job.Name}, Time: {job.PrintTime} minutes");
        }
    }
}
```

---

## Common Pitfalls and Solutions

1. **Type Casting Issues**
   ```csharp
   // Problematic
   string job = queue.Dequeue(); // Compilation error

   // Solution
   string job = (string)queue.Dequeue(); // Explicit casting
   ```

2. **Empty Queue Operations**
   ```csharp
   // Problematic
   var item = queue.Dequeue(); // Throws InvalidOperationException

   // Solution
   if (queue.Count > 0)
   {
       var item = queue.Dequeue();
   }
   ```

3. **Type Safety**
   ```csharp
   // Problematic
   queue.Enqueue(123); // Works, but might cause issues later

   // Solution
   queue.Enqueue("123"); // Be consistent with types
   ```

---

## Performance Considerations

| Operation  | Time Complexity | Space Complexity | Notes                                    |
|------------|----------------|------------------|------------------------------------------|
| Enqueue    | O(1)          | O(1)            | Constant time, adds to end               |
| Dequeue    | O(1)          | O(1)            | Constant time, removes from front        |
| Peek       | O(1)          | O(1)            | Constant time, no removal                |
| Contains   | O(n)          | O(1)            | Linear time, must search entire queue    |

### Performance Tips:
* Consider using `Queue<T>` for better type safety and performance
* Avoid frequent type casting operations
* Use `Count` property to check queue state
* Implement proper error handling

---

## Best Practices

1. **Error Handling**
   ```csharp
   try
   {
       var job = (PrintJob)queue.Dequeue();
       // Process job
   }
   catch (InvalidOperationException)
   {
       Console.WriteLine("Queue is empty");
   }
   catch (InvalidCastException)
   {
       Console.WriteLine("Invalid type in queue");
   }
   ```

2. **Type Safety**
   ```csharp
   // Create a wrapper class
   public class TypedQueue
   {
       private Queue _queue = new Queue();

       public void Enqueue(PrintJob job)
       {
           _queue.Enqueue(job);
       }

       public PrintJob Dequeue()
       {
           return (PrintJob)_queue.Dequeue();
       }
   }
   ```

3. **Thread Safety**
   ```csharp
   // For thread-safe operations
   private readonly object _lockObject = new object();

   public void EnqueueJob(PrintJob job)
   {
       lock (_lockObject)
       {
           _queue.Enqueue(job);
       }
   }
   ```

---

## Summary

| Key Points to Remember                    |
| -------------------------------------------- |
| Non-generic Queue stores items as `object` |
| Requires explicit type casting             |
| Follows FIFO principle                     |
| Thread-safe operations need synchronization|
| Consider using `Queue<T>` for new projects |

---

## Interview Questions

1. How would you implement a thread-safe print queue?
2. What's the difference between `Queue` and `Queue<T>`?
3. How would you handle type casting errors in a non-generic queue?
4. Explain the FIFO principle with a real-world example.

---

## Practice Projects

1. **Print Queue Manager** (as shown above)
2. **Game Event System**
3. **Message Processor**
4. **Task Scheduler**

---

## Additional Resources

* [Microsoft Docs: Queue](https://docs.microsoft.com/en-us/dotnet/api/system.collections.queue)
* [C# Collections Overview](https://docs.microsoft.com/en-us/dotnet/standard/collections/)
* [Thread-Safe Collections](https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/)
