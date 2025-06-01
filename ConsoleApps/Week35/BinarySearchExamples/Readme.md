# C# Binary Search Algorithm - Iterative and Recursive Implementations

Welcome to your comprehensive guide to Binary Search Algorithms in C#. This guide covers both iterative and recursive implementations, with detailed explanations and examples.

---

## What is Binary Search?

Binary Search is an efficient algorithm for finding an element in a sorted array. It works by repeatedly dividing the search interval in half, making it much faster than linear search for large datasets.

> Time Complexity: O(log n)
> Space Complexity: O(1) for iterative, O(log n) for recursive

---

## Prerequisites

* Sorted array
* Elements must be comparable
* Random access to elements

---

## 1. Iterative Binary Search

### Implementation

```csharp
public static int BinarySearchIterative(int[] array, int target)
{
    int left = 0;
    int right = array.Length - 1;

    while (left <= right)
    {
        int mid = left + (right - left) / 2;

        // Check if target is present at mid
        if (array[mid] == target)
            return mid;

        // If target is greater, ignore left half
        if (array[mid] < target)
            left = mid + 1;
        // If target is smaller, ignore right half
        else
            right = mid - 1;
    }

    // Target not found
    return -1;
}
```

### Usage Example

```csharp
int[] numbers = { 1, 3, 5, 7, 9, 11, 13, 15 };
int target = 7;
int index = BinarySearchIterative(numbers, target);

if (index != -1)
    Console.WriteLine($"Element found at index: {index}");
else
    Console.WriteLine("Element not found");
```

### Advantages of Iterative Approach

* No stack overflow risk
* Lower memory usage
* Better performance for very large arrays
* Easier to optimize

---

## 2. Recursive Binary Search

### Implementation

```csharp
public static int BinarySearchRecursive(int[] array, int target, int left, int right)
{
    if (left <= right)
    {
        int mid = left + (right - left) / 2;

        // If element is present at middle
        if (array[mid] == target)
            return mid;

        // If element is smaller than mid, search left subarray
        if (array[mid] > target)
            return BinarySearchRecursive(array, target, left, mid - 1);

        // Else search right subarray
        return BinarySearchRecursive(array, target, mid + 1, right);
    }

    // Element not present
    return -1;
}

// Helper method for easier calling
public static int BinarySearchRecursive(int[] array, int target)
{
    return BinarySearchRecursive(array, target, 0, array.Length - 1);
}
```

### Usage Example

```csharp
int[] numbers = { 1, 3, 5, 7, 9, 11, 13, 15 };
int target = 7;
int index = BinarySearchRecursive(numbers, target);

if (index != -1)
    Console.WriteLine($"Element found at index: {index}");
else
    Console.WriteLine("Element not found");
```

### Advantages of Recursive Approach

* More elegant and readable code
* Easier to understand the algorithm
* Better for small to medium-sized arrays
* Natural expression of the divide-and-conquer strategy

---

## 3. Generic Binary Search

### Implementation

```csharp
public static int BinarySearchGeneric<T>(T[] array, T target) where T : IComparable<T>
{
    int left = 0;
    int right = array.Length - 1;

    while (left <= right)
    {
        int mid = left + (right - left) / 2;
        int comparison = target.CompareTo(array[mid]);

        if (comparison == 0)
            return mid;
        if (comparison > 0)
            left = mid + 1;
        else
            right = mid - 1;
    }

    return -1;
}
```

### Usage Example

```csharp
string[] names = { "Alice", "Bob", "Charlie", "David", "Eve" };
string target = "Charlie";
int index = BinarySearchGeneric(names, target);
```

---

## 4. Common Variations

### 1. Finding First Occurrence

```csharp
public static int FindFirstOccurrence(int[] array, int target)
{
    int left = 0;
    int right = array.Length - 1;
    int result = -1;

    while (left <= right)
    {
        int mid = left + (right - left) / 2;

        if (array[mid] == target)
        {
            result = mid;
            right = mid - 1; // Continue searching left
        }
        else if (array[mid] < target)
            left = mid + 1;
        else
            right = mid - 1;
    }

    return result;
}
```

### 2. Finding Last Occurrence

```csharp
public static int FindLastOccurrence(int[] array, int target)
{
    int left = 0;
    int right = array.Length - 1;
    int result = -1;

    while (left <= right)
    {
        int mid = left + (right - left) / 2;

        if (array[mid] == target)
        {
            result = mid;
            left = mid + 1; // Continue searching right
        }
        else if (array[mid] < target)
            left = mid + 1;
        else
            right = mid - 1;
    }

    return result;
}
```

### 3. Finding Closest Element

```csharp
public static int FindClosestElement(int[] array, int target)
{
    int left = 0;
    int right = array.Length - 1;

    while (left <= right)
    {
        int mid = left + (right - left) / 2;

        if (array[mid] == target)
            return mid;

        if (array[mid] < target)
            left = mid + 1;
        else
            right = mid - 1;
    }

    // Find closest element
    if (right < 0) return 0;
    if (left >= array.Length) return array.Length - 1;

    return Math.Abs(array[left] - target) < Math.Abs(array[right] - target) 
        ? left : right;
}
```

---

## 5. Best Practices

1. **Always Check Array Length**
   ```csharp
   if (array == null || array.Length == 0)
       return -1;
   ```

2. **Handle Edge Cases**
   ```csharp
   if (target < array[0] || target > array[array.Length - 1])
       return -1;
   ```

3. **Prevent Integer Overflow**
   ```csharp
   // Instead of (left + right) / 2
   int mid = left + (right - left) / 2;
   ```

4. **Use Appropriate Types**
   ```csharp
   // For custom objects
   public class Person : IComparable<Person>
   {
       public string Name { get; set; }
       public int CompareTo(Person other) => Name.CompareTo(other.Name);
   }
   ```

---

## 6. Performance Considerations

| Operation | Time Complexity | Space Complexity | Notes |
|-----------|----------------|------------------|-------|
| Search    | O(log n)       | O(1)            | Iterative |
| Search    | O(log n)       | O(log n)        | Recursive |
| Insert    | O(n)           | O(1)            | Requires shifting |
| Delete    | O(n)           | O(1)            | Requires shifting |

### When to Use Each Approach

1. **Use Iterative When:**
   * Working with very large arrays
   * Memory is a concern
   * Stack overflow is a risk
   * Performance is critical

2. **Use Recursive When:**
   * Code readability is important
   * Working with smaller arrays
   * Implementing complex variations
   * Teaching/learning the algorithm

---

## 7. Common Pitfalls

1. **Integer Overflow**
   ```csharp
   // Wrong
   int mid = (left + right) / 2;

   // Correct
   int mid = left + (right - left) / 2;
   ```

2. **Off-by-One Errors**
   ```csharp
   // Wrong
   while (left < right)

   // Correct
   while (left <= right)
   ```

3. **Unsorted Arrays**
   ```csharp
   // Always ensure array is sorted
   Array.Sort(array);
   ```

---

## 8. Interview Questions

1. How does binary search work?
2. What's the difference between iterative and recursive binary search?
3. When would you use binary search over linear search?
4. How do you handle duplicate values in binary search?
5. What are the limitations of binary search?

---

## 9. Additional Resources

* [Binary Search Algorithm](https://en.wikipedia.org/wiki/Binary_search_algorithm)
* [C# Array Class](https://docs.microsoft.com/en-us/dotnet/api/system.array)
* [C# Collections](https://docs.microsoft.com/en-us/dotnet/standard/collections/)