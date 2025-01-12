namespace OOP.Inheritance.MethodOverriding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            Dog dog= new Dog();

            dog.MakeSound();
        }
    }

    public class Animal
    {
        /// <summary>
        /// access modifier -> virtual -> return type -> Method Name
        /// </summary>
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound");
        }
    }

    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Dog barks: Woof!");
        }
    }

    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Cat meows: Meow!");
        }
    }
}
