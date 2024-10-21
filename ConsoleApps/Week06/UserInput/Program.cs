namespace UserInput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Example 1: Basic User Input
            // Prompt the user to enter their favorite color and read the input from the console.
            Console.WriteLine("Enter your favorite color:");
            string favoriteColor = Console.ReadLine();
            // Display the user's favorite color.
            Console.WriteLine("Your favorite color is: " + favoriteColor);

            // Example 2: User Input and Integer Conversion
            // Prompt the user to enter their age and read the input from the console.
            Console.WriteLine("Enter your age:");
            string ageInput = Console.ReadLine();
            // Convert the input string to an integer.
            int age = Convert.ToInt32(ageInput);
            // Display the user's age.
            Console.WriteLine("Your age is: " + age);

            // Example 3: User Input and Double Conversion
            // Prompt the user to enter the price of an item and read the input from the console.
            Console.WriteLine("Enter the price of the item:");
            string priceInput = Console.ReadLine();
            // Convert the input string to a double.
            double price = Convert.ToDouble(priceInput);
            // Display the price of the item.
            Console.WriteLine("The price of the item is: " + price);

            // Example 4: User Input and Boolean Conversion
            // Prompt the user to indicate if it is raining today and read the input from the console.
            Console.WriteLine("Is it raining today? (true/false):");
            string isRainingInput = Console.ReadLine();
            // Convert the input string to a boolean.
            bool isRaining = Convert.ToBoolean(isRainingInput);
            // Display whether it is raining today.
            Console.WriteLine("Is it raining today: " + isRaining);

            // Example 5: User Input and DateTime Conversion
            // Prompt the user to enter their birthdate in the specified format and read the input from the console.
            Console.WriteLine("Enter your birthdate (yyyy-MM-dd):");
            string birthdateInput = Console.ReadLine();
            // Convert the input string to a DateTime object.
            DateTime birthdate = Convert.ToDateTime(birthdateInput);
            // Display the user's birthdate in a short date format.
            Console.WriteLine("Your birthdate is: " + birthdate.ToShortDateString());
        }
    }
}