# ArrayList in C# - A Complete Guide (Zero to Hero)

## Introduction

In this guide, we will explore the **ArrayList** class in C#. This is a **non-generic** collection that can store elements of any data type. Though `ArrayList` is considered outdated in favor of generic collections like `List<T>`, understanding it remains crucial for dealing with legacy systems and some low-level .NET functionalities.

We will walk through the concepts from basic to advanced, including internal working, real-life examples, use cases, and limitations.

---

## Table of Contents

1. What is ArrayList?
2. Declaring and Initializing
3. Adding Elements
4. Accessing Elements
5. Updating Elements
6. Removing Elements
7. Searching Elements
8. Iterating Over ArrayList
9. Capacity vs Count
10. Sorting and Reversing
11. Boxing and Unboxing
12. Performance Considerations
13. Comparison: ArrayList vs List<T>
14. When to Use / Avoid
15. Real-life Scenarios
16. Summary
17. Practice Exercises

---

## 1. What is ArrayList?

The `ArrayList` class is part of the `System.Collections` namespace. It provides a dynamically sized array that can store **any object type**. Internally, it maintains an array and resizes it automatically as elements are added.

> Namespace: `System.Collections`
>
> Assembly: `mscorlib.dll`

### Key Characteristics:

* Stores `object` types (boxed value types and reference types).
* Allows different data types in one list.
* Dynamic resizing.
* Not type-safe.

---

## 2. Declaring and Initializing

```csharp
using System.Collections;

ArrayList list = new ArrayList();
```

You can also initialize with predefined capacity:

```csharp
ArrayList list = new ArrayList(10);
```

Or use a collection:

```csharp
ArrayList list = new ArrayList(new int[] { 1, 2, 3 });
```

---

## 3. Adding Elements

```csharp
list.Add(10);
list.Add("text");
list.Add(true);
list.Add(3.14);
```

To add multiple items:

```csharp
list.AddRange(new object[] { 5, "more", false });
```

---

## 4. Accessing Elements

```csharp
object item = list[0];
Console.WriteLine(item);
```

Type casting is needed for value types:

```csharp
int value = (int)list[0];
```

---

## 5. Updating Elements

```csharp
list[1] = "updated";
```

---

## 6. Removing Elements

```csharp
list.Remove("text");        // by value
list.RemoveAt(0);            // by index
list.Clear();                // remove all
```

---

## 7. Searching Elements

```csharp
bool hasValue = list.Contains(3.14);
int index = list.IndexOf("updated");
```

---

## 8. Iterating Over ArrayList

```csharp
foreach (object item in list)
{
    Console.WriteLine(item);
}
```

Or using a for loop:

```csharp
for (int i = 0; i < list.Count; i++)
{
    Console.WriteLine(list[i]);
}
```

---

## 9. Capacity vs Count

```csharp
Console.WriteLine(list.Count);     // Number of elements
Console.WriteLine(list.Capacity);  // Allocated space
```

Capacity increases automatically as needed, usually doubling in size.

---

## 10. Sorting and Reversing

> Only works if items are of the **same comparable type** (e.g., all ints).

```csharp
list.Sort();
list.Reverse();
```

---

## 11. Boxing and Unboxing

When storing value types (e.g., `int`, `double`) in `ArrayList`, they are **boxed** into objects. Retrieving them requires **unboxing**.

```csharp
int x = 42;
list.Add(x);             // boxing
int y = (int)list[0];     // unboxing
```

This causes performance overhead.

---

## 12. Performance Considerations

| Operation       | Performance Impact           |
| --------------- | ---------------------------- |
| Type Safety     | ❌ Not enforced               |
| Boxing/Unboxing | ❌ Slower for value types     |
| Memory Usage    | ❌ More due to object storage |
| Flexibility     | ✅ Accepts mixed types        |

---

## 13. ArrayList vs List<T>

| Feature     | ArrayList | List<T>       |
| ----------- | --------- | ------------- |
| Type Safe   | ❌ No      | ✅ Yes         |
| Performance | ❌ Slower  | ✅ Faster      |
| Generics    | ❌ No      | ✅ Yes         |
| Usage       | ⚠️ Legacy | ✅ Recommended |

---

## 14. When to Use / Avoid

### ✅ Use:

* Working with legacy code.
* When type is not known at compile time.

### ❌ Avoid:

* In new development — use `List<T>` instead.
* When performance or type safety is critical.

---

## 15. Real-life Scenarios

* Parsing unknown JSON or XML data into objects.
* Storing mixed types for dynamic scripting.
* Refactoring old enterprise applications.

---

## 16. Summary

* `ArrayList` is a non-generic dynamic array.
* Useful in certain legacy or dynamic type scenarios.
* Type casting and boxing can lead to bugs and performance loss.
* Prefer `List<T>` for modern applications.

---

## 17. Practice Exercises

1. Create an ArrayList with integers, strings, and booleans.
2. Write a method that iterates and prints the type of each item.
3. Try to sort a mixed-type ArrayList. What happens?
4. Replace your `ArrayList` with `List<object>`. What's the difference?
5. Implement a search function that returns index of a given value.

---

> 👨‍🏫 **Instructor Tip**: You might encounter `ArrayList` in interviews or legacy systems. Learn it well, but know when to avoid it in real-world projects.

