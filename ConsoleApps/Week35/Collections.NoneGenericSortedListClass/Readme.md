# Non-Generic SortedList in C# – A Complete Guide

Welcome to your comprehensive guide to mastering the non-generic **SortedList** data structure in **C#**. This guide covers everything from basic concepts to advanced implementations, with a focus on practical applications.

---

## What Is a Non-Generic SortedList?

A non-generic **SortedList** is a collection of key-value pairs that are sorted by the keys. It combines the features of a hash table and an array, providing both fast lookups and sorted access.

> The elements are automatically sorted by their keys, and both keys and values are stored as `object` type.

---

## Real-World Applications

* **Configuration Management**
* **Sorted Dictionaries**
* **Priority Queues**
* **Sorted Data Storage**
* **Caching Systems**

---

## SortedList Implementation Details

| Component   | Description                                    |
|------------|------------------------------------------------|
| Namespace  | `System.Collections`                           |
| Base Type  | `object` (both keys and values)                |
| Interface  | `IDictionary`, `ICollection`, `IEnumerable`    |

---

## Core SortedList Operations

| Method           | Description                                      | Example                                    |
|-----------------|--------------------------------------------------|--------------------------------------------|
| `Add()`         | Adds a key-value pair to the list               | `sortedList.Add("key", "value")`          |
| `Remove()`      | Removes a key-value pair by key                 | `sortedList.Remove("key")`                |
| `ContainsKey()` | Checks if a key exists                          | `bool exists = sortedList.ContainsKey("key")` |
| `ContainsValue()`| Checks if a value exists                        | `bool exists = sortedList.ContainsValue("value")` |
| `Count`         | Gets the number of elements                     | `int count = sortedList.Count`            |
| `Clear()`       | Removes all elements                            | `sortedList.Clear()`                      |
| `GetByIndex()`  | Gets value by index                             | `object value = sortedList.GetByIndex(0)` |
| `GetKey()`      | Gets key by index                               | `object key = sortedList.GetKey(0)`       |

---

## Basic Example

```csharp
using System.Collections;

SortedList config = new SortedList();
config.Add("Server", "localhost");
config.Add("Port", 8080);
config.Add("Timeout", 30);

// Access by key
Console.WriteLine(config["Server"]);    // Output: localhost

// Access by index
Console.WriteLine(config.GetByIndex(0)); // Output: localhost
Console.WriteLine(config.GetKey(0));     // Output: Port
```

---

## Iterating Through a SortedList

```csharp
// By key-value pairs
foreach (DictionaryEntry entry in config)
{
    Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
}

// By index
for (int i = 0; i < config.Count; i++)
{
    Console.WriteLine($"Key: {config.GetKey(i)}, Value: {config.GetByIndex(i)}");
}
```

> Note: Non-generic SortedList stores items as `object`, so type casting may be needed.

---

## Practical Example: Configuration Manager

Here's a simplified version of a configuration manager using non-generic SortedList:

```csharp
public class ConfigManager
{
    private SortedList _config;

    public ConfigManager()
    {
        _config = new SortedList();
    }

    public void AddSetting(string key, object value)
    {
        if (!_config.ContainsKey(key))
        {
            _config.Add(key, value);
        }
    }

    public object GetSetting(string key)
    {
        return _config.ContainsKey(key) ? _config[key] : null;
    }

    public void DisplaySettings()
    {
        foreach (DictionaryEntry entry in _config)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }
}
```

---

## Common Pitfalls and Solutions

1. **Type Casting Issues**
   ```csharp
   // Problematic
   int port = config["Port"]; // Compilation error

   // Solution
   int port = (int)config["Port"]; // Explicit casting
   ```

2. **Duplicate Keys**
   ```csharp
   // Problematic
   config.Add("key", "value1");
   config.Add("key", "value2"); // Throws ArgumentException

   // Solution
   if (!config.ContainsKey("key"))
   {
       config.Add("key", "value2");
   }
   ```

3. **Null Keys**
   ```csharp
   // Problematic
   config.Add(null, "value"); // Throws ArgumentNullException

   // Solution
   if (key != null)
   {
       config.Add(key, "value");
   }
   ```

