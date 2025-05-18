# 🔐 Hashtable in C# - A Complete Guide (Zero to Hero)

This guide covers everything you need to know about using `Hashtable` in C#. By the end, you'll understand what a hashtable is, when to use it, how it works, and what its limitations are — all with practical code examples.

---

## 📘 What is a Hashtable?

A **Hashtable** is a **collection of key-value pairs** where:

* Each **key is unique**
* Values are accessed using their corresponding keys
* It uses **hashing** for fast lookups

> Namespace: `System.Collections`
> Type: `non-generic` (Use `Dictionary<TKey, TValue>` for a generic alternative)

---

## ⚙️ Syntax

```csharp
using System.Collections;

// Create
Hashtable hashtable = new Hashtable();

// Add
hashtable.Add("id", 101);
hashtable.Add("name", "Alice");

// Access
Console.WriteLine(hashtable["name"]); // Output: Alice

// Update
hashtable["name"] = "Bob";

// Remove
hashtable.Remove("id");

// Iterate
foreach (DictionaryEntry entry in hashtable)
{
    Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
}
```

---

## 🚀 Features

| Feature          | Description                             |
| ---------------- | --------------------------------------- |
| Type             | Non-generic (stores `object`)           |
| Indexing         | Key-based                               |
| Key uniqueness   | Keys must be unique                     |
| Order            | **Unordered** (no guarantee of order)   |
| Thread-safe      | ❌ Not by default                        |
| Dynamic resizing | ✅ Automatically resizes                 |
| Null keys        | ❌ Not allowed (`ArgumentNullException`) |
| Null values      | ✅ Allowed                               |

---

## 🔍 When to Use Hashtable?

✅ Use Hashtable when:

* You are working with .NET 1.1 legacy code
* You need **key-value** storage
* You **don’t care about types** (i.e., mixed types allowed)
* You want **fast lookups** (constant time on average)

❌ Avoid it in modern code:

* Use `Dictionary<TKey, TValue>` instead for type safety and better performance

---

## 🎯 Common Operations

### ➕ Add Entry

```csharp
hashtable.Add("username", "parviz");
```

### 🔄 Update Value

```csharp
hashtable["username"] = "elmar";
```

### ❌ Remove Key

```csharp
hashtable.Remove("username");
```

### ✅ Check if Key Exists

```csharp
if (hashtable.ContainsKey("username"))
{
    Console.WriteLine("User exists!");
}
```

### 🔁 Iterate

```csharp
foreach (DictionaryEntry entry in hashtable)
{
    Console.WriteLine($"{entry.Key} = {entry.Value}");
}
```

---

## ⚠️ Limitations

* ❌ Not type-safe (you must cast)
* ❌ No generic support (use `Dictionary<TKey, TValue>` instead)
* ❌ Slower than `Dictionary` for most modern workloads
* ❌ Not ordered (use `SortedList` or `SortedDictionary` if needed)

---

## 🧠 Hashtable vs Dictionary

| Feature            | `Hashtable`          | `Dictionary<TKey, TValue>`            |
| ------------------ | -------------------- | ------------------------------------- |
| Type Safety        | ❌ No (uses `object`) | ✅ Yes (generic)                       |
| Null Keys          | ❌ Not allowed        | ✅ Allowed (except with structs)       |
| Performance        | ⚠️ Slower            | ✅ Faster                              |
| Thread Safety      | ❌ No                 | ❌ No (but has `ConcurrentDictionary`) |
| Use in modern code | ❌ Outdated           | ✅ Recommended                         |

---

## 🧪 Sample Use Case

```csharp
using System;
using System.Collections;

class Program
{
    static void Main()
    {
        Hashtable phoneBook = new Hashtable();
        phoneBook.Add("User1", "070-123-4561");
        phoneBook.Add("User2", "050-987-6541");

        Console.WriteLine("Phone numbers:");
        foreach (DictionaryEntry entry in phoneBook)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }
}
```

---

## 📦 Bonus: Null & Error Handling

```csharp
try
{
    hashtable.Add(null, "value"); // ❌ Throws ArgumentNullException
}
catch (ArgumentNullException)
{
    Console.WriteLine("❗ Null keys are not allowed.");
}
```

---

## ✅ Best Practices

* Prefer `Dictionary<TKey, TValue>` in modern applications
* Avoid boxing/unboxing by using generics
* Don’t depend on order of keys
* Check `ContainsKey()` before accessing by key
* Consider `ConcurrentDictionary` for thread-safe scenarios

---

## 📚 Summary

| ✅ What You Learned                        |
| ----------------------------------------- |
| ✔ What a Hashtable is                     |
| ✔ How to create, update, delete entries   |
| ✔ Why it's legacy and what to use instead |
| ✔ Key differences with `Dictionary`       |

---

