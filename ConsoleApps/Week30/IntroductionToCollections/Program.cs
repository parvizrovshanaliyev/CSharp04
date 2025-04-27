using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IntroductionToCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C# Collections Demo\n");

            // List<T> Demo
            DemoList();

            // Dictionary<TKey,TValue> Demo
            DemoDictionary();

            // HashSet<T> Demo
            DemoHashSet();

            // Queue<T> Demo
            DemoQueue();

            // Stack<T> Demo
            DemoStack();

            // ArrayList Demo (Non-generic)
            DemoArrayList();

            // Hashtable Demo (Non-generic)
            DemoHashtable();

            // LINQ Demo
            DemoLinq();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void DemoList()
        {
            Console.WriteLine("=== List<T> Demo ===");

            // Creating and adding elements
            List<string> fruits = new List<string>();
            fruits.Add("Apple");
            fruits.Add("Banana");
            fruits.Add("Orange");
            fruits.AddRange(new[] { "Mango", "Grape" });

            // Displaying elements
            Console.WriteLine("All fruits:");
            foreach (string fruit in fruits)
            {
                Console.WriteLine($"- {fruit}");
            }

            // Searching
            Console.WriteLine($"\nContains 'Apple': {fruits.Contains("Apple")}");
            Console.WriteLine($"Index of 'Banana': {fruits.IndexOf("Banana")}");

            // Removing elements
            fruits.Remove("Mango");
            fruits.RemoveAt(0); // Remove first element

            // Sorting
            fruits.Sort();
            Console.WriteLine("\nSorted fruits:");
            fruits.ForEach(f => Console.WriteLine($"- {f}"));
            Console.WriteLine();
        }

        static void DemoDictionary()
        {
            Console.WriteLine("=== Dictionary<TKey,TValue> Demo ===");

            // Creating and adding elements
            Dictionary<string, int> ages = new Dictionary<string, int>();
            ages["John"] = 25;
            ages["Jane"] = 30;
            ages.Add("Bob", 35);

            // Accessing and displaying elements
            Console.WriteLine("Ages:");
            foreach (KeyValuePair<string, int> entry in ages)
            {
                Console.WriteLine($"- {entry.Key} is {entry.Value} years old");
            }

            // Checking existence
            string searchName = "John";
            if (ages.ContainsKey(searchName))
            {
                Console.WriteLine($"\n{searchName}'s age is: {ages[searchName]}");
            }

            // Removing entry
            ages.Remove("Bob");
            Console.WriteLine();
        }

        static void DemoHashSet()
        {
            Console.WriteLine("=== HashSet<T> Demo ===");

            // Creating and adding elements
            HashSet<int> set1 = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<int> set2 = new HashSet<int> { 4, 5, 6, 7, 8 };

            // Set operations
            Console.WriteLine("Set 1: " + string.Join(", ", set1));
            Console.WriteLine("Set 2: " + string.Join(", ", set2));

            // Union
            HashSet<int> union = new HashSet<int>(set1);
            union.UnionWith(set2);
            Console.WriteLine("\nUnion: " + string.Join(", ", union));

            // Intersection
            HashSet<int> intersection = new HashSet<int>(set1);
            intersection.IntersectWith(set2);
            Console.WriteLine("Intersection: " + string.Join(", ", intersection));

            // Difference
            HashSet<int> difference = new HashSet<int>(set1);
            difference.ExceptWith(set2);
            Console.WriteLine("Difference (Set1 - Set2): " + string.Join(", ", difference));
            Console.WriteLine();
        }

        static void DemoQueue()
        {
            Console.WriteLine("=== Queue<T> Demo ===");

            // Creating and adding elements
            Queue<string> printQueue = new Queue<string>();
            printQueue.Enqueue("Document1.pdf");
            printQueue.Enqueue("Document2.pdf");
            printQueue.Enqueue("Document3.pdf");

            Console.WriteLine("Print queue contents:");
            foreach (string doc in printQueue)
            {
                Console.WriteLine($"- {doc}");
            }

            // Processing queue
            Console.WriteLine("\nProcessing print queue:");
            while (printQueue.Count > 0)
            {
                string doc = printQueue.Dequeue();
                Console.WriteLine($"Printing: {doc}");
            }
            Console.WriteLine();
        }

        static void DemoStack()
        {
            Console.WriteLine("=== Stack<T> Demo ===");

            // Creating and adding elements
            Stack<string> browserHistory = new Stack<string>();
            browserHistory.Push("https://www.google.com");
            browserHistory.Push("https://www.microsoft.com");
            browserHistory.Push("https://www.github.com");

            Console.WriteLine("Browser history (most recent first):");
            foreach (string url in browserHistory)
            {
                Console.WriteLine($"- {url}");
            }

            // Popping elements
            Console.WriteLine("\nGoing back in history:");
            while (browserHistory.Count > 0)
            {
                string url = browserHistory.Pop();
                Console.WriteLine($"Previous page: {url}");
            }
            Console.WriteLine();
        }

        static void DemoArrayList()
        {
            Console.WriteLine("=== ArrayList Demo ===");

            // Creating and adding elements
            ArrayList list = new ArrayList();
            list.Add("String");
            list.Add(123);
            list.Add(true);
            list.Add(3.14);

            // Displaying elements
            Console.WriteLine("ArrayList contents:");
            foreach (object item in list)
            {
                Console.WriteLine($"- {item} (Type: {item.GetType().Name})");
            }
            Console.WriteLine();
        }

        static void DemoHashtable()
        {
            Console.WriteLine("=== Hashtable Demo ===");

            // Creating and adding elements
            Hashtable table = new Hashtable();
            table.Add("string_key", "String value");
            table.Add(1, 100);
            table.Add(2.5, true);

            // Displaying elements
            Console.WriteLine("Hashtable contents:");
            foreach (DictionaryEntry entry in table)
            {
                Console.WriteLine($"- Key: {entry.Key} (Type: {entry.Key.GetType().Name})");
                Console.WriteLine($"  Value: {entry.Value} (Type: {entry.Value.GetType().Name})");
            }
            Console.WriteLine();
        }

        static void DemoLinq()
        {
            Console.WriteLine("=== LINQ Demo ===");

            // Create a list of numbers
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // LINQ query examples
            var evenNumbers = numbers.Where(n => n % 2 == 0);
            var doubledNumbers = numbers.Select(n => n * 2);
            var sortedDescending = numbers.OrderByDescending(n => n);
            var sum = numbers.Sum();
            var average = numbers.Average();

            // Display results
            Console.WriteLine("Original numbers: " + string.Join(", ", numbers));
            Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));
            Console.WriteLine("Doubled numbers: " + string.Join(", ", doubledNumbers));
            Console.WriteLine("Sorted descending: " + string.Join(", ", sortedDescending));
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Average: {average}");
            Console.WriteLine();
        }
    }
}
