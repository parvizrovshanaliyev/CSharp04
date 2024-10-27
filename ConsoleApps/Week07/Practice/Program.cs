namespace Practice;

using System;

class Program
{
    static void Main()
    {
        /* 
         * Task 1: Celsius to Fahrenheit Conversion
         * This task prompts the user to enter a temperature in Celsius.
         * It then converts the Celsius temperature to Fahrenheit using the formula: F = (C × 9/5) + 32.
         * Finally, it displays both the Celsius and Fahrenheit values.
         * 
         * Example Input: 
         * Enter temperature in Celsius: 25
         * 
         * Expected Output:
         * The temperature in Celsius is: 25
         * The temperature in Fahrenheit is: 77
         */
        Console.Write("Enter temperature in Celsius: ");
        double celsius = Convert.ToDouble(Console.ReadLine());
        double fahrenheit = (celsius * 9 / 5) + 32;
        Console.WriteLine($"The temperature in Celsius is: {celsius}");
        Console.WriteLine($"The temperature in Fahrenheit is: {fahrenheit}");

        /* 
         * Task 2: Area of a Circle
         * This task prompts the user to enter the radius of a circle.
         * It then calculates the area using the formula: Area = π * r^2 (using Math.PI for π).
         * Finally, it displays the radius and area of the circle.
         * 
         * Example Input:
         * Enter the radius of the circle: 5
         * 
         * Expected Output:
         * The radius of the circle is: 5
         * The area of the circle is: 78.54
         */
        Console.Write("Enter the radius of the circle: ");
        double radius = Convert.ToDouble(Console.ReadLine());
        double area = Math.PI * Math.Pow(radius, 2);
        Console.WriteLine($"The radius of the circle is: {radius}");
        Console.WriteLine($"The area of the circle is: {area:F2}");

        /* 
         * Task 3: Simple Interest Calculator
         * This task prompts the user to enter the principal amount, rate of interest, and time (in years).
         * It then calculates the simple interest using the formula: Simple Interest = (Principal * Rate * Time) / 100.
         * Finally, it displays the calculated simple interest.
         * 
         * Example Input:
         * Enter the principal amount: 1000
         * Enter the rate of interest: 5
         * Enter the time in years: 2
         * 
         * Expected Output:
         * The simple interest is: 100
         */
        Console.Write("Enter the principal amount: ");
        double principal = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the rate of interest: ");
        double rate = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the time in years: ");
        double time = Convert.ToDouble(Console.ReadLine());
        double simpleInterest = (principal * rate * time) / 100;
        Console.WriteLine($"The simple interest is: {simpleInterest}");

        /* 
         * Task 4: Rectangle Perimeter Calculator
         * This task prompts the user to enter the length and width of a rectangle.
         * It then calculates the perimeter using the formula: Perimeter = 2 * (Length + Width).
         * Finally, it displays the calculated perimeter of the rectangle.
         * 
         * Example Input:
         * Enter the length of the rectangle: 8
         * Enter the width of the rectangle: 3
         * 
         * Expected Output:
         * The perimeter of the rectangle is: 22
         */
        Console.Write("Enter the length of the rectangle: ");
        double length = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the width of the rectangle: ");
        double width = Convert.ToDouble(Console.ReadLine());
        double perimeter = 2 * (length + width);
        Console.WriteLine($"The perimeter of the rectangle is: {perimeter}");

        /* 
         * Task 5: Convert Minutes to Hours and Minutes
         * This task prompts the user to enter a number of minutes.
         * It then converts the minutes into hours and remaining minutes.
         * Finally, it displays the converted time in hours and minutes.
         * 
         * Example Input:
         * Enter the number of minutes: 130
         * 
         * Expected Output:
         * 130 minutes is 2 hour(s) and 10 minute(s).
         */
        Console.Write("Enter the number of minutes: ");
        int minutes = Convert.ToInt32(Console.ReadLine());
        int hours = minutes / 60;
        int remainingMinutes = minutes % 60;
        Console.WriteLine($"{minutes} minutes is {hours} hour(s) and {remainingMinutes} minute(s).");

        /* 
         * Task 6: Kilometers to Miles Converter
         * This task prompts the user to enter a distance in kilometers.
         * It then converts the distance to miles using the formula: Miles = Kilometers * 0.621371.
         * Finally, it displays the distance in miles.
         * 
         * Example Input:
         * Enter distance in kilometers: 10
         * 
         * Expected Output:
         * The distance in miles is: 6.21371
         */
        Console.Write("Enter distance in kilometers: ");
        double kilometers = Convert.ToDouble(Console.ReadLine());
        double miles = kilometers * 0.621371;
        Console.WriteLine($"The distance in miles is: {miles:F5}");

        /* 
         * Task 7: Average of Three Numbers
         * This task prompts the user to enter three numbers.
         * It then calculates the average of these numbers.
         * Finally, it displays the calculated average.
         * 
         * Example Input:
         * Enter the first number: 10
         * Enter the second number: 20
         * Enter the third number: 30
         * 
         * Expected Output:
         * The average of 10, 20, and 30 is: 20
         */
        Console.Write("Enter the first number: ");
        double num1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the second number: ");
        double num2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the third number: ");
        double num3 = Convert.ToDouble(Console.ReadLine());
        double average = (num1 + num2 + num3) / 3;
        Console.WriteLine($"The average of {num1}, {num2}, and {num3} is: {average}");

        /* 
         * Task 8: Convert Days to Weeks and Days
         * This task prompts the user to enter a number of days.
         * It then converts the days into weeks and remaining days.
         * Finally, it displays the converted time in weeks and days.
         * 
         * Example Input:
         * Enter the number of days: 10
         * 
         * Expected Output:
         * 10 days is 1 week(s) and 3 day(s).
         */
        Console.Write("Enter the number of days: ");
        int days = Convert.ToInt32(Console.ReadLine());
        int weeks = days / 7;
        int remainingDays = days % 7;
        Console.WriteLine($"{days} days is {weeks} week(s) and {remainingDays} day(s).");

        /* 
         * Task 9: Grams to Kilograms Converter
         * This task prompts the user to enter a weight in grams.
         * It then converts the weight to kilograms.
         * Finally, it displays the weight in kilograms.
         * 
         * Example Input:
         * Enter the weight in grams: 2500
         * 
         * Expected Output:
         * The weight in kilograms is: 2.5
         */
        Console.Write("Enter the weight in grams: ");
        double grams = Convert.ToDouble(Console.ReadLine());
        double kilograms = grams / 1000;
        Console.WriteLine($"The weight in kilograms is: {kilograms}");
    }
}
