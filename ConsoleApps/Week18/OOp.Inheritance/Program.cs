namespace OOp.Inheritance
{
    /*
     * Inheritance is one of the fundamental concepts in object-oriented programming (OOP)
     * that allows a class (derived/child class) to inherit properties and methods 
     * from another class (base/parent class).
     * 
     * Key Benefits of Inheritance:
     * 1. Code Reusability - Reuse fields and methods of existing class
     * 2. Method Overriding - Ability to modify parent class behavior
     * 3. Establishes "IS-A" relationship between classes
     */
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Basic inheritance example showing how a Child class
             * inherits and extends Parent class functionality
             */
            Console.WriteLine("=== Basic Inheritance Example ===");
            Child child = new Child(name: "John");
            child.Method1();  // Calls overridden method
            child.Method2();  // Calls inherited method
            child.DisplayInfo();

            /*
             * Multi-level inheritance example showing inheritance chain:
             * Parent -> Child -> Child2
             */
            Console.WriteLine("\n=== Multi-level Inheritance Example ===");
            Child2 child2 = new Child2("Alice", 10);
            child2.DisplayInfo();
        }
    }

    /*
     * Parent/Base class that defines the common properties and methods
     * that will be inherited by child classes.
     * 
     * Protected members are accessible within the same class and by derived classes,
     * providing encapsulation while allowing inheritance
     */
    class Parent
    {
        protected string name;  // Protected field accessible by derived classes

        /*
         * Property with protected backing field
         * Demonstrates encapsulation while allowing inheritance
         */
        public string Name
        {
            get => name;
            set => name = value;
        }

        /*
         * Default constructor
         * Called when no parameters are provided
         */
        public Parent()
        {
            Console.WriteLine("Parent Constructor Called");
        }

        /*
         * Protected constructor
         * Only accessible by derived classes
         */
        protected Parent(string name)
        {
            this.name = name;
        }

        /*
         * Virtual method that can be overridden by derived classes
         * Virtual keyword enables method overriding
         */
        public virtual void Method1()
        {
            Console.WriteLine("Parent's Method 1");
        }

        /*
         * Regular method that will be inherited as-is
         * Cannot be overridden without virtual keyword
         */
        public void Method2()
        {
            Console.WriteLine("Parent's Method 2");
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}");
        }
    }

    /*
     * Child class inherits from Parent class using : syntax
     * This establishes an "IS-A" relationship (Child IS-A Parent)
     */
    class Child : Parent
    {
        /*
         * Constructor chaining using base keyword
         * Calls the parent class constructor before executing its own code
         */
        public Child() : base()
        {
            Console.WriteLine("Child Constructor Called");
        }

        public Child(string name) : base(name)
        {
            Console.WriteLine($"Child Constructor Called with name: {name}");
        }

        /*
         * Method overriding example
         * Override keyword indicates this method provides new implementation
         * base keyword calls parent's version of the method
         */
        public override void Method1()
        {
            base.Method1();  // Call parent's implementation first
            Console.WriteLine("Child's Method 1");
        }

        /*
         * New method specific to Child class
         * Parent class doesn't have this method
         */
        public void Method3()
        {
            Console.WriteLine("Child's Method 3");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Child Info:");
            base.DisplayInfo();
        }
    }

    /*
     * Multi-level inheritance example
     * Child2 inherits from Child, which inherits from Parent
     * Demonstrates inheritance chain
     */
    class Child2 : Child
    {
        private int grade;  // Additional field specific to Child2

        public Child2() : base()
        {
            Console.WriteLine("Child2 Constructor Called");
        }

        /*
         * Constructor that takes additional parameter
         * Shows how derived class can extend parent's functionality
         */
        public Child2(string name, int grade) : base(name)
        {
            this.grade = grade;
            Console.WriteLine($"Child2 Constructor Called with name: {name} and grade: {grade}");
        }

        /*
         * Method specific to Child2
         * Shows how derived class can access inherited protected members
         */
        public void Study()
        {
            Console.WriteLine($"{Name} is studying in grade {grade}");
        }

        /*
         * Override DisplayInfo to include grade information
         * Shows how each level can add its own information while using parent's implementation
         */
        public override void DisplayInfo()
        {
            Console.WriteLine("Student Info:");
            base.DisplayInfo();
            Console.WriteLine($"Grade: {grade}");
        }
    }
}
