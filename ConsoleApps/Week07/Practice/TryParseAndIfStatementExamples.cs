using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal class TryParseAndIfStatementExamples
    {
        static void Run()
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

            bool parsed = double.TryParse(Console.ReadLine(), out double celsius); // default 0
            if (parsed == true)
            {
                double fahrenheit = (celsius * 9 / 5) + 32;
                Console.WriteLine($"The temperature in Celsius is: {celsius}");
                Console.WriteLine($"The temperature in Fahrenheit is: {fahrenheit}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }

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
            if (double.TryParse(Console.ReadLine(), out double radius))
            {
                double area = Math.PI * Math.Pow(radius, 2);
                Console.WriteLine($"The radius of the circle is: {radius}");
                Console.WriteLine($"The area of the circle is: {area:F2}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }

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
            if (double.TryParse(Console.ReadLine(), out double principal))
            {
                Console.Write("Enter the rate of interest: ");
                if (double.TryParse(Console.ReadLine(), out double rate))
                {
                    Console.Write("Enter the time in years: ");
                    if (double.TryParse(Console.ReadLine(), out double time))
                    {
                        double simpleInterest = (principal * rate * time) / 100;
                        Console.WriteLine($"The simple interest is: {simpleInterest}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for time. Please enter a numeric value.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for rate. Please enter a numeric value.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for principal. Please enter a numeric value.");
            }

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
            if (double.TryParse(Console.ReadLine(), out double length))
            {
                Console.Write("Enter the width of the rectangle: ");
                if (double.TryParse(Console.ReadLine(), out double width))
                {
                    double perimeter = 2 * (length + width);
                    Console.WriteLine($"The perimeter of the rectangle is: {perimeter}");
                }
                else
                {
                    Console.WriteLine("Invalid input for width. Please enter a numeric value.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for length. Please enter a numeric value.");
            }

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
            if (int.TryParse(Console.ReadLine(), out int minutes))
            {
                int hours = minutes / 60;
                int remainingMinutes = minutes % 60;
                Console.WriteLine($"{minutes} minutes is {hours} hour(s) and {remainingMinutes} minute(s).");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter an integer value.");
            }

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
            if (double.TryParse(Console.ReadLine(), out double kilometers))
            {
                double miles = kilometers * 0.621371;
                Console.WriteLine($"The distance in miles is: {miles:F5}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }

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
            if (double.TryParse(Console.ReadLine(), out double num1))
            {
                Console.Write("Enter the second number: ");
                if (double.TryParse(Console.ReadLine(), out double num2))
                {
                    Console.Write("Enter the third number: ");
                    if (double.TryParse(Console.ReadLine(), out double num3))
                    {
                        double average = (num1 + num2 + num3) / 3;
                        Console.WriteLine($"The average of {num1}, {num2}, and {num3} is: {average}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for third number. Please enter a numeric value.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for second number. Please enter a numeric value.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for first number. Please enter a numeric value.");
            }

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
            if (int.TryParse(Console.ReadLine(), out int days))
            {
                int weeks = days / 7;
                int remainingDays = days % 7;
                Console.WriteLine($"{days} days is {weeks} week(s) and {remainingDays} day(s).");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter an integer value.");
            }

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
            if (double.TryParse(Console.ReadLine(), out double grams))
            {
                double kilograms = grams / 1000;
                Console.WriteLine($"The weight in kilograms is: {kilograms}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
        }
    }
}
