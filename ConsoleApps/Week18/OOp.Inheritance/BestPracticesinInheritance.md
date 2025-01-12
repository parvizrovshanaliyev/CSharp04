### **Best Practices in Inheritance**

---

### **1. Favor Composition Over Inheritance**

While inheritance is a powerful tool, it is not always the best solution. Use inheritance only when there is a clear **"is-a" relationship**. For **"has-a" relationships**, prefer composition to maintain flexibility and reduce tight coupling.

#### Example:

- **Inheritance** (Clear "is-a" relationship):
    ```csharp
    public class Vehicle
    {
        public void Start() => Console.WriteLine("Vehicle started");
    }

    public class Car : Vehicle
    {
    }
    ```

- **Composition** (Clear "has-a" relationship):
    ```csharp
    public class Engine
    {
        public void Start() => Console.WriteLine("Engine started");
    }

    public class Car
    {
        private Engine engine = new Engine();

        public void StartCar() => engine.Start();
    }
    ```

**Why favor composition?**
- Greater flexibility.
- Easier to modify or replace components.
- Reduces unintended side effects from base class changes.

---

### **2. Keep Inheritance Hierarchies Shallow**

Deep inheritance hierarchies can make code harder to understand, debug, and maintain. Strive to keep hierarchies **shallow** and **focused**:

#### Strategies:
- Limit inheritance levels to **2-3 layers**.
- Split large classes into smaller, specialized ones.
- Avoid scenarios where every change in the base class cascades to numerous derived classes.

---

### **3. Use Abstract Classes for Base Functionality**

Abstract classes are ideal for defining shared functionality while requiring derived classes to implement specific details. They provide a blueprint for derived classes.

#### Example:
```csharp
public abstract class Animal
{
    public void Eat() => Console.WriteLine("Eating...");
    public abstract void Speak(); // Must be implemented by derived classes
}

public class Dog : Animal
{
    public override void Speak() => Console.WriteLine("Dog barks");
}

public class Cat : Animal
{
    public override void Speak() => Console.WriteLine("Cat meows");
}
```

**Benefits of abstract classes**:
- Shared logic resides in the base class.
- Derived classes enforce specific implementations.

---

### **4. Use Interfaces for Contracts**

Use interfaces to define behavior that multiple unrelated classes should implement. Unlike abstract classes, interfaces focus on **what** a class can do rather than **how** it does it.

#### Example:
```csharp
public interface IDrawable
{
    void Draw();
}

public class Circle : IDrawable
{
    public void Draw() => Console.WriteLine("Drawing Circle");
}

public class Rectangle : IDrawable
{
    public void Draw() => Console.WriteLine("Drawing Rectangle");
}
```

**Why use interfaces?**
- Decouples implementation from the interface.
- Allows multiple inheritance of behavior.

---

### **5. Adhere to the Liskov Substitution Principle (LSP)**

Derived classes must be substitutable for their base classes without altering the correctness of the program. Avoid breaking the expectations set by the base class.

#### Good Example:
```csharp
public class Bird
{
    public virtual void Fly() => Console.WriteLine("Flying...");
}

public class Sparrow : Bird
{
}

Bird myBird = new Sparrow();
myBird.Fly(); // Works correctly
```

#### Bad Example (Breaking LSP):
```csharp
public class Bird
{
    public virtual void Fly() => Console.WriteLine("Flying...");
}

public class Penguin : Bird
{
    public override void Fly()
    {
        throw new NotImplementedException("Penguins cannot fly");
    }
}

Bird myBird = new Penguin();
myBird.Fly(); // Throws unexpected exception
```

**How to avoid breaking LSP?**
- Ensure derived classes respect the behavior of the base class.
- Use alternative class hierarchies when behavior diverges significantly.

---

### **6. Use `sealed` When Necessary**

Mark classes or methods as `sealed` to prevent further inheritance or overriding, especially when no additional specialization is required or to avoid misuse.

#### Example:
```csharp
public class BaseClass
{
    public virtual void DoWork() => Console.WriteLine("Base work");
}

public class DerivedClass : BaseClass
{
    public sealed override void DoWork() => Console.WriteLine("Derived work");
}

// Further overriding of DoWork is not allowed.
```

**Benefits**:
- Prevents unintended extension or modification.
- Secures critical functionality.

---

### **7. Test for Side Effects in Overridden Methods**

When overriding methods, ensure no unintended side effects are introduced. Thoroughly test the interactions between base and derived class methods.

#### Example:
```csharp
public class BaseClass
{
    public virtual void Display() => Console.WriteLine("Base display");
}

public class DerivedClass : BaseClass
{
    public override void Display()
    {
        base.Display(); // Calls base method
        Console.WriteLine("Derived display");
    }
}
```

**Testing Considerations**:
- Ensure base behavior remains consistent.
- Validate the combined behavior of base and overridden methods.

---

### **8. Follow Single Responsibility Principle (SRP)**

Each class in the inheritance hierarchy should have a **single responsibility**. Avoid overloading base classes with unrelated functionality.

#### Example:
Instead of creating a single class with multiple responsibilities:
```csharp
public class ReportHandler
{
    public void GenerateReport() => Console.WriteLine("Generating report...");
    public void PrintReport() => Console.WriteLine("Printing report...");
}
```

Split responsibilities into separate classes:
```csharp
public class ReportGenerator
{
    public void GenerateReport() => Console.WriteLine("Generating report...");
}

public class ReportPrinter
{
    public void PrintReport() => Console.WriteLine("Printing report...");
}
```

**Why follow SRP?**
- Simplifies maintenance and testing.
- Promotes reusability and clarity.

---

### **Summary**

1. **Favor Composition Over Inheritance**: Use composition for "has-a" relationships.
2. **Keep Inheritance Hierarchies Shallow**: Avoid deep hierarchies for simplicity.
3. **Use Abstract Classes for Base Functionality**: Share common logic while enforcing specific behaviors.
4. **Use Interfaces for Contracts**: Define behavior for unrelated classes.
5. **Adhere to Liskov Substitution Principle**: Ensure derived classes behave consistently with base classes.
6. **Use `sealed` for Final Classes or Methods**: Prevent further inheritance or overriding when necessary.
7. **Test Overridden Methods Thoroughly**: Avoid unexpected side effects.
8. **Follow Single Responsibility Principle**: Ensure each class has a well-defined purpose.

By following these best practices, you can leverage inheritance effectively while maintaining a clean, robust, and scalable codebase.