## **University Syllabus: C# Programming and Application Development**

### **Course Code:** CS305
### **Credits:** 3
### **Prerequisites:** Introductory Programming (CS101) or equivalent

---

### **Course Description**
This course provides an in-depth introduction to C# programming and the .NET platform, focusing on foundational programming concepts, object-oriented design, and advanced features. Students will learn how to build real-world applications by combining theoretical knowledge with hands-on programming experience. Topics include control structures, object-oriented programming (OOP), collections, LINQ, delegates, events, asynchronous programming, and database integration. The course emphasizes modern software development practices, preparing students for industry or advanced study.

---

### **Course Learning Outcomes**
By the end of this course, students will be able to:
1. Design, write, and debug efficient C# programs using industry-standard tools.
2. Apply programming constructs such as control flow, data structures, and error handling.
3. Leverage object-oriented principles to create modular, reusable, and maintainable code.
4. Use advanced C# features, including LINQ, delegates, events, and asynchronous programming, to solve complex problems.
5. Build complete applications that integrate with file systems, databases, and web APIs.
6. Test, debug, and optimize applications for performance and scalability.

---

### **Course Topics and Weekly Breakdown**

---

#### **Unit 1: Introduction to C# and .NET (Weeks 1-2)**
- **Introduction to C#**
  - History, features, and use cases: desktop, web, mobile, and gaming
  - Overview of the .NET ecosystem: .NET Framework, .NET Core, and .NET 6+
  - Role of the Common Language Runtime (CLR) and Just-In-Time (JIT) compilation
- **Development Environment**
  - Setting up Visual Studio and .NET SDK
  - Writing and running your first program: "Hello, World!"
  - Anatomy of a C# program: namespaces, classes, and the `Main` method

**Hands-On Practice**:
- Write and run your first program.
- Explore basic syntax by modifying simple programs (e.g., greeting with user input).

---

#### **Unit 2: Core Programming Fundamentals (Weeks 3-4)**
- **Data Types and Variables**
  - Primitive types (`int`, `float`, `string`, `bool`)
  - Constants, type inference (`var`), and nullable types (`int?`)
- **Control Structures**
  - Conditional statements: `if-else`, `switch-case`
  - Loops: `for`, `while`, `do-while`, and `foreach`
- **Operators and Type Conversion**
  - Arithmetic, comparison, logical, and ternary operators
  - Type casting: implicit, explicit, `Convert`, and `TryParse`
- **Error Handling**
  - Introduction to exceptions and `try-catch-finally`

**Hands-On Practice**:
- Write a program that validates user input and handles errors gracefully.
- Create a basic calculator with control flow and loops.

---

#### **Unit 3: Methods and Modular Programming (Week 5)**
- **Methods**
  - Defining and calling methods
  - Overloading methods and using default parameters
  - Passing parameters by value and by reference (`ref`, `out`)
- **Program Modularity**
  - Writing reusable functions and organizing code

**Hands-On Practice**:
- Build a program to calculate grades using modular methods.
- Refactor a previously written program to improve modularity.

---

#### **Unit 4: Object-Oriented Programming (OOP) Basics (Weeks 6-7)**
- **Classes and Objects**
  - Defining, creating, and using classes and objects
  - Encapsulation: access modifiers (`public`, `private`) and properties
- **Constructors**
  - Default, parameterized, and static constructors
- **The `object` Class**
  - Methods like `ToString`, `Equals`, and `GetHashCode`

**Hands-On Practice**:
- Create a `Book` class to store and display book details.
- Design a simple student management system using classes and objects.

---

#### **Unit 5: Boxing and Unboxing (Week 8)**
- **Concepts**
  - Boxing: converting value types into objects
  - Unboxing: extracting value types from objects
- **Practical Applications**
  - Usage in collections like `ArrayList`
- **Performance Considerations**
  - Reducing boxing with generics (`List<T>`)

**Hands-On Practice**:
- Write a program to demonstrate boxing/unboxing and measure performance differences.

