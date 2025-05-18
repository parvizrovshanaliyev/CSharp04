# 🥞 Stack in C# – A Complete Guide (Zero to Hero)

Welcome to your one-stop guide to mastering the **Stack** data structure in **C#**. This guide takes you from beginner to advanced, covering core concepts, syntax, use cases, and best practices — all with practical examples.

---

## 📌 What Is a Stack?

A **Stack** is a **linear data structure** that follows the **LIFO** principle — **Last In, First Out**.

> The last element added is the first one to be removed.

---

## 🧠 Real-World Analogies

* **Undo/Redo** in text editors
* **Back/Forward** navigation in web browsers
* **Call Stack** in programming languages
* **Reversing strings** or arrays

---

## 📦 Stack Types in C\#

| Type       | Namespace                    | Description                           |
| ---------- | ---------------------------- | ------------------------------------- |
| `Stack`    | `System.Collections`         | Non-generic version (stores `object`) |
| `Stack<T>` | `System.Collections.Generic` | Generic version (recommended)         |

---

## ⚙️ Core Stack Operations

| Method         | Description                                      |
| -------------- | ------------------------------------------------ |
| `Push(T item)` | Adds an item to the top of the stack             |
| `Pop()`        | Removes and returns the item at the top          |
| `Peek()`       | Returns the item at the top **without removing** |
| `Count`        | Gets the number of elements in the stack         |
| `Clear()`      | Removes all items from the stack                 |
| `Contains(T)`  | Checks whether an item exists in the stack       |

---

## ✅ Basic Example

```csharp
using System.Collections;

Stack stack = new Stack();
stack.Push("A");
stack.Push("B");
stack.Push("C");

Console.WriteLine(stack.Peek()); // Output: C
Console.WriteLine(stack.Pop());  // Output: C
Console.WriteLine(stack.Count);  // Output: 2
```

---

## 🔁 Iterating Through a Stack

```csharp
foreach (var item in stack)
{
    Console.WriteLine(item); // Output: top to bottom
}
```

> ❗ Iteration is LIFO (from most recent to oldest item)

---

## 💡 Generic Stack<T> (Preferred)

```csharp
Stack<int> numbers = new Stack<int>();
numbers.Push(10);
numbers.Push(20);

Console.WriteLine(numbers.Peek()); // 20
Console.WriteLine(numbers.Pop());  // 20
```

✅ Benefits of using `Stack<T>`:

* Type safety (no casting)
* Better performance
* No boxing/unboxing

---

## 🚀 Real-World Use Cases

| Scenario                          | Why Stack?                       |
| --------------------------------- | -------------------------------- |
| Undo/Redo feature in applications | Stores previous actions          |
| Balanced parentheses checker      | Tracks opening/closing brackets  |
| Reverse strings                   | Push all characters, then pop    |
| Expression evaluation (postfix)   | Backtrack operands and operators |
| Recursive algorithms              | Simulate call stack manually     |

---

## 🧪 Common Example: Reverse a String

```csharp
string input = "hello";
Stack<char> stack = new Stack<char>();

foreach (char c in input)
    stack.Push(c);

string reversed = "";
while (stack.Count > 0)
    reversed += stack.Pop();

Console.WriteLine(reversed); // Output: olleh
```

---

## ⚠️ Common Pitfalls

* ❌ Calling `Pop()` or `Peek()` on an empty stack throws `InvalidOperationException`.
* ❌ Assuming stack preserves insertion order (it's LIFO).
* ❌ Using Stack when FIFO is required (use `Queue` instead).

---

## 🔍 Stack vs Queue in C\#

| Feature     | Stack                     | Queue                      |
| ----------- | ------------------------- | -------------------------- |
| Principle   | LIFO (Last-In, First-Out) | FIFO (First-In, First-Out) |
| Add item    | `Push()`                  | `Enqueue()`                |
| Remove item | `Pop()`                   | `Dequeue()`                |
| Use cases   | Undo, call stack, reverse | Job scheduling, pipelines  |

---

## 📚 Summary

| ✅ You Have Learned About:                 |
| ----------------------------------------- |
| ✔ What a Stack is                         |
| ✔ Core operations (`Push`, `Pop`, `Peek`) |
| ✔ Generic vs non-generic versions         |
| ✔ Real-world use cases                    |
| ✔ Common mistakes and interview tips      |

---

## 🎁 Bonus: Interview Challenge

> Write a method to check whether a given expression has **balanced parentheses** using a `Stack<char>`.

```csharp
Input: "{[()]}" → Balanced  
Input: "{[(])}" → Not balanced
```

---

## 🧰 Recommended Practice Projects

* 📋 **Browser History** simulation
* 🧮 **Postfix Expression Evaluator**
* 🔄 **String Palindrome Checker**
* ✍️ **Undo/Redo Text Editor Mock**
