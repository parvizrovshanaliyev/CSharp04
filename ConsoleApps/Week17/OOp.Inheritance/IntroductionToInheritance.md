### **Introduction to Inheritance**

---

### **What is Inheritance?**

Inheritance is one of the fundamental concepts of Object-Oriented Programming (OOP). It allows a class (known as the **derived class**) to inherit members such as fields, properties, methods, and events from another class (known as the **base class**). This facilitates code reusability and establishes a relationship between the classes.

---

### **Purpose of Inheritance**

1. **Code Reusability**:
   - Common functionality can be defined in a base class and reused across multiple derived classes.

2. **Hierarchy Creation**:
   - Inheritance establishes an "is-a" relationship, such as "a Dog is an Animal."

3. **Extensibility**:
   - Derived classes can extend the behavior of the base class by adding new members or overriding existing ones.

---

### **Inheritance vs. Composition**

- **Inheritance**:
  - Represents an "is-a" relationship.
  - Example: A "Car" is a "Vehicle."

- **Composition**:
  - Represents a "has-a" relationship.
  - Example: A "Car" has an "Engine."

Choosing between inheritance and composition depends on the relationship between the classes and the flexibility required.

---

### **Base and Derived Classes**

- **Base Class**:
  - The parent class that provides common functionality.
  - Example:

    ```csharp
    public class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Eating...");
        }
    }
    ```

- **Derived Class**:
  - The child class that inherits from the base class.
  - Example:

    ```csharp
    public class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("Barking...");
        }
    }
    ```

- Usage:

    ```csharp
    Dog myDog = new Dog();
    myDog.Eat();  // Inherited from Animal
    myDog.Bark(); // Defined in Dog
    ```

---

### **Summary**

- Inheritance is a core concept that promotes code reusability, hierarchy creation, and extensibility.
- Use inheritance when there is a clear "is-a" relationship.
- Understand the distinction between inheritance and composition to choose the right approach for your design.