---

#### **Unit 6: Advanced OOP Concepts (Weeks 9-10)**
- **Inheritance**
  - Base and derived classes
  - Overriding methods using `virtual` and `override`
- **Polymorphism**
  - Abstract classes and interfaces
  - Type casting: `is`, `as`, and explicit casting
- **Static Members and Singleton Pattern**
  - Static fields, properties, and methods
  - Implementing the Singleton design pattern

**Hands-On Practice**:
- Build a class hierarchy for vehicles, with derived classes like `Car` and `Truck`.
- Implement a polymorphic method to calculate mileage for different vehicle types.

---

#### **Unit 7: Collections and LINQ (Weeks 11-12)**
- **Collections**
  - Generic collections: `List<T>`, `Dictionary<TKey, TValue>`, `Queue<T>`, `Stack<T>`
- **LINQ**
  - Query syntax and method syntax
  - Filtering, sorting, and grouping data

**Hands-On Practice**:
- Build an inventory system for a library using collections.
- Write LINQ queries to filter and sort the inventory.

---

#### **Unit 8: Delegates, Events, and Lambda Expressions (Week 13)**
- **Delegates**
  - Single-cast and multicast delegates
  - Built-in delegates: `Action`, `Func`, and `Predicate`
- **Events**
  - Defining and subscribing to events
  - Event-driven programming concepts
- **Lambda Expressions**
  - Syntax and applications, particularly in LINQ

**Hands-On Practice**:
- Implement a notification system using events and delegates.
- Use lambda expressions to simplify LINQ queries.

---

#### **Unit 9: File Handling and Serialization (Week 14)**
- **File I/O**
  - Reading and writing files with `StreamReader` and `StreamWriter`
  - Managing directories and file paths
- **Serialization**
  - JSON serialization using `System.Text.Json`

**Hands-On Practice**:
- Build a program to save and load user preferences in a JSON file.

---

#### **Unit 10: Asynchronous and Parallel Programming (Week 15)**
- **Asynchronous Programming**
  - Using `async` and `await` for non-blocking operations
- **Multithreading Basics**
  - Creating and managing threads
- **Parallel Programming**
  - Using PLINQ to process large datasets

**Hands-On Practice**:
- Develop an asynchronous file downloader.

---

#### **Unit 11: Database Integration (Week 16)**
- **Entity Framework Core**
  - Setting up and using an ORM for CRUD operations
  - Database migrations and LINQ-to-Entities

**Hands-On Practice**:
- Create a student record management application backed by a database.

---

### **Assessment and Evaluation**
1. **Assignments (30%)**: Weekly coding exercises to reinforce learning.
2. **Quizzes (10%)**: Short quizzes at the end of core units (e.g., Units 2, 4, 6).
3. **Midterm Exam (20%)**: Covers foundational concepts (Units 1-5).
4. **Final Project (30%)**: Students will develop a full-fledged C# application, such as:
  - A library management system
  - A real-time chat application using SignalR
  - An e-commerce backend with authentication and payment integration
5. **Participation (10%)**: Attendance, in-class discussions, and code reviews.

---

### **Suggested Textbooks and Resources**
1. **"C# in Depth" by Jon Skeet**
2. **"Pro C# 10 and the .NET 6 Platform" by Andrew Troelsen and Philip Japikse**
3. **Microsoft Learn**: [https://learn.microsoft.com/dotnet/csharp](https://learn.microsoft.com/dotnet/csharp)

---

### **Key Enhancements**
1. **Improved Topic Sequencing**: Topics like delegates, events, and lambda expressions are introduced after foundational and intermediate OOP topics.
2. **Hands-On Emphasis**: Practical exercises are provided for every unit to ensure students apply theoretical knowledge.
3. **Industry Relevance**: The course includes real-world examples, modern development practices, and tools like LINQ and Entity Framework.
4. **Final Project Focus**: Encourages students to integrate and apply all concepts in a meaningful way.

