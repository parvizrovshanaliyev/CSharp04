# Introduction to Collections in C#

## Overview

This module introduces the fundamental concepts of collections in C#, providing a comprehensive guide to understanding and implementing various collection types available in the .NET Framework.

## Collection Types

### 1. System.Collections.Generic

#### List<T>
- Dynamic array implementation
- Type-safe at compile time
- Fast access by index
- Efficient for add/remove at end
- Example:
```csharp
List<string> names = new List<string>();
names.Add("John");
names.Add("Jane");
```

#### Dictionary<TKey, TValue>
- Key-value pair collection
- Fast lookups by key
- No duplicate keys allowed
- Example:
```csharp
Dictionary<int, string> employees = new Dictionary<int, string>();
employees.Add(1, "John Smith");
employees.Add(2, "Jane Doe");
```

#### HashSet<T>
- Unique elements only
- Fast lookups and comparisons
- Set operations (Union, Intersect)
- Example:
```csharp
HashSet<int> numbers = new HashSet<int>();
numbers.Add(1);
numbers.Add(2);
```

#### Queue<T>
- FIFO (First-In-First-Out)
- Enqueue/Dequeue operations
- Example:
```csharp
Queue<string> printQueue = new Queue<string>();
printQueue.Enqueue("Document1.pdf");
printQueue.Enqueue("Document2.pdf");
```

#### Stack<T>
- LIFO (Last-In-First-Out)
- Push/Pop operations
- Example:
```csharp
Stack<int> numbers = new Stack<int>();
numbers.Push(1);
numbers.Push(2);
```

### 2. System.Collections

#### ArrayList
- Non-generic collection
- Stores objects of any type
- Boxing/Unboxing overhead
- Example:
```csharp
ArrayList list = new ArrayList();
list.Add("String");
list.Add(123);
```

#### Hashtable
- Non-generic key-value pairs
- Stores objects of any type
- Example:
```csharp
Hashtable table = new Hashtable();
table.Add("key1", "value1");
table.Add(1, "value2");
```

## Common Operations

### Adding Elements
```csharp
List<int> numbers = new List<int>();
numbers.Add(1);           // Single element
numbers.AddRange(new[] { 2, 3, 4 }); // Multiple elements
```

### Removing Elements
```csharp
numbers.Remove(1);        // Remove specific element
numbers.RemoveAt(0);      // Remove at index
numbers.Clear();          // Remove all elements
```

### Searching Elements
```csharp
bool exists = numbers.Contains(1);    // Check existence
int index = numbers.IndexOf(1);       // Find index
var found = numbers.Find(x => x > 2); // Find with predicate
```

### Sorting
```csharp
numbers.Sort();                       // Default sort
numbers.Sort((a, b) => b.CompareTo(a)); // Custom sort
```

## Best Practices

1. **Choose the Right Collection**
   - Use List<T> for ordered, indexed collections
   - Use Dictionary<TKey,TValue> for key-value pairs
   - Use HashSet<T> for unique elements
   - Use Queue<T> for FIFO operations
   - Use Stack<T> for LIFO operations

2. **Performance Considerations**
   - Initialize with capacity when size is known
   - Use generic collections over non-generic
   - Consider memory usage for large collections
   - Use appropriate collection for operation patterns

3. **Type Safety**
   - Prefer generic collections
   - Avoid mixing types in non-generic collections
   - Use strong typing where possible

4. **Memory Management**
   - Clear collections when no longer needed
   - Dispose of elements if they implement IDisposable
   - Be mindful of collection size in memory

## Common Interfaces

### IEnumerable<T>
- Enables foreach iteration
- LINQ support
- Basic collection interface

### ICollection<T>
- Adds size and modification capabilities
- Count property
- Add/Remove methods

### IList<T>
- Adds index-based access
- Insert/RemoveAt methods
- Index property

### IDictionary<TKey,TValue>
- Key-value pair operations
- Key/Value collections
- Add/Remove by key

## Advanced Topics

### Thread Safety
- Use concurrent collections for multi-threading
- ConcurrentDictionary<TKey,TValue>
- ConcurrentQueue<T>
- ConcurrentBag<T>

### Custom Collections
- Implement IEnumerable<T>
- Override collection behavior
- Custom sorting and comparison

### LINQ Integration
```csharp
var query = numbers
    .Where(n => n > 2)
    .OrderBy(n => n)
    .Select(n => n * 2);
```

## Examples

### Basic List Operations
```csharp
List<string> fruits = new List<string>();
fruits.Add("Apple");
fruits.Add("Banana");
fruits.Add("Orange");

foreach (string fruit in fruits)
{
    Console.WriteLine(fruit);
}
```

### Dictionary Usage
```csharp
Dictionary<string, int> ages = new Dictionary<string, int>();
ages["John"] = 25;
ages["Jane"] = 30;

foreach (KeyValuePair<string, int> entry in ages)
{
    Console.WriteLine($"{entry.Key} is {entry.Value} years old");
}
```

### HashSet Operations
```csharp
HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
HashSet<int> set2 = new HashSet<int> { 2, 3, 4 };

set1.UnionWith(set2);     // Union
set1.IntersectWith(set2); // Intersection
set1.ExceptWith(set2);    // Difference
```

## Resources

- [Microsoft Docs - Collections](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections)
- [C# Collection Types](https://docs.microsoft.com/en-us/dotnet/standard/collections/)
- [Collection Interfaces](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic)

## Notes

- Collections are fundamental to most C# applications
- Choose collections based on specific needs
- Consider performance implications
- Use generic collections when possible
- Implement proper error handling
- Consider thread safety requirements
- Keep collections manageable in size