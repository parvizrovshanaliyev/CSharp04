# 📚 Hashtable Questions and Exercises

## 📋 Instructions for Students

### How to Use This Document
1. **Read and Understand**
   - Start with the Basic Concepts section
   - Make sure you understand each concept before moving to exercises
   - Take notes on important points

2. **Practice Order**
   - Complete questions in sequence
   - Start with basic operations
   - Move to practical exercises
   - Finally attempt advanced concepts

3. **Code Implementation**
   - Write code for each exercise
   - Test your implementations
   - Compare with example solutions
   - Document your learning

4. **Time Management**
   - Basic Concepts: 30 minutes
   - Practical Exercises: 1 hour
   - Advanced Concepts: 1 hour
   - Real-World Scenarios: 1 hour
   - Testing and Best Practices: 30 minutes

5. **Learning Tips**
   - Use Visual Studio or VS Code
   - Create a new project for exercises
   - Comment your code
   - Test edge cases
   - Review your solutions

6. **Assessment Criteria**
   - Code correctness
   - Implementation efficiency
   - Error handling
   - Code readability
   - Documentation quality

7. **Resources**
   - Keep documentation open
   - Use online resources
   - Review C# documentation
   - Check example solutions

8. **Submission Requirements**
   - Clean, well-commented code
   - Test cases
   - Documentation
   - Learning reflections

### Getting Started
1. Create a new C# console application
2. Add necessary using statements:
   ```csharp
   using System.Collections;
   using System.Collections.Generic;
   ```
3. Create a new class for each exercise
4. Implement and test your solutions

### Important Notes
- All code should be properly documented
- Include error handling
- Test with different data types
- Consider edge cases
- Follow C# coding conventions

## 🔍 Basic Concepts

### Understanding Hashtable
1. What is a Hashtable in C# and how does it differ from other collection types?
2. Explain the key-value pair concept in Hashtable.
3. What are the main advantages of using Hashtable over arrays or lists?
4. How does Hashtable achieve O(1) lookup time?
5. What is the difference between Hashtable and Dictionary<TKey, TValue>?

### Implementation Questions
1. How do you create and initialize a Hashtable in C#?
2. What are the different ways to add items to a Hashtable?
3. How do you retrieve a value from a Hashtable?
4. What happens when you try to add a duplicate key to a Hashtable?
5. How do you check if a key exists in a Hashtable?

## 💻 Practical Exercises

### Basic Operations
1. Create a Hashtable to store student grades where:
   - Key: Student ID (string)
   - Value: Grade (int)
   ```csharp
   // Example solution
   Hashtable grades = new Hashtable();
   grades.Add("S001", 85);
   grades.Add("S002", 92);
   ```

2. Implement a method to find the average grade:
   ```csharp
   public double CalculateAverageGrade(Hashtable grades)
   {
       // Your implementation
   }
   ```

3. Create a method to find the highest grade:
   ```csharp
   public int FindHighestGrade(Hashtable grades)
   {
       // Your implementation
   }
   ```

### Type Handling
1. How do you handle different data types in a Hashtable?
2. What are the implications of storing different types in a Hashtable?
3. How do you safely cast values retrieved from a Hashtable?

### Common Patterns
1. Implement a method to merge two Hashtables:
   ```csharp
   public Hashtable MergeHashtables(Hashtable first, Hashtable second)
   {
       // Your implementation
   }
   ```

2. Create a method to find duplicate values:
   ```csharp
   public List<object> FindDuplicateValues(Hashtable table)
   {
       // Your implementation
   }
   ```

## 🎯 Advanced Concepts

### Performance Considerations
1. What factors affect Hashtable performance?
2. How does the load factor impact Hashtable performance?
3. When should you use a custom IEqualityComparer with Hashtable?
4. How do you optimize Hashtable for large datasets?

### Thread Safety
1. Is Hashtable thread-safe by default?
2. How do you make Hashtable operations thread-safe?
3. What are the alternatives to Hashtable for thread-safe operations?

### Memory Management
1. How does Hashtable handle memory allocation?
2. What are the memory implications of using Hashtable?
3. How do you properly dispose of a Hashtable?

## 🔄 Real-World Scenarios

### Data Processing
1. How would you use Hashtable to implement a caching system?
2. Design a method to track user sessions using Hashtable:
   ```csharp
   public class SessionManager
   {
       private Hashtable _sessions;
       // Your implementation
   }
   ```

3. Create a simple in-memory database using Hashtable:
   ```csharp
   public class InMemoryDatabase
   {
       private Hashtable _data;
       // Your implementation
   }
   ```

### Integration with Other Collections
1. How do you convert a Hashtable to other collection types?
2. Implement a method to synchronize a Hashtable with a List:
   ```csharp
   public void SynchronizeWithList(Hashtable table, List<string> list)
   {
       // Your implementation
   }
   ```

## 🧪 Testing and Debugging

### Error Handling
1. What are common exceptions when working with Hashtable?
2. How do you handle null keys or values?
3. Implement a safe method to get values:
   ```csharp
   public T GetValueOrDefault<T>(Hashtable table, object key, T defaultValue)
   {
       // Your implementation
   }
   ```

### Unit Testing
1. How do you test Hashtable operations?
2. Create unit tests for a Hashtable-based cache:
   ```csharp
   [Test]
   public void TestCacheOperations()
   {
       // Your implementation
   }
   ```

## 📝 Best Practices

### Code Quality
1. What are the best practices for using Hashtable?
2. When should you use Hashtable vs. Dictionary<TKey, TValue>?
3. How do you ensure type safety with Hashtable?

### Design Patterns
1. How can Hashtable be used in the Repository pattern?
2. Implement a simple caching pattern using Hashtable:
   ```csharp
   public class Cache<T>
   {
       private Hashtable _cache;
       // Your implementation
   }
   ```

## 🎓 Learning Exercises

### Implementation Tasks
1. Create a simple phone book using Hashtable:
   ```csharp
   public class PhoneBook
   {
       private Hashtable _contacts;
       // Your implementation
   }
   ```

2. Implement a simple shopping cart:
   ```csharp
   public class ShoppingCart
   {
       private Hashtable _items;
       // Your implementation
   }
   ```

### Problem-Solving Challenges
1. Design a method to find the most frequent value in a Hashtable
2. Create a method to sort Hashtable by values
3. Implement a method to find all keys with the same value

## 📚 Resources
- [Microsoft Documentation: Hashtable Class](https://docs.microsoft.com/en-us/dotnet/api/system.collections.hashtable)
- [C# Collections Best Practices](https://docs.microsoft.com/en-us/dotnet/standard/collections/best-practices)
- [Understanding Hash Tables](https://en.wikipedia.org/wiki/Hash_table)

## 🎯 Learning Path
1. Start with basic operations and understanding
2. Practice with simple implementations
3. Move to advanced concepts and patterns
4. Work on real-world scenarios
5. Master performance optimization 