---

## Performance Considerations

| Operation  | Time Complexity | Space Complexity | Notes                                    |
|------------|----------------|------------------|------------------------------------------|
| Add        | O(n)          | O(1)            | Linear time due to sorting               |
| Remove     | O(n)          | O(1)            | Linear time due to shifting              |
| Lookup     | O(log n)      | O(1)            | Binary search for sorted keys            |
| Index Access| O(1)         | O(1)            | Direct array access                      |

### Performance Tips:
* Consider using `SortedList<TKey, TValue>` for better type safety
* Avoid frequent additions/removals in large lists
* Use `ContainsKey` before adding
* Consider capacity if size is known

---

## Best Practices

1. **Error Handling**
   ```csharp
   try
   {
       config.Add(key, value);
   }
   catch (ArgumentException)
   {
       Console.WriteLine("Key already exists");
   }
   catch (ArgumentNullException)
   {
       Console.WriteLine("Key cannot be null");
   }
   ```

2. **Type Safety**
   ```csharp
   public class TypedConfigManager
   {
       private SortedList _config = new SortedList();

       public void AddSetting<T>(string key, T value)
       {
           _config.Add(key, value);
       }

       public T GetSetting<T>(string key)
       {
           return (T)_config[key];
       }
   }
   ```

3. **Thread Safety**
   ```csharp
   private readonly object _lockObject = new object();

   public void AddSetting(string key, object value)
   {
       lock (_lockObject)
       {
           _config.Add(key, value);
       }
   }
   ```

---

## Summary

| Key Points to Remember                    |
| -------------------------------------------- |
| SortedList maintains sorted order by keys  |
| Both keys and values are stored as `object` |
| Keys must be unique and non-null           |
| Values can be null                         |
| Consider thread safety for concurrent access|

---

## Interview Questions

1. How does SortedList maintain its sorted order?
2. What's the difference between SortedList and Dictionary?
3. When would you choose SortedList over other collections?
4. How do you handle type casting in a non-generic SortedList?

---

## Practice Projects

1. **Configuration Manager** (as shown above)
2. **Priority Task Scheduler**
3. **Sorted Settings Store**
4. **Caching System**

---

## Additional Resources

