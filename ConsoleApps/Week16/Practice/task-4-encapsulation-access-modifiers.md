 ### **Task 4: Design and Build an Employee Management System**

---

### **Objective**

The goal of this task is to create an **Employee Management System** that demonstrates the principles of **encapsulation** and **data validation**. You will design an `Employee` class to securely store and manage employee information while ensuring that only valid data can be set or retrieved.

By completing this task, you will:
1. Learn how to use **private fields** and **public methods** to implement encapsulation.
2. Practice validating input to maintain data integrity.
3. Apply structured programming techniques to design a real-world use case.

---

### **Key Concepts**

1. **Encapsulation**:
   - Hide the internal details of the `Employee` class by using private fields.
   - Expose only the necessary functionality via public methods.

2. **Access Modifiers**:
   - Use `private` for sensitive fields to restrict direct access.
   - Provide controlled access through `public` methods and properties.

3. **Validation**:
   - Enforce rules such as:
     - Salary must be positive.
     - Performance ratings must be between 1 and 5.
     - Department names cannot be empty.

4. **Real-World Relevance**:
   - Implement operations such as updating salary, changing departments, and tracking employee performance.

---

### **Requirements**

1. **Create an `Employee` Class**:
   - Define the following private fields:
     - `employeeId`: A unique identifier for each employee.
     - `name`: The employee's full name.
     - `department`: The department the employee belongs to (e.g., IT, HR).
     - `salary`: The employee's monthly salary (default: 0).
     - `performanceRating`: A performance rating between 1 and 5 (default: 0).
   - Ensure these fields are **private** to protect their values.

2. **Add a Constructor**:
   - The constructor should initialize:
     - `employeeId` (required and immutable).
     - `name` (must not be empty).
     - `department` (must not be empty).
   - Use default values for `salary` and `performanceRating`.

3. **Implement Methods**:
   - `SetSalary(decimal salary)`: Set the employee's salary.
     - Ensure the salary is positive.
   - `GetDetails()`: Display all employee details (e.g., ID, name, department, salary, and performance rating).
   - `UpdatePerformanceRating(int rating)`: Update the performance rating (must be between 1 and 5).
   - `ChangeDepartment(string newDepartment)`: Change the employee’s department (must not be empty).

4. **Integrate and Test**:
   - Create at least one `Employee` object in your program.
   - Demonstrate:
     - Setting and updating the salary.
     - Changing the department.
     - Updating the performance rating.
     - Displaying the employee details after each operation.
   - Attempt invalid operations (e.g., setting a negative salary) and handle them gracefully by skipping the change with appropriate console output.

---

### **Expected Console Behavior**

Here’s an example of how the program should behave:

```plaintext
=== Employee Management System ===

--- Initial Employee Details ---
Employee ID: 1
Name: John Doe
Department: IT
Salary: $0.00
Performance Rating: 0

--- Setting Salary ---
Setting salary to $3000.00...
Salary updated successfully.
Employee ID: 1
Name: John Doe
Department: IT
Salary: $3,000.00
Performance Rating: 0

--- Updating Performance Rating ---
Updating performance rating to 4...
Performance rating updated successfully.
Employee ID: 1
Name: John Doe
Department: IT
Salary: $3,000.00
Performance Rating: 4

--- Changing Department ---
Changing department to HR...
Department updated successfully.
Employee ID: 1
Name: John Doe
Department: HR
Salary: $3,000.00
Performance Rating: 4

--- Attempting Invalid Operations ---
Setting salary to -500...
Error: Salary must be positive.

Updating performance rating to 6...
Error: Performance rating must be between 1 and 5.

Changing department to an empty string...
Error: Department name cannot be empty.

--- Final Employee Details ---
Employee ID: 1
Name: John Doe
Department: HR
Salary: $3,000.00
Performance Rating: 4
```

---
### **Learning Goals**

By completing this task, you will:
1. Gain a deeper understanding of **encapsulation** and how it protects data.
2. Practice designing a class that enforces business rules through validation.
3. Understand how access modifiers (`private`, `public`) help control the visibility of class members.
4. Develop a structured approach to problem-solving in real-world scenarios. 