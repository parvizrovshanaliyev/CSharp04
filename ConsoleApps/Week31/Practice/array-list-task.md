## 📝 Task: Student Grades Management using `ArrayList`

### 🎯 Objective

Build a simple **C# console application** that simulates a **Student Grade Management System**. The program should allow users to:

* Add students with their grades
* View all registered students
* Calculate and display the average grade
* Remove a student by name

This task introduces object-oriented design, collection handling, and input validation using `ArrayList`.

---

### 📚 Requirements

1. Define a `Student` class with:

   * `string Name`
   * `double Grade`

2. Use an `ArrayList` to store `Student` objects.

3. Implement the following features:

   * ➕ **Add** a new student:

     * Prompt for `Name` and `Grade`
     * **Validate** inputs:

       * Name must not be empty
       * Grade must be a number between `0` and `100`
     * Prevent duplicate student names (case-insensitive)
   * 📋 **Display** all students:

     * Show each student's name and grade
     * Sort students by grade in **descending** order
   * 📊 **Calculate and show average grade**
   * ❌ **Remove** a student by name:

     * Ask for the name and remove the matching student if found

---

### 💡 Implementation Hints

* Use `ArrayList.Add()` to store instances of `Student`.
* When processing the list:

  * Use `foreach` to iterate
  * Use `is Student` and type casting to access properties
* For sorting:

  * Implement `IComparer` to sort `ArrayList` by grade
* Use `ArrayList.RemoveAt(index)` when removing by name

---

### 🧪 Sample Output

```
===== Student Grade System =====
1. Add student
2. Show all students
3. Show average grade
4. Remove student by name
5. Exit
Enter your choice: 1
Enter name: Alice
Enter grade: 85.5
✅ Student added!

...

Enter your choice: 2
📋 Students (sorted by grade):
Name: Bob     | Grade: 92.0
Name: Alice   | Grade: 85.5

...

Enter your choice: 3
📊 Average Grade: 88.75

...

Enter your choice: 4
Enter name to remove: Alice
✅ Student 'Alice' removed from list.
```

---

### ✅ Bonus (Already Integrated)

Encourage learners to:

* ✅ Validate all user input properly (empty names, grade range)
* ✅ Avoid duplicate student entries by name
* ✅ Sort the list by grade before displaying

---

This task strengthens understanding of collections, object-oriented programming, and real-world logic flow in a console-based C# app.
