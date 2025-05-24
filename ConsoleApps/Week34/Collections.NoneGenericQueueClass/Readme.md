# 🚶 Queue in C# – A Complete Guide (Zero to Hero)

Welcome to your one-stop guide to mastering the **Queue** data structure in **C#**. This guide takes you from beginner to advanced, covering core concepts, syntax, use cases, and best practices — all with practical examples.

---

## 📌 What Is a Queue?

A **Queue** is a **linear data structure** that follows the **FIFO** principle — **First In, First Out**.

> The first element added is the first one to be removed.

---

## 🧠 Real-World Analogies

* **Print Queue** in printers
* **Ticket Counter** line
* **Message Queue** in applications
* **Task Scheduler** in operating systems

---

## 📦 Queue Types in C#

| Type        | Namespace                    | Description                           |
| ----------- | ---------------------------- | ------------------------------------- |
| `Queue`     | `System.Collections`         | Non-generic version (stores `object`) |
| `Queue<T>`  | `System.Collections.Generic` | Generic version (recommended)         |

---

## ⚙️ Core Queue Operations

| Method           | Description                                      |
| ---------------- | ------------------------------------------------ |
| `Enqueue(T item)`| Adds an item to the end of the queue            |
| `Dequeue()`      | Removes and returns the item at the front        |
| `Peek()`         | Returns the item at the front **without removing**|
| `Count`          | Gets the number of elements in the queue         |
| `Clear()`        | Removes all items from the queue                 |
| `Contains(T)`    | Checks whether an item exists in the queue       |

---

## ✅ Basic Example

```csharp
using System.Collections;

Queue queue = new Queue();
queue.Enqueue("First");
queue.Enqueue("Second");
queue.Enqueue("Third");

Console.WriteLine(queue.Peek()); // Output: First
Console.WriteLine(queue.Dequeue()); // Output: First
Console.WriteLine(queue.Count); // Output: 2
```

---

## 🔁 Iterating Through a Queue

```csharp
foreach (var item in queue)
{
    Console.WriteLine(item); // Output: front to back
}
```

> ❗ Iteration is FIFO (from oldest to most recent item)

---

## 💡 Generic Queue<T> (Preferred)

```csharp
Queue<int> numbers = new Queue<int>();
numbers.Enqueue(10);
numbers.Enqueue(20);

Console.WriteLine(numbers.Peek()); // 10
Console.WriteLine(numbers.Dequeue()); // 10
```

✅ Benefits of using `Queue<T>`:

* Type safety (no casting)
* Better performance
* No boxing/unboxing

---

## 🚀 Real-World Use Cases

| Scenario                          | Why Queue?                       |
| --------------------------------- | -------------------------------- |
| Print job management              | Process documents in order       |
| Task scheduling                   | Execute tasks in sequence        |
| Message processing                | Handle messages in order         |
| Breadth-first search             | Track nodes to visit             |
| Event handling                    | Process events in order          |

---

## 🧪 Common Example: Process Print Jobs

```csharp
Queue<string> printJobs = new Queue<string>();
printJobs.Enqueue("Document1.pdf");
printJobs.Enqueue("Document2.pdf");
printJobs.Enqueue("Document3.pdf");

while (printJobs.Count > 0)
{
    string currentJob = printJobs.Dequeue();
    Console.WriteLine($"Printing: {currentJob}");
}
```

---

## ⚠️ Common Pitfalls

* ❌ Calling `Dequeue()` or `Peek()` on an empty queue throws `InvalidOperationException`.
* ❌ Assuming queue preserves reverse order (it's FIFO).
* ❌ Using Queue when LIFO is required (use `Stack` instead).

---

## 🔍 Queue vs Stack in C#

| Feature     | Queue                      | Stack                     |
| ----------- | -------------------------- | ------------------------- |
| Principle   | FIFO (First-In, First-Out) | LIFO (Last-In, First-Out) |
| Add item    | `Enqueue()`                | `Push()`                  |
| Remove item | `Dequeue()`                | `Pop()`                   |
| Use cases   | Task scheduling, pipelines | Undo, call stack, reverse |

---

## 📊 Performance Analysis

| Operation  | Time Complexity | Space Complexity | Notes                                    |
|------------|----------------|------------------|------------------------------------------|
| Enqueue    | O(1)          | O(1)            | Constant time, adds to end               |
| Dequeue    | O(1)          | O(1)            | Constant time, removes from front        |
| Peek       | O(1)          | O(1)            | Constant time, no removal                |
| Contains   | O(n)          | O(1)            | Linear time, must search entire queue    |
| Count      | O(1)          | O(1)            | Constant time, stored property           |

### 🔍 Performance Tips:
* Use `Queue<T>` instead of `Queue` for better performance
* Avoid frequent `Contains()` checks on large queues
* Consider capacity if you know the expected size
* Use `TryDequeue()` and `TryPeek()` to avoid exceptions

## 🎯 Advanced Queue Concepts

### 1. Circular Queue
```csharp
public class CircularQueue<T>
{
    private T[] _items;
    private int _front;
    private int _rear;
    private int _count;

    public CircularQueue(int capacity)
    {
        _items = new T[capacity];
        _front = _rear = -1;
        _count = 0;
    }

    public bool Enqueue(T item)
    {
        if (_count == _items.Length) return false;
        
        _rear = (_rear + 1) % _items.Length;
        _items[_rear] = item;
        _count++;
        
        if (_front == -1) _front = _rear;
        return true;
    }
}
```

### 2. Priority Queue
```csharp
public class PriorityQueue<T>
{
    private List<(T item, int priority)> _items = new();

    public void Enqueue(T item, int priority)
    {
        _items.Add((item, priority));
        _items.Sort((a, b) => b.priority.CompareTo(a.priority));
    }

    public T Dequeue()
    {
        var item = _items[0].item;
        _items.RemoveAt(0);
        return item;
    }
}
```

## 🛠️ Best Practices

1. **Error Handling**
   ```csharp
   // Instead of
   var item = queue.Dequeue(); // Might throw

   // Use
   if (queue.TryDequeue(out var item))
   {
       // Process item
   }
   ```

2. **Capacity Management**
   ```csharp
   // If you know the size
   var queue = new Queue<string>(1000);
   ```

3. **Thread Safety**
   ```csharp
   // For thread-safe operations
   var queue = new ConcurrentQueue<string>();
   ```

## 📚 Summary

| ✅ You Have Learned About:                    |
| -------------------------------------------- |
| ✔ What a Queue is                            |
| ✔ Core operations (`Enqueue`, `Dequeue`, `Peek`) |
| ✔ Generic vs non-generic versions            |
| ✔ Real-world use cases                       |
| ✔ Common mistakes and interview tips         |

---

## 🎁 Bonus: Interview Challenge

> Write a method to implement a **circular queue** with a fixed size using an array.

```csharp
Input: Size = 3
Enqueue(1) → [1]
Enqueue(2) → [1,2]
Enqueue(3) → [1,2,3]
Dequeue()  → [2,3]
Enqueue(4) → [2,3,4]
```

---

## 🧰 Recommended Practice Projects

* 📋 **Print Queue** simulation
* 🎮 **Game Event System**
* 📨 **Message Queue** implementation
* ⏱️ **Task Scheduler** mock

## 🔗 Additional Resources

* [Microsoft Docs: Queue<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1)
* [Microsoft Docs: ConcurrentQueue<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentqueue-1)
* [Queue vs Stack Performance](https://docs.microsoft.com/en-us/dotnet/standard/collections/selecting-a-collection-class)
