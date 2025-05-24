using System;
using System.Collections;

namespace Collections.NoneGenericQueueClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * ================================================
             * 🔰 DEMO: Non-Generic Queue in C#
             * ================================================
             * Queue follows FIFO: First In, First Out.
             * We use Enqueue() to add, Dequeue() to remove, Peek() to view the front.
             * This example uses non-generic Queue from System.Collections.
             */

            Console.WriteLine("=== Creating a Non-Generic Queue ===\n");

            // �� Create a new queue with initial capacity
            Queue queue = new Queue(10); // Specify initial capacity for better performance

            // 🔸 Enqueue various types of elements
            queue.Enqueue(10);        // int
            queue.Enqueue("Hello");   // string
            queue.Enqueue(3.14f);     // float
            queue.Enqueue(true);      // bool
            queue.Enqueue(67.8);      // double
            queue.Enqueue('A');       // char

            /*
             * 🔁 Display all elements in the queue
             * (Note: Queue iterates from front to back – FIFO order)
             */
            Console.WriteLine("📋 Queue Elements:");
            foreach (object item in queue)
            {
                Console.WriteLine($"  ➤ {item}");
            }

            Console.WriteLine($"\n🧮 Total elements in queue: {queue.Count}");
            Console.WriteLine($"📊 Queue capacity: {queue.Count} (dynamic)");
            Console.ReadKey();
            Console.Clear();

            /*
             * 🗑️ DEQUEUE – Removes and returns the front element
             * Throws InvalidOperationException if the queue is empty
             */
            Console.WriteLine("=== Removing Front Element Using Dequeue() ===");

            var removedItem = queue.Dequeue();
            Console.WriteLine($"❌ Removed Item: {removedItem}");

            Console.WriteLine($"\n📋 Queue After Dequeue (Count: {queue.Count}):");
            foreach (object item in queue)
            {
                Console.WriteLine($"  ➤ {item}");
            }

            Console.ReadKey();
            Console.Clear();

            /*
             * 🔎 PEEK – Returns the front element without removing it
             */
            Console.WriteLine("=== Peek Front Element ===");
            Console.WriteLine($"👀 Front Element: {queue.Peek()}");
            Console.WriteLine($"🧮 Total Elements: {queue.Count}");

            /*
             * 🔍 CONTAINS – Check if an element exists in the queue
             */
            Console.WriteLine("\n=== Checking Queue Contents ===");
            Console.WriteLine($"🔍 Contains 'Hello'? ➤ {queue.Contains("Hello")}");
            Console.WriteLine($"🔍 Contains 999? ➤ {queue.Contains(999)}");

            /*
             * 📋 Copy Queue to Array
             */
            Console.WriteLine("\n=== Copying Queue to Array ===");
            object[] queueArray = new object[queue.Count];
            queue.CopyTo(queueArray, 0);
            Console.WriteLine("📋 Queue Elements in Array:");
            foreach (object item in queueArray)
            {
                Console.WriteLine($"  ➤ {item}");
            }

            /*
             * 🎯 Practical Example: Process Queue
             */
            Console.WriteLine("\n=== Practical Example: Processing Queue ===");
            Queue processQueue = new Queue();
            processQueue.Enqueue("Task 1: Initialize");
            processQueue.Enqueue("Task 2: Load Data");
            processQueue.Enqueue("Task 3: Process");
            processQueue.Enqueue("Task 4: Save Results");

            Console.WriteLine("🔄 Processing Queue Items:");
            while (processQueue.Count > 0)
            {
                string task = (string)processQueue.Dequeue();
                Console.WriteLine($"  ⏳ Processing: {task}");
                // Simulate task processing
                System.Threading.Thread.Sleep(500);
                Console.WriteLine($"  ✅ Completed: {task}");
            }

            /*
             * 🧹 CLEAR – Remove all elements from the queue
             */
            Console.WriteLine("\n=== Clearing Queue ===");
            queue.Clear();
            Console.WriteLine($"🧺 Queue Cleared. Remaining Count: {queue.Count}");

            /*
             * 🛑 DEQUEUE or PEEK on empty queue will throw exception
             * Uncommenting below will cause runtime error
             */
            // queue.Dequeue(); // ❌ InvalidOperationException
            // queue.Peek(); // ❌ InvalidOperationException

            /*
             * 💡 Queue Behavior Notes:
             * 1. Queue is not thread-safe by default
             * 2. For thread-safe operations, use ConcurrentQueue<T>
             * 3. Queue automatically grows when capacity is reached
             * 4. Queue maintains insertion order (FIFO)
             */

            Console.WriteLine("\n✅ Demo Complete.");
            Console.ReadKey();
        }
    }
}
