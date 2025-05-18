
# 📘 Array vs ArrayList in C#

In C#, both `Array` and `ArrayList` are used to store collections of items. However, they have key differences in **type safety**, **performance**, and **usage scenarios**. This document provides an in-depth comparison of `Array` and `ArrayList` to help developers choose the right structure for their needs.

---

## 🔍 Overview

| Feature         | `Array`                                  | `ArrayList`                              |
| --------------- | ---------------------------------------- | ---------------------------------------- |
| Namespace       | `System`                                 | `System.Collections`                     |
| Type Safety     | **Strongly typed** (`int[]`, `string[]`) | **Loosely typed** (`object`)             |
| Size            | Fixed size (defined at creation)         | Dynamic size (grows automatically)       |
| Generic Support | Yes (with `T[]`)                         | No (use `List<T>` for generic version)   |
| Performance     | Faster (no boxing/unboxing)              | Slower (uses `object`, requires casting) |
| Usability       | Simple and efficient for fixed data      | Flexible, easier when size is unknown    |
| Indexing        | 0-based                                  | 0-based                                  |

---

## 📌 Syntax Comparison

### ➤ Declaring and Initializing

```csharp
// Array
int[] numbers = new int[3];
numbers[0] = 1;

// ArrayList
ArrayList list = new ArrayList();
list.Add(1); // Stored as object
```

### ➤ Accessing Values

```csharp
int x = numbers[0]; // No cast needed

int y = (int)list[0]; // Must cast from object
```

---

## 🔒 Type Safety

* **Array** is **type-safe**. You declare and use it with a specific type.

  ```csharp
  string[] names = new string[] { "Alice", "Bob" };
  names[1] = "Charlie"; // OK
  names[1] = 42;        // ❌ Compile-time error
  ```

* **ArrayList** stores elements as `object`, so you can accidentally store different types.

  ```csharp
  list.Add("hello");
  list.Add(42); // Allowed, but error-prone
  ```

---

## ⚙️ Performance

### Why `Array` is faster:

* No boxing/unboxing for value types.
* Compile-time type checking.
* Lower memory footprint.

```csharp
ArrayList list = new ArrayList();
list.Add(5);        // Boxing occurs here (int → object)
int x = (int)list[0]; // Unboxing
```

Use **`List<T>`** instead of `ArrayList` to avoid this and maintain performance:

```csharp
List<int> list = new List<int>(); // Generic, no boxing
```

---

## 🔄 Resizing

| Operation   | Array                   | ArrayList        |
| ----------- | ----------------------- | ---------------- |
| Add Element | ❌ Not allowed           | ✅ `Add()` method |
| Resize      | `Array.Resize` (costly) | Automatic        |

```csharp
// Resize Array (expensive)
Array.Resize(ref numbers, 5);

// ArrayList grows automatically
list.Add(10);
```

---

## ✅ When to Use What?

| Use Case                                           | Recommendation       |
| -------------------------------------------------- | -------------------- |
| Known fixed-size collection                        | Use `Array`          |
| Mixed types (but discouraged in modern C#)         | `ArrayList` (legacy) |
| Need type-safety and performance with dynamic size | Use `List<T>`        |
| Interop with legacy .NET 1.0/1.1 code              | `ArrayList`          |

---

## 🧭 Migration Advice

* ⚠️ Avoid `ArrayList` in **modern C# development**.
* Prefer `List<T>` for most dynamic collection needs.
* Use `Array` when working with low-level memory or APIs that require it.

---

## 🔁 Alternatives to ArrayList

| Option                    | Description                       |
| ------------------------- | --------------------------------- |
| `List<T>`                 | Type-safe, generic dynamic list   |
| `LinkedList<T>`           | Doubly-linked list                |
| `ObservableCollection<T>` | Useful for data binding in WPF    |
| `Collection<T>`           | Base class for custom collections |

---

## 📎 Summary Table

| Criteria            | Array      | ArrayList    | List<T> (Recommended) |
| ------------------- | ---------- | ------------ | --------------------- |
| Fixed size          | ✅          | ❌            | ❌                     |
| Type safety         | ✅          | ❌            | ✅                     |
| Performance         | ✅          | ❌ (boxing)   | ✅                     |
| Easy to resize      | ❌          | ✅            | ✅                     |
| Supports generics   | ✅ (T\[])   | ❌            | ✅                     |
| Use in new projects | ⚠️ Limited | ❌ Deprecated | ✅ Yes                 |

---

## ✅ Best Practice

> 🔧 **Use `Array` when performance and type safety are critical, and the size is known. Use `List<T>` in all other scenarios.
Avoid `ArrayList` unless working with legacy code.**

