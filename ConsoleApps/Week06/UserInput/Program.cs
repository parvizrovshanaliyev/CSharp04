namespace UserInput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Example 1: Basic User Input
            Console.WriteLine("Enter your favorite color:");
            string favoriteColor = Console.ReadLine();
            Console.WriteLine("Your favorite color is: " + favoriteColor);

            // Example 2: User Input and Integer Conversion
            Console.WriteLine("Enter your age:");
            string ageInput = Console.ReadLine();
            int age = Convert.ToInt32(ageInput);
            Console.WriteLine("Your age is: " + age);

            // Example 3: User Input and Double Conversion
            Console.WriteLine("Enter the price of the item:");
            string priceInput = Console.ReadLine();
            double price = Convert.ToDouble(priceInput);
            Console.WriteLine("The price of the item is: " + price);
        }
    }
}
