Here�s an updated and enhanced version of your **Practical Scenarios for Using Inheritance** document. I�ve clarified points, refined examples, and improved formatting for better readability and comprehensiveness.

---

### **Practical Scenarios for Using Inheritance**

---

### **1. Creating a Class Hierarchy**

Inheritance is ideal for modeling hierarchical relationships where base classes define common behavior and derived classes specialize or extend it.

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

    myAnimal = new Cat();
    myAnimal.Speak(); // Output: Cat meows
    ```

    **Why use this approach?**
    - Promotes code reuse and maintainability.
    - Allows extending behavior by adding new derived classes without modifying existing ones.

---

### **2. Extending Functionality**

Inheritance enables the addition of new features to a class while preserving the base class's original behavior. 

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

    **Usage**:

    ```csharp
    Car car = new Car();
    car.Start();        // Output: Vehicle started
    car.OpenTrunk();    // Output: Trunk opened

    Bike bike = new Bike();
    bike.Start();       // Output: Vehicle started
    bike.KickStand();   // Output: Kickstand engaged
    ```

    **Benefits**:
    - Shared functionality (`Start`) resides in the base class.
    - Unique functionality (`OpenTrunk`, `KickStand`) is added in derived classes.

---

### **3. Polymorphism in Action**

Polymorphism allows objects to be treated as instances of their base class, enabling dynamic method invocation based on the actual object type at runtime.

- **Example**: Drawing shapes using a single reference type.

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

    **Why is this useful?**
    - Simplifies code by handling different derived types through a single base class reference.
    - Facilitates dynamic behavior and reduces code duplication.

---

### **4. Implementing Common Logic**

Inheritance reduces redundancy by centralizing shared logic in a base class, with derived classes implementing specific details.

- **Example**: A `Payment` base class for `CreditCardPayment` and `PayPalPayment`.

    ```csharp
    public abstract class Payment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Processing payment...");
            ExecutePayment(); // Specific behavior handled by derived classes
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

    **Usage**:

    ```csharp
    Payment payment = new CreditCardPayment();
    payment.ProcessPayment();
    // Output:
    // Processing payment...
    // Credit Card payment completed.

    payment = new PayPalPayment();
    payment.ProcessPayment();
    // Output:
    // Processing payment...
    // PayPal payment completed.
    ```

    **Advantages**:
    - Common logic (`ProcessPayment`) is implemented once in the base class.
    - Specific behavior (`ExecutePayment`) is provided by derived classes.

---

### **5. Enhancing Maintainability with Abstract Classes**

Abstract classes provide a blueprint for derived classes, ensuring consistent implementation of essential functionality.

- **Example**: Abstract class for employees with specific implementations.

    ```csharp
    public abstract class Employee
    {
        public abstract void CalculateSalary();

        public void DisplayInfo()
        {
            Console.WriteLine("Employee details displayed.");
        }
    }

    public class FullTimeEmployee : Employee
    {
        public override void CalculateSalary()
        {
            Console.WriteLine("Calculating salary for full-time employee...");
        }
    }

    public class PartTimeEmployee : Employee
    {
        public override void CalculateSalary()
        {
            Console.WriteLine("Calculating salary for part-time employee...");
        }
    }
    ```

    **Usage**:

    ```csharp
    Employee emp = new FullTimeEmployee();
    emp.CalculateSalary(); // Output: Calculating salary for full-time employee...
    emp.DisplayInfo();     // Output: Employee details displayed.

    emp = new PartTimeEmployee();
    emp.CalculateSalary(); // Output: Calculating salary for part-time employee...
    ```

---

### **Summary**

1. **Class Hierarchies**: Model real-world relationships using base and derived classes.
2. **Extending Functionality**: Add new features while preserving existing behavior.
3. **Polymorphism**: Simplify code with dynamic method invocation.
4. **Shared Logic**: Avoid redundancy by centralizing common functionality in the base class.
5. **Abstract Classes**: Ensure consistent implementation for essential functionality.

