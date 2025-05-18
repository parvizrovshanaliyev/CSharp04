using System;
using System.Collections;

namespace Collections.NoneGenericStackClass;

internal class Program
{
    static void Main(string[] args)
    {
        /*
         * ================================================
         * 🔰 DEMO: Non-Generic Stack in C#
         * ================================================
         * Stack follows LIFO: Last In, First Out.
         * We use Push() to add, Pop() to remove, Peek() to view the top.
         * This example uses non-generic Stack from System.Collections.
         */

        Console.WriteLine("=== Creating a Non-Generic Stack ===\n");

        // 🔸 Create a new stack
        Stack stack = new Stack();

        // 🔸 Push various types of elements onto the stack
        stack.Push(10);        // int
        stack.Push("Hello");   // string
        stack.Push(3.14f);     // float
        stack.Push(true);      // bool
        stack.Push(67.8);      // double
        stack.Push('A');       // char

        /*
         * 🔁 Display all elements in the stack
         * (Note: Stack iterates from top to bottom – LIFO order)
         */
        Console.WriteLine("📋 Stack Elements:");
        foreach (object item in stack)
        {
            Console.WriteLine($"  ➤ {item}");
        }

        Console.WriteLine($"\n🧮 Total elements in stack: {stack.Count}");
        Console.ReadKey();
        Console.Clear();

        /*
         * 🗑️ POP – Removes and returns the top element
         * Throws InvalidOperationException if the stack is empty
         */
        Console.WriteLine("=== Removing Top Element Using Pop() ===");

        var removedItem = stack.Pop();
        Console.WriteLine($"❌ Removed Item: {removedItem}");

        Console.WriteLine($"\n📋 Stack After Pop (Count: {stack.Count}):");
        foreach (object item in stack)
        {
            Console.WriteLine($"  ➤ {item}");
        }

        Console.ReadKey();
        Console.Clear();

        /*
         * 🔎 PEEK – Returns the top element without removing it
         */
        Console.WriteLine("=== Peek Top Element ===");
        Console.WriteLine($"👀 Top Element: {stack.Peek()}");
        Console.WriteLine($"🧮 Total Elements: {stack.Count}");

        /*
         * 🔍 CONTAINS – Check if an element exists in the stack
         */
        Console.WriteLine("\n=== Checking Stack Contents ===");
        Console.WriteLine($"🔍 Contains 'Hello'? ➤ {stack.Contains("Hello")}");
        Console.WriteLine($"🔍 Contains 999? ➤ {stack.Contains(999)}");

        /*
         * 🧹 CLEAR – Remove all elements from the stack
         */
        Console.WriteLine("\n=== Clearing Stack ===");
        stack.Clear();
        Console.WriteLine($"🧺 Stack Cleared. Remaining Count: {stack.Count}");

        /*
         * 🛑 POP or PEEK on empty stack will throw exception
         * Uncommenting below will cause runtime error
         */
        // stack.Pop(); // ❌ InvalidOperationException
        // stack.Peek(); // ❌ InvalidOperationException

        Console.WriteLine("\n✅ Demo Complete.");
        Console.ReadKey();
    }
}