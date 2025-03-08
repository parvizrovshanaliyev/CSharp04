namespace ExtensionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string consoleInput = Console.ReadLine();

            // Extension method
            int number = int.Parse(consoleInput);
            int number2 = consoleInput.ToInt();


            Student student = new Student();

            Student.Display();


            ////////////////
            OldClass obj = new OldClass();
            obj.Test1();
            obj.Test2();
            //Calling Extension Methods
            obj.Test3();
            obj.Test4(10);
            obj.Test5();
            Console.ReadLine();
        }
    }

    public static class StringExtensions
    {
        public static int ToInt(this string value)
        {
            return int.Parse(value);
        }
    }


    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public static void Display()
        {
            //Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }

    public class Student :Person
    {
        
    }


    public class OldClass
    {
        public int x = 100;
        public void Test1()
        {
            Console.WriteLine("Method one: " + this.x);
        }
        public void Test2()
        {
            Console.WriteLine("Method two: " + this.x);
        }
    }


    public static class NewClass
    {
        public static void Test3(this OldClass O)
        {
            Console.WriteLine("Method Three");
        }
        public static void Test4(this OldClass O, int x)
        {
            Console.WriteLine("Method Four: " + x);
        }
        public static void Test5(this OldClass O)
        {
            Console.WriteLine("Method Five:" + O.x);
        }
    }
}
