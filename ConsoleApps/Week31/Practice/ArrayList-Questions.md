# 📝 ArrayList in C# - Practice Questions and Solutions

## 🔍 Basic Concepts

1. **What is ArrayList?**
   - What are the key characteristics of ArrayList?
     ```csharp
     // ArrayList is a non-generic collection that can store elements of any type
     ArrayList list = new ArrayList();
     list.Add(1);        // Integer
     list.Add("Hello");  // String
     list.Add(3.14);     // Double
     list.Add(true);     // Boolean
     ```
   - How does ArrayList differ from arrays?
     ```csharp
     // Array - fixed size, same type
     int[] numbers = new int[5];
     
     // ArrayList - dynamic size, any type
     ArrayList dynamicList = new ArrayList();
     dynamicList.Add(1);
     dynamicList.Add("Two");
     ```
   - What are the advantages and disadvantages of using ArrayList?
     ```csharp
     // Advantages
     ArrayList flexibleList = new ArrayList();
     flexibleList.Add(1);
     flexibleList.Add("Two");
     flexibleList.Add(new Student());
     
     // Disadvantages
     // Need type casting
     int number = (int)flexibleList[0];
     string text = (string)flexibleList[1];
     Student student = (Student)flexibleList[2];
     ```

2. **ArrayList vs Generic Collections**
   - Why is ArrayList considered less type-safe compared to generic collections?
     ```csharp
     // ArrayList - no type safety
     ArrayList unsafeList = new ArrayList();
     unsafeList.Add(1);
     unsafeList.Add("Two"); // No compile-time error
     
     // List<T> - type safe
     List<int> safeList = new List<int>();
     safeList.Add(1);
     // safeList.Add("Two"); // Compile-time error
     ```
   - When would you choose ArrayList over List<T>?
     ```csharp
     // Use ArrayList when:
     // 1. Working with legacy code
     // 2. Need to store mixed types
     // 3. Working with non-generic APIs
     ArrayList mixedList = new ArrayList();
     mixedList.Add(1);
     mixedList.Add("Text");
     mixedList.Add(new DateTime());
     ```
   - What are the performance implications of using ArrayList?
     ```csharp
     // ArrayList requires boxing/unboxing for value types
     ArrayList numbers = new ArrayList();
     numbers.Add(1);    // Boxing
     int num = (int)numbers[0]; // Unboxing
     
     // List<T> avoids boxing/unboxing
     List<int> genericNumbers = new List<int>();
     genericNumbers.Add(1);    // No boxing
     int num2 = genericNumbers[0]; // No unboxing
     ```

## 💻 Implementation Questions

3. **ArrayList Operations**
   ```csharp
   ArrayList list = new ArrayList();
   ```
   - How do you add elements to an ArrayList?
     ```csharp
     // Adding elements
     list.Add(1);
     list.AddRange(new[] { 2, 3, 4 });
     list.Insert(0, 0);
     ```
   - How do you remove elements from an ArrayList?
     ```csharp
     // Removing elements
     list.Remove(1);
     list.RemoveAt(0);
     list.RemoveRange(0, 2);
     list.Clear();
     ```
   - How do you check if an element exists in an ArrayList?
     ```csharp
     // Checking elements
     bool exists = list.Contains(1);
     int index = list.IndexOf(1);
     int lastIndex = list.LastIndexOf(1);
     ```
   - How do you get the number of elements in an ArrayList?
     ```csharp
     int count = list.Count;
     int capacity = list.Capacity;
     ```

4. **Type Handling**
   ```csharp
   ArrayList mixedList = new ArrayList();
   mixedList.Add(1);
   mixedList.Add("Hello");
   mixedList.Add(new Student());
   ```
   - How does ArrayList handle different data types?
     ```csharp
     // Safe type checking
     foreach (object item in mixedList)
     {
         if (item is int number)
         {
             Console.WriteLine($"Number: {number}");
         }
         else if (item is string text)
         {
             Console.WriteLine($"Text: {text}");
         }
         else if (item is Student student)
         {
             Console.WriteLine($"Student: {student.Name}");
         }
     }
     ```
   - What are the potential issues with storing different types in ArrayList?
     ```csharp
     // Potential issues
     try
     {
         int number = (int)mixedList[1]; // InvalidCastException
     }
     catch (InvalidCastException ex)
     {
         Console.WriteLine("Type casting failed");
     }
     ```
   - How do you safely retrieve and use elements of specific types?
     ```csharp
     // Safe retrieval
     public T GetItem<T>(ArrayList list, int index)
     {
         if (list[index] is T item)
         {
             return item;
         }
         throw new InvalidCastException($"Cannot cast to {typeof(T)}");
     }
     ```

