using System;
using System.Collections;

namespace Collections.NonGenericArrayListCollectionClass;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== ArrayList Demonstration: Non-Generic Collection ===\n");

        // Initialize a new ArrayList instance
        ArrayList mixedList = new ArrayList();
        object[] objectArray= new object[10];

        /*
         * ArrayList can hold elements of any data type.
         * Internally, value types are boxed into objects.
         * This flexibility comes with trade-offs (e.g., lack of type safety).
         */
        mixedList.Add(100);                  // int
        objectArray[0] = 100;
        mixedList.Add("Hello World");        // string
        objectArray[1] = "Hello World";
        mixedList.Add(true);                 // bool
        objectArray[2] = true;
        mixedList.Add(99.99);                // double
        objectArray[3] = 99.99;
        mixedList.Add(DateTime.Now);         // DateTime object
        objectArray[4]= DateTime.Now;

        Console.WriteLine("Initial list content:");
        foreach (var item in mixedList)
        {
            Console.WriteLine($" - {item} (Type: {item.GetType().Name})");
        }

        Console.WriteLine($"\nCount: {mixedList.Count}");
        Console.WriteLine($"Capacity: {mixedList.Capacity}\n");

        // Insert an element at index 2
        mixedList.Insert(2, "Inserted String");
        Console.WriteLine("After Insert at index 2:");
        foreach (var item in mixedList)
        {
            Console.WriteLine($" - {item}");
        }

        // Remove specific elements
        mixedList.Remove("Hello World");       // by value
        mixedList.RemoveAt(0);                 // by index

        Console.WriteLine("\nAfter Removals:");
        foreach (var item in mixedList)
        {
            Console.WriteLine($" - {item}");
        }

        // Check for existence
        Console.WriteLine("\nContains 99.99: " + mixedList.Contains(99.99));

        // Accessing and modifying elements
        Console.WriteLine("\nAccessing by Index:");
        for (int i = 0; i < mixedList.Count; i++)
        {
            Console.WriteLine($"Index {i}: {mixedList[i]}");
        }

        // Updating a value at a given index
        if (mixedList.Count > 1)
        {
            mixedList[1] = "Updated Value";
            Console.WriteLine("\nAfter Updating Index 1:");
            foreach (var item in mixedList)
            {
                Console.WriteLine($" - {item}");
            }
        }

        // Demonstrating sorting and reversing (homogeneous list only)
        ArrayList intList = new ArrayList() { 3, 1, 4, 1, 5, 9 };
        intList.Sort();
        Console.WriteLine("\nSorted Integer List:");
        foreach (var num in intList)
        {
            Console.WriteLine(num);
        }

        intList.Reverse();
        Console.WriteLine("\nReversed Integer List:");
        foreach (var num in intList)
        {
            Console.WriteLine(num);
        }

        // Demonstrating Boxing and Unboxing
        Console.WriteLine("\nBoxing and Unboxing Example:");
        int original = 10;
        mixedList.Add(original);          // Boxing
        int unboxed = (int)mixedList[mixedList.Count - 1]; // Unboxing
        Console.WriteLine($"Original: {original}, Unboxed: {unboxed}");

        // Capacity resizing demo
        Console.WriteLine("\nCapacity before adding 20 items:");
        Console.WriteLine($"Capacity: {mixedList.Capacity}");
        for (int i = 0; i < 20; i++) mixedList.Add(i);
        Console.WriteLine("Capacity after adding 20 items:");
        Console.WriteLine($"Capacity: {mixedList.Capacity}, Count: {mixedList.Count}");

        // Clearing the list
        mixedList.Clear();
        Console.WriteLine("\nCleared mixedList. Count: " + mixedList.Count);

        // Exception handling when sorting mixed data
        ArrayList badSortList = new ArrayList { 1, "string", 3 };
        try
        {
            badSortList.Sort();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("\nException on mixed-type sort: " + ex.Message);
        }
    }
}