---

# Beginner OOP Practice Tasks - `Student` Class

This guide will help you create and practice Object-Oriented Programming (OOP) concepts by building a `Student` class.
The goal is to familiarize you with classes, properties, constructors, and methods.

---

## **Task Objective**

By completing this task, you will:
1. Learn how to create and use classes.
2. Understand how to define and use properties with validation.
3. Implement constructors to initialize objects with default and custom values.
4. Write methods to manipulate and display object data.

---

## **Step 1: Create the `Student` Class**

### **Requirements**
1. Define a `Student` class with the following properties:
   - **`Name`**: The name of the student.
     - Type: `string`
     - Default: `"Unknown"`
     - Validation: Must not be empty or null.
   - **`Grade`**: The student's grade (0–100).
     - Type: `int`
     - Default: `0`
     - Validation: Must be between `0` and `100`.
   - **`Age`**: The student's age.
     - Type: `int`
     - Default: `18`
     - Validation: Must be `>= 0`.
   - **`Major`**: The student’s field of study.
     - Type: `string`
     - Default: `"Undeclared"`

2. Add the following **constructors**:
   - **Default Constructor**:
     - Initializes the `Name` to `"Unknown"`, `Grade` to `0`, `Age` to `18`, and `Major` to `"Undeclared"`.
   - **Parameterized Constructor 1**:
     - Accepts `Name` and `Age` as parameters and sets default values for the other properties.
   - **Parameterized Constructor 2**:
     - Accepts `Name`, `Age`, `Grade`, and `Major` as parameters.

3. Implement the following **methods**:
   - **`DisplayDetails()`**:
     - Prints the student's details (`Name`, `Age`, `Grade`, `Major`).
   - **`ImproveGrade(int amount)`**:
     - Increases the `Grade` by the specified amount, but not above `100`.
   - **`ReduceGrade(int amount)`**:
     - Decreases the `Grade` by the specified amount, but not below `0`.
   - **`ChangeMajor(string newMajor)`**:
     - Updates the `Major` property. Validation: Rejects empty or null values.

---

## **Step 2: Write the `Main` Method**

### **Instructions**
1. **Create a Default Student**:
   - Instantiate a `Student` object using the default constructor.
   - Display its details using `DisplayDetails()`.

2. **Create a Custom Student**:
   - Instantiate a `Student` object using the second constructor with a name and age.
   - Display its details.

3. **Create a Fully Custom Student**:
   - Instantiate a `Student` object using the fully parameterized constructor with a name, age, grade, and major.
   - Display its details.

4. **Test the Methods**:
   - Improve and reduce the grade of a student.
   - Change a student’s major.
   - Display the updated details after each change.

---

## **Code Template**

Here’s how the `Student` class and `Main` method should look:

### **Student Class**
```csharp
public class Student
{
    // Properties
    public string Name { get; set; } = "Unknown";
    private int _grade;
    public int Grade
    {
        get => _grade;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentException("Grade must be between 0 and 100.");
            _grade = value;
        }
    }
    private int _age;
    public int Age
    {
        get => _age;
        set
        {
            if (value < 0)
                throw new ArgumentException("Age must be non-negative.");
            _age = value;
        }
    }
    public string Major { get; set; } = "Undeclared";

    // Constructors
    public Student() { }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public Student(string name, int age, int grade, string major)
    {
        Name = name;
        Age = age;
        Grade = grade;
        Major = major;
    }

    // Methods
    public void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Grade: {Grade}, Major: {Major}");
    }

    public void ImproveGrade(int amount)
    {
        Grade = Math.Min(Grade + amount, 100);
        Console.WriteLine($"{Name}'s grade has improved to {Grade}.");
    }

    public void ReduceGrade(int amount)
    {
        Grade = Math.Max(Grade - amount, 0);
        Console.WriteLine($"{Name}'s grade has reduced to {Grade}.");
    }

    public void ChangeMajor(string newMajor)
    {
        if (string.IsNullOrWhiteSpace(newMajor))
            throw new ArgumentException("Major cannot be empty or null.");
        Major = newMajor;
        Console.WriteLine($"{Name} has changed their major to {Major}.");
    }
}
```

---

### **Main Method**
```csharp
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Student Class Demonstration ===");

        // Default student
        Student student1 = new Student();
        student1.DisplayDetails();

        // Custom student (name and age)
        Student student2 = new Student("Alice", 20);
        student2.DisplayDetails();

        // Fully custom student
        Student student3 = new Student("Bob", 22, 85, "Computer Science");
        student3.DisplayDetails();

        // Improving and reducing grades
        student3.ImproveGrade(10);
        student3.ReduceGrade(30);

        // Changing major
        student3.ChangeMajor("Data Science");

        // Display final details
        student3.DisplayDetails();
    }
}
```

---

## **Expected Output**
```
=== Student Class Demonstration ===
Name: Unknown, Age: 18, Grade: 0, Major: Undeclared
Name: Alice, Age: 20, Grade: 0, Major: Undeclared
Name: Bob, Age: 22, Grade: 85, Major: Computer Science
Bob's grade has improved to 95.
Bob's grade has reduced to 65.
Bob has changed their major to Data Science.
Name: Bob, Age: 22, Grade: 65, Major: Data Science
```

---

## **Next Steps**

1. **Explore Validation Enhancements:**
   - Prevent empty names or majors.
   - Reject unrealistic age values (e.g., greater than 120).

2. **Add More Features:**
   - Add a `ScholarshipEligibility` method to check if `Grade > 90`.
   - Include a `GraduationEligibility` method to check if `Grade > 50`.

3. **Practice Subclasses:**
   - Create a `GraduateStudent` class that extends `Student` and adds a `ThesisTitle` property.

---