## 🎯 Practical Exercises

5. **Basic Operations**
   ```csharp
   // Create an ArrayList of integers
   ArrayList numbers = new ArrayList();
   ```
   - Write code to add numbers 1 to 10 to the ArrayList
     ```csharp
     // Solution
     for (int i = 1; i <= 10; i++)
     {
         numbers.Add(i);
     }
     ```
   - Write code to remove all even numbers
     ```csharp
     // Solution
     for (int i = numbers.Count - 1; i >= 0; i--)
     {
         if (numbers[i] is int num && num % 2 == 0)
         {
             numbers.RemoveAt(i);
         }
     }
     ```
   - Write code to find the sum of all numbers
     ```csharp
     // Solution
     int sum = 0;
     foreach (object item in numbers)
     {
         if (item is int num)
         {
             sum += num;
         }
     }
     ```
   - Write code to find the average of all numbers
     ```csharp
     // Solution
     double average = 0;
     if (numbers.Count > 0)
     {
         int sum = 0;
         foreach (object item in numbers)
         {
             if (item is int num)
             {
                 sum += num;
             }
         }
         average = (double)sum / numbers.Count;
     }
     ```

6. **Type Casting**
   ```csharp
   ArrayList students = new ArrayList();
   students.Add(new Student("John", 85));
   students.Add(new Student("Alice", 92));
   ```
   - Write code to safely cast and access Student objects
     ```csharp
     // Solution
     public Student GetStudent(ArrayList students, string name)
     {
         foreach (object item in students)
         {
             if (item is Student student && student.Name == name)
             {
                 return student;
             }
         }
         return null;
     }
     ```
   - Implement a method to find a student by name
     ```csharp
     // Solution
     public Student FindStudentByName(ArrayList students, string name)
     {
         return students.Cast<Student>()
                        .FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
     }
     ```
   - Implement a method to calculate the average grade
     ```csharp
     // Solution
     public double CalculateAverageGrade(ArrayList students)
     {
         if (students.Count == 0) return 0;
         
         return students.Cast<Student>()
                        .Average(s => s.Grade);
     }
     ```

7. **Sorting and Searching**
   ```csharp
   ArrayList grades = new ArrayList();
   grades.Add(85);
   grades.Add(92);
   grades.Add(78);
   ```
   - How do you sort an ArrayList?
     ```csharp
     // Solution
     grades.Sort(); // For simple types
     
     // Custom sorting for complex types
     grades.Sort(new StudentComparer());
     ```
   - How do you search for a specific value?
     ```csharp
     // Solution
     int index = grades.BinarySearch(85);
     if (index >= 0)
     {
         Console.WriteLine($"Found at index: {index}");
     }
     ```
   - How do you implement custom sorting?
     ```csharp
     // Solution
     public class StudentComparer : IComparer
     {
         public int Compare(object x, object y)
         {
             if (x is Student s1 && y is Student s2)
             {
                 return s1.Grade.CompareTo(s2.Grade);
             }
             return 0;
         }
     }
     ```

## 🔄 Advanced Concepts

8. **Performance Considerations**
   - What is the time complexity of common ArrayList operations?
     ```csharp
     // O(1) operations
     list.Add(item);        // Amortized
     list[index];          // Direct access
     list.Count;           // Property access
     
     // O(n) operations
     list.Insert(0, item); // Shifting elements
     list.Remove(item);    // Searching and shifting
     list.Contains(item);  // Linear search
     ```
   - How does ArrayList handle memory allocation?
     ```csharp
     // ArrayList grows by doubling capacity
     ArrayList list = new ArrayList();
     Console.WriteLine(list.Capacity); // Initial capacity
     
     for (int i = 0; i < 100; i++)
     {
         list.Add(i);
         if (list.Count == list.Capacity)
         {
             Console.WriteLine($"New capacity: {list.Capacity}");
         }
     }
     ```
   - When should you consider using a different collection type?
     ```csharp
     // Use List<T> when:
     // 1. Working with same type
     List<int> numbers = new List<int>();
     
     // Use Dictionary<TKey, TValue> when:
     // 2. Need key-value pairs
     Dictionary<string, int> grades = new Dictionary<string, int>();
     
     // Use HashSet<T> when:
     // 3. Need unique values
     HashSet<int> uniqueNumbers = new HashSet<int>();
     ```

9. **Thread Safety**
   - Is ArrayList thread-safe?
     ```csharp
     // ArrayList is not thread-safe
     ArrayList list = new ArrayList();
     
     // Thread 1
     Task.Run(() => list.Add(1));
     
     // Thread 2
     Task.Run(() => list.Add(2)); // Potential race condition
     ```
   - How can you make ArrayList operations thread-safe?
     ```csharp
     // Solution 1: Using lock
     private readonly object _lock = new object();
     
     public void AddItem(object item)
     {
         lock (_lock)
         {
             list.Add(item);
         }
     }
     
     // Solution 2: Using Synchronized
     ArrayList syncList = ArrayList.Synchronized(new ArrayList());
     ```
   - What are the alternatives for thread-safe collections?
     ```csharp
     // Concurrent collections
     ConcurrentBag<int> bag = new ConcurrentBag<int>();
     ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
     ConcurrentStack<int> stack = new ConcurrentStack<int>();
     ```

## 📊 Real-World Scenarios

10. **Data Processing**
    ```csharp
    ArrayList data = new ArrayList();
    // Assume data contains mixed types
    ```
    - How would you process mixed-type data safely?
      ```csharp
      // Solution
      public void ProcessMixedData(ArrayList data)
      {
          foreach (object item in data)
          {
              switch (item)
              {
                  case int number:
                      ProcessNumber(number);
                      break;
                  case string text:
                      ProcessText(text);
                      break;
                  case Student student:
                      ProcessStudent(student);
                      break;
                  default:
                      Console.WriteLine("Unknown type");
                      break;
              }
          }
      }
      ```
    - How would you convert ArrayList to a strongly-typed collection?
      ```csharp
      // Solution
      public List<T> ConvertToTypedList<T>(ArrayList list)
      {
          return list.Cast<T>().ToList();
      }
      
      // Usage
      List<int> numbers = ConvertToTypedList<int>(data);
      ```
    - How would you handle null values?
      ```csharp
      // Solution
      public void ProcessWithNullCheck(ArrayList data)
      {
          foreach (object item in data)
          {
              if (item == null)
              {
                  Console.WriteLine("Null value found");
                  continue;
              }
              
              // Process non-null items
          }
      }
      ```

## 🧪 Testing and Debugging

11. **Error Handling**
    ```csharp
    ArrayList list = new ArrayList();
    // Assume list contains mixed types
    ```
    - How do you handle type casting exceptions?
      ```csharp
      // Solution
      public T SafeGetItem<T>(ArrayList list, int index)
      {
          try
          {
              if (list[index] is T item)
              {
                  return item;
              }
              throw new InvalidCastException($"Cannot cast to {typeof(T)}");
          }
          catch (ArgumentOutOfRangeException)
          {
              throw new IndexOutOfRangeException($"Index {index} is out of range");
          }
          catch (InvalidCastException ex)
          {
              throw new InvalidCastException($"Type casting failed: {ex.Message}");
          }
      }
      ```
    - How do you validate ArrayList contents?
      ```csharp
      // Solution
      public bool ValidateArrayList(ArrayList list)
      {
          if (list == null)
              return false;
              
          if (list.Count == 0)
              return false;
              
          foreach (object item in list)
          {
              if (item == null)
                  return false;
          }
          
          return true;
      }
      ```
    - How do you debug ArrayList-related issues?
      ```csharp
      // Solution
      public void DebugArrayList(ArrayList list)
      {
          Console.WriteLine($"Count: {list.Count}");
          Console.WriteLine($"Capacity: {list.Capacity}");
          
          for (int i = 0; i < list.Count; i++)
          {
              Console.WriteLine($"Item {i}: {list[i]} ({list[i]?.GetType()})");
          }
      }
      ```

## 📚 Best Practices

12. **Code Quality**
    - What are the best practices for using ArrayList?
      ```csharp
      // 1. Use type checking
      if (item is int number)
      {
          // Process number
      }
      
      // 2. Use proper initialization
      ArrayList list = new ArrayList(100); // Specify initial capacity
      
      // 3. Use proper disposal
      using (var list = new ArrayList())
      {
          // Use list
      }
      ```
    - How do you make ArrayList code more maintainable?
      ```csharp
      // 1. Use meaningful variable names
      ArrayList studentGrades = new ArrayList();
      
      // 2. Add proper documentation
      /// <summary>
      /// Processes the student grades in the ArrayList
      /// </summary>
      public void ProcessGrades(ArrayList grades)
      {
          // Implementation
      }
      
      // 3. Use constants for magic numbers
      private const int InitialCapacity = 100;
      ArrayList list = new ArrayList(InitialCapacity);
      ```
    - When should you refactor ArrayList code to use generic collections?
      ```csharp
      // When you need type safety
      // Before
      ArrayList numbers = new ArrayList();
      
      // After
      List<int> numbers = new List<int>();
      
      // When you need specific collection features
      // Before
      ArrayList uniqueNumbers = new ArrayList();
      
      // After
      HashSet<int> uniqueNumbers = new HashSet<int>();
      ```

## 🎓 Learning Exercises

13. **Implementation Tasks**
    - Implement a custom ArrayList wrapper class
      ```csharp
      public class CustomArrayList
      {
          private readonly ArrayList _list;
          
          public CustomArrayList()
          {
              _list = new ArrayList();
          }
          
          public void Add<T>(T item)
          {
              _list.Add(item);
          }
          
          public T Get<T>(int index)
          {
              if (_list[index] is T item)
              {
                  return item;
              }
              throw new InvalidCastException();
          }
          
          public void Remove<T>(T item)
          {
              _list.Remove(item);
          }
          
          public int Count => _list.Count;
      }
      ```
    - Create a thread-safe ArrayList implementation
      ```csharp
      public class ThreadSafeArrayList
      {
          private readonly ArrayList _list;
          private readonly object _lock = new object();
          
          public ThreadSafeArrayList()
          {
              _list = new ArrayList();
          }
          
          public void Add(object item)
          {
              lock (_lock)
              {
                  _list.Add(item);
              }
          }
          
          public object Get(int index)
          {
              lock (_lock)
              {
                  return _list[index];
              }
          }
          
          public void Remove(object item)
          {
              lock (_lock)
              {
                  _list.Remove(item);
              }
          }
      }
      ```
    - Implement a custom sorting algorithm for ArrayList
      ```csharp
      public class CustomSorter
      {
          public static void QuickSort(ArrayList list, int left, int right)
          {
              if (left < right)
              {
                  int pivot = Partition(list, left, right);
                  QuickSort(list, left, pivot - 1);
                  QuickSort(list, pivot + 1, right);
              }
          }
          
          private static int Partition(ArrayList list, int left, int right)
          {
              var pivot = list[right];
              int i = left - 1;
              
              for (int j = left; j < right; j++)
              {
                  if (Comparer.Default.Compare(list[j], pivot) <= 0)
                  {
                      i++;
                      var temp = list[i];
                      list[i] = list[j];
                      list[j] = temp;
                  }
              }
              
              var temp2 = list[i + 1];
              list[i + 1] = list[right];
              list[right] = temp2;
              
              return i + 1;
          }
      }
      ```

## 📚 Resources

- [Microsoft Docs - ArrayList](https://docs.microsoft.com/en-us/dotnet/api/system.collections.arraylist)
- [C# Collections](https://docs.microsoft.com/en-us/dotnet/standard/collections/)
- [Best Practices for Collections](https://docs.microsoft.com/en-us/dotnet/standard/collections/best-practices)
- [Thread Safety in Collections](https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/)
- [Performance Considerations](https://docs.microsoft.com/en-us/dotnet/standard/collections/selecting-a-collection-class)

## 🎓 Learning Path

1. Start with basic ArrayList operations
   - Adding and removing elements
   - Accessing elements
   - Basic iteration

2. Practice type casting and safety
   - Type checking
   - Safe casting
   - Error handling

3. Implement custom solutions
   - Custom wrappers
   - Thread-safe implementations
   - Custom sorting

4. Study performance implications
   - Time complexity
   - Memory usage
   - Optimization techniques

5. Learn best practices
   - Code organization
   - Error handling
   - Documentation

6. Apply knowledge to real-world scenarios
   - Data processing
   - Integration with other collections
   - Problem solving 