* [Microsoft Docs: SortedList](https://docs.microsoft.com/en-us/dotnet/api/system.collections.sortedlist)
* [C# Collections Overview](https://docs.microsoft.com/en-us/dotnet/standard/collections/)
* [Thread-Safe Collections](https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/)
* [C# Best Practices](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/)

## Array.BinarySearch in C#

Binary search is an efficient algorithm for finding an element in a sorted array. C# provides the `Array.BinarySearch` method for this purpose.

### Basic Usage

```csharp
// Simple array of integers
int[] numbers = { 1, 3, 5, 7, 9, 11, 13, 15 };
int index = Array.BinarySearch(numbers, 7);
// Returns 3 (the index of 7)

// String array
string[] names = { "Alice", "Bob", "Charlie", "David", "Eve" };
int nameIndex = Array.BinarySearch(names, "Charlie");
// Returns 2 (the index of "Charlie")
```

### Return Values

```csharp
int[] array = { 1, 3, 5, 7, 9 };

// Found case
int found = Array.BinarySearch(array, 5);    // Returns 2 (index of 5)

// Not found case
int notFound = Array.BinarySearch(array, 4); // Returns -3 (bitwise complement of insertion point)
// To get insertion point: ~notFound = 2
```

### Custom Objects

```csharp
public class Person : IComparable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }

    public int CompareTo(Person other)
    {
        return Age.CompareTo(other.Age);
    }
}

// Usage
Person[] people = new Person[]
{
    new Person { Name = "Alice", Age = 20 },
    new Person { Name = "Bob", Age = 25 },
    new Person { Name = "Charlie", Age = 30 }
};

int index = Array.BinarySearch(people, new Person { Age = 25 });
// Returns 1 (index of Bob)
```

### Performance Characteristics

| Operation | Time Complexity | Space Complexity | Notes |
|-----------|----------------|------------------|-------|
| Search    | O(log n)       | O(1)            | Much faster than linear search for large arrays |

### Best Practices

1. **Always Use Sorted Arrays**
   ```csharp
   // Correct: Array is sorted
   int[] sorted = { 1, 2, 3, 4, 5 };
   int index = Array.BinarySearch(sorted, 3); // Works correctly

   // Incorrect: Array is not sorted
   int[] unsorted = { 5, 2, 1, 4, 3 };
   int wrongIndex = Array.BinarySearch(unsorted, 3); // May give incorrect results
   ```

2. **Handle Not Found Cases**
   ```csharp
   int[] array = { 1, 3, 5, 7, 9 };
   int searchValue = 4;
   int index = Array.BinarySearch(array, searchValue);

   if (index >= 0)
   {
       Console.WriteLine($"Found at index: {index}");
   }
   else
   {
       int insertionPoint = ~index;
       Console.WriteLine($"Not found. Should be inserted at index: {insertionPoint}");
   }
   ```

3. **Use Appropriate Types**
   ```csharp
   // Good: Using IComparable types
   string[] strings = { "a", "b", "c" };
   int index = Array.BinarySearch(strings, "b");

   // Bad: Using non-comparable types
   object[] objects = { new object(), new object() };
   // This will throw an exception
   // int index = Array.BinarySearch(objects, new object());
   ```

### Common Pitfalls

1. **Unsorted Arrays**
   ```csharp
   // Problematic
   int[] unsorted = { 5, 2, 1, 4, 3 };
   int index = Array.BinarySearch(unsorted, 3);
   // Result may be incorrect
   ```

2. **Null Values**
   ```csharp
   // Problematic
   string[] array = { "a", null, "c" };
   int index = Array.BinarySearch(array, "b");
   // May throw NullReferenceException
   ```

3. **Type Mismatches**
   ```csharp
   // Problematic
   object[] array = { 1, "2", 3 };
   int index = Array.BinarySearch(array, 2);
   // May throw InvalidOperationException
   ```

### Performance Tips

1. **Pre-sort Arrays**
   ```csharp
   // Good practice
   int[] array = { 5, 2, 1, 4, 3 };
   Array.Sort(array); // Sort first
   int index = Array.BinarySearch(array, 3);
   ```

2. **Use Appropriate Array Size**
   ```csharp
   // For small arrays, linear search might be better
   int[] smallArray = { 1, 2, 3 };
   // Linear search might be more efficient
   ```

3. **Consider Memory Usage**
   ```csharp
   // For very large arrays, consider using a more memory-efficient structure
   // or splitting the search into chunks
   ```

### Real-World Examples

1. **Finding a Range**
   ```csharp
   public static (int start, int end) FindRange(int[] array, int value)
   {
       int index = Array.BinarySearch(array, value);
       if (index < 0) return (-1, -1);

       int start = index;
       while (start > 0 && array[start - 1] == value)
           start--;

       int end = index;
       while (end < array.Length - 1 && array[end + 1] == value)
           end++;

       return (start, end);
   }
   ```

2. **Finding Closest Value**
   ```csharp
   public static int FindClosest(int[] array, int value)
   {
       int index = Array.BinarySearch(array, value);
       if (index >= 0) return array[index];

       int insertionPoint = ~index;
       if (insertionPoint == 0) return array[0];
       if (insertionPoint == array.Length) return array[array.Length - 1];

       int before = array[insertionPoint - 1];
       int after = array[insertionPoint];
       return Math.Abs(value - before) <= Math.Abs(value - after) ? before : after;
   }
   ```

### Interview Questions

1. How does binary search work?
2. What's the time complexity of binary search?
3. When would you use binary search over linear search?
4. How do you handle duplicate values in binary search?
5. What are the limitations of Array.BinarySearch?

### Additional Resources

* [Microsoft Docs: Array.BinarySearch](https://docs.microsoft.com/en-us/dotnet/api/system.array.binarysearch)
* [Binary Search Algorithm](https://en.wikipedia.org/wiki/Binary_search_algorithm)
* [C# Array Class](https://docs.microsoft.com/en-us/dotnet/api/system.array)