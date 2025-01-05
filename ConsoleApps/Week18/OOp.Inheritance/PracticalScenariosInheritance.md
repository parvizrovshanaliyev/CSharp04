### **Practical Scenarios for Using Inheritance**

---

### **1. Creating a Class Hierarchy**

A base class provides common functionality that derived classes can extend or override:

- **Example**: `Animal` as a base class with derived classes `Dog` and `Cat`.

    ```csharp
    public class Animal
    {
        public virtual void Speak()
        {
            Console.WriteLine("Animal speaks");
        }
    }

    public class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("Dog barks");
        }
    }

    public class Cat : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("Cat meows");
        }
    }
    ```

    **Usage**:

    ```csharp
    Animal myAnimal = new Dog();
    myAnimal.Speak(); // Output: Dog barks
    ```

---

### **2. Extending Functionality**

Inheritance allows new features to be added without modifying the base class.

- **Example**: A `Vehicle` base class extended by `Car` and `Bike`.

    ```csharp
    public class Vehicle
    {
        public void Start()
        {
            Console.WriteLine("Vehicle started");
        }
    }

    public class Car : Vehicle
    {
        public void OpenTrunk()
        {
            Console.WriteLine("Trunk opened");
        }
    }

    public class Bike : Vehicle
    {
        public void KickStand()
        {
            Console.WriteLine("Kickstand engaged");
        }
    }
    ```

---

### **3. Polymorphism in Action**

Polymorphism enables dynamic method invocation based on the object type at runtime.

- **Example**: Using a single reference type to handle multiple derived types.

    ```csharp
    public class Shape
    {
        public virtual void Draw()
        {
            Console.WriteLine("Drawing Shape");
        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing Circle");
        }
    }

    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing Rectangle");
        }
    }

    public class Program
    {
        public static void Main()
        {
            Shape[] shapes = { new Circle(), new Rectangle() };

            foreach (Shape shape in shapes)
            {
                shape.Draw();
            }
        }
    }
    ```

    **Output**:

    ```plaintext
    Drawing Circle
    Drawing Rectangle
    ```

---

### **4. Implementing Common Logic**

Avoid duplicating logic by defining it in the base class and inheriting it in derived classes.

- **Example**: A `Payment` base class for `CreditCardPayment` and `PayPalPayment`.

    ```csharp
    public abstract class Payment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Processing payment...");
            ExecutePayment();
        }

        protected abstract void ExecutePayment();
    }

    public class CreditCardPayment : Payment
    {
        protected override void ExecutePayment()
        {
            Console.WriteLine("Credit Card payment completed.");
        }
    }

    public class PayPalPayment : Payment
    {
        protected override void ExecutePayment()
        {
            Console.WriteLine("PayPal payment completed.");
        }
    }
    ```

---

### **Summary**

- Inheritance simplifies code management by enabling hierarchical relationships.
- Use polymorphism to handle multiple types with a single reference.
- Extend functionality without modifying existing code.
- Implement shared logic in the base class to avoid duplication.

