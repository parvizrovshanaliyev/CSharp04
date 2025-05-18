using System;
using System.Collections;

namespace CompareArrayVsArrayList;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Array vs ArrayList Comparison ===\n");

        /*
         * ----------------------------------------------------
         * ARRAY SECTION: Demonstrates type-safe, fixed-length array
         * ----------------------------------------------------
         * Arrays in C# are strongly typed and their size must be 
         * defined at the time of declaration. They offer better 
         * performance compared to ArrayList due to the absence of 
         * boxing/unboxing and runtime casting.
         */
        Console.WriteLine("🔹 Array (Strongly Typed):");
        int[] intArray = new int[3];
        intArray[0] = 10;
        intArray[1] = 20;
        intArray[2] = 30;

        foreach (var item in intArray)
        {
            Console.WriteLine($"Array item: {item}");
        }

        /*
         * The following operations are intentionally commented out
         * as they will result in compile-time errors due to:
         * 1. Array index out of bounds
         * 2. Type mismatch assignment
         */
        // intArray[3] = 40;        // ❌ Index out of range
        // intArray[1] = "test";    // ❌ Type mismatch

        /*
         * ---------------------------------------------------------
         * ARRAYLIST SECTION: Demonstrates dynamically-sized, 
         * object-based collection with no compile-time type safety
         * ---------------------------------------------------------
         * ArrayList can store heterogeneous types as it stores all 
         * elements as `object`. This flexibility comes at the cost 
         * of runtime casting and potential errors.
         */
        Console.WriteLine("\n🔹 ArrayList (Loosely Typed):");
        ArrayList arrayList = new ArrayList();
        arrayList.Add(10);         // int (boxed into object)
        arrayList.Add("hello");    // string
        arrayList.Add(3.14);       // double

        foreach (var item in arrayList)
        {
            Console.WriteLine($"ArrayList item (type {item.GetType()}): {item}");
        }

        /*
         * When retrieving data from an ArrayList, type casting is 
         * necessary. This introduces a risk of runtime exceptions 
         * if the type is incorrect or unexpected.
         */
        int firstValue = (int)arrayList[0]; // ✅ Valid cast

        // The following line would throw an InvalidCastException
        // int invalidCast = (int)arrayList[1]; // ❌ string to int

        Console.WriteLine($"\n✅ First value in ArrayList (casted to int): {firstValue}");

        /*
         * ----------------------------------------------------
         * Demonstrates automatic resizing capability of ArrayList
         * ----------------------------------------------------
         * Unlike arrays, ArrayList grows in capacity as elements 
         * are added beyond the initial allocation.
         */
        Console.WriteLine("\n🔹 Demonstrating dynamic growth:");
        arrayList.Add(100);
        arrayList.Add(200);
        Console.WriteLine($"ArrayList count after additions: {arrayList.Count}");

        // In contrast, array length remains fixed after declaration
        Console.WriteLine($"Array length (fixed): {intArray.Length}");

        Console.WriteLine("\n✅ Comparison complete.");
    }
}