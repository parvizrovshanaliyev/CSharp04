﻿using System;

namespace Practice
{
    class IfElseTasks
    {
        public static void Run()
        {
            // --- Task 1: Determine Leap Year ---
            /*
             * Description:
             * Write a program that prompts the user to enter a year and determines
             * if it is a leap year. A leap year is divisible by 4 but not by 100,
             * unless it is also divisible by 400.
             *
             * Example Input:
             *   Enter a year: 2024
             * Example Output:
             *   2024 is a leap year.
             *
             * Example Input:
             *   Enter a year: 1900
             * Example Output:
             *   1900 is not a leap year.
             */
            Console.Write("Enter a year: ");
            int year = int.Parse(Console.ReadLine());
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
                Console.WriteLine($"{year} is a leap year.");
            else
                Console.WriteLine($"{year} is not a leap year.");
            Console.WriteLine();

            // --- Task 2: Check if Character is Vowel or Consonant ---
            /*
             * Description:
             * Write a program that takes a single character as input and checks
             * if it is a vowel (a, e, i, o, u - case insensitive) or a consonant.
             *
             * Example Input:
             *   Enter a character: A
             * Example Output:
             *   A is a vowel.
             *
             * Example Input:
             *   Enter a character: B
             * Example Output:
             *   B is a consonant.
             */
            Console.Write("Enter a character: ");
            char character = char.ToUpper(Console.ReadLine()[0]);
            if ("AEIOU".Contains(character))
                Console.WriteLine($"{character} is a vowel.");
            else
                Console.WriteLine($"{character} is a consonant.");
            Console.WriteLine();

            // --- Task 3: Check for Weekend ---
            /*
             * Description:
             * Write a program that prompts the user to enter the day of the week.
             * The program should determine if the day is a weekend (Saturday or Sunday)
             * or a weekday.
             *
             * Example Input:
             *   Enter the day of the week: Saturday
             * Example Output:
             *   Saturday is a weekend.
             *
             * Example Input:
             *   Enter the day of the week: Wednesday
             * Example Output:
             *   Wednesday is a weekday.
             */
            Console.Write("Enter the day of the week: ");
            string day = Console.ReadLine().Trim().ToLower();
            if (day == "saturday" || day == "sunday")
                Console.WriteLine($"{char.ToUpper(day[0]) + day.Substring(1)} is a weekend.");
            else
                Console.WriteLine($"{char.ToUpper(day[0]) + day.Substring(1)} is a weekday.");
            Console.WriteLine();

            // --- Task 4: Calculate BMI Category ---
            /*
             * Description:
             * Write a program that asks the user for their weight (in kg) and height (in meters),
             * calculates their Body Mass Index (BMI), and categorizes it.
             *
             * BMI < 18.5: Underweight
             * 18.5 <= BMI < 24.9: Normal weight
             * 25 <= BMI < 29.9: Overweight
             * BMI >= 30: Obesity
             *
             * Example Input:
             *   Enter your weight in kg: 70
             *   Enter your height in meters: 1.75
             * Example Output:
             *   Your BMI is 22.9, which is considered Normal weight.
             */
            Console.Write("Enter your weight in kg: ");
            double weight = double.Parse(Console.ReadLine());
            Console.Write("Enter your height in meters: ");
            double height = double.Parse(Console.ReadLine());
            double bmi = weight / (height * height);
            Console.Write($"Your BMI is {bmi:F1}, which is considered ");
            if (bmi < 18.5)
                Console.WriteLine("Underweight.");
            else if (bmi < 25)
                Console.WriteLine("Normal weight.");
            else if (bmi < 30)
                Console.WriteLine("Overweight.");
            else
                Console.WriteLine("Obesity.");
            Console.WriteLine();

            // --- Task 5: Identify Triangle Type ---
            /*
             * Description:
             * Write a program that asks the user for the three side lengths of a triangle
             * and identifies if it is Equilateral (all sides equal), Isosceles (two sides equal),
             * or Scalene (all sides different).
             *
             * Example Input:
             *   Enter side 1: 5
             *   Enter side 2: 5
             *   Enter side 3: 5
             * Example Output:
             *   This is an Equilateral triangle.
             */
            Console.Write("Enter side 1: ");
            int side1 = int.Parse(Console.ReadLine());
            Console.Write("Enter side 2: ");
            int side2 = int.Parse(Console.ReadLine());
            Console.Write("Enter side 3: ");
            int side3 = int.Parse(Console.ReadLine());
            if (side1 == side2 && side2 == side3)
                Console.WriteLine("This is an Equilateral triangle.");
            else if (side1 == side2 || side1 == side3 || side2 == side3)
                Console.WriteLine("This is an Isosceles triangle.");
            else
                Console.WriteLine("This is a Scalene triangle.");
            Console.WriteLine();

            // --- Task 6: Determine Shipping Cost Based on Weight ---
            /*
             * Description:
             * Write a program that calculates the shipping cost based on package weight.
             * - <= 1 kg: $5
             * - > 1 kg and <= 5 kg: $10
             * - > 5 kg and <= 10 kg: $20
             * - > 10 kg: $50
             *
             * Example Input:
             *   Enter package weight in kg: 3
             * Example Output:
             *   The shipping cost is $10.
             */
            Console.Write("Enter package weight in kg: ");
            double weightInKg = double.Parse(Console.ReadLine());
            int cost;
            if (weightInKg <= 1)
                cost = 5;
            else if (weightInKg <= 5)
                cost = 10;
            else if (weightInKg <= 10)
                cost = 20;
            else
                cost = 50;
            Console.WriteLine($"The shipping cost is ${cost}.");
            Console.WriteLine();

            // --- Task 7: Calculate Electricity Bill ---
            /*
             * Description:
             * Write a program that calculates the electricity bill based on the following rates:
             * - 0-100 units: $0.50 per unit
             * - 101-200 units: $0.75 per unit
             * - 201-300 units: $1.20 per unit
             * - Over 300 units: $1.50 per unit
             *
             * Example Input:
             *   Enter units consumed: 150
             * Example Output:
             *   The total bill is $112.5.
             */
            Console.Write("Enter units consumed: ");
            int units = int.Parse(Console.ReadLine());
            double bill = 0;
            if (units <= 100)
                bill = units * 0.50;
            else if (units <= 200)
                bill = 100 * 0.50 + (units - 100) * 0.75;
            else if (units <= 300)
                bill = 100 * 0.50 + 100 * 0.75 + (units - 200) * 1.20;
            else
                bill = 100 * 0.50 + 100 * 0.75 + 100 * 1.20 + (units - 300) * 1.50;
            Console.WriteLine($"The total bill is ${bill}.");
            Console.WriteLine();

            // --- Task 8: Check if Number is Divisible by 2, 3, or 5 ---
            /*
             * Description:
             * Write a program that prompts the user for a number and checks if it is divisible by 2, 3, or 5.
             *
             * Example Input:
             *   Enter a number: 30
             * Example Output:
             *   The number is divisible by 2, 3, and 5.
             */
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            bool divisibleBy2 = number % 2 == 0;
            bool divisibleBy3 = number % 3 == 0;
            bool divisibleBy5 = number % 5 == 0;
            if (divisibleBy2 && divisibleBy3 && divisibleBy5)
                Console.WriteLine("The number is divisible by 2, 3, and 5.");
            else if (divisibleBy2 && divisibleBy3)
                Console.WriteLine("The number is divisible by 2 and 3.");
            else if (divisibleBy2 && divisibleBy5)
                Console.WriteLine("The number is divisible by 2 and 5.");
            else if (divisibleBy3 && divisibleBy5)
                Console.WriteLine("The number is divisible by 3 and 5.");
            else if (divisibleBy2)
                Console.WriteLine("The number is divisible by 2.");
            else if (divisibleBy3)
                Console.WriteLine("The number is divisible by 3.");
            else if (divisibleBy5)
                Console.WriteLine("The number is divisible by 5.");
            else
                Console.WriteLine("The number is not divisible by 2, 3, or 5.");
            Console.WriteLine();

            // --- Task 9: Ticket Price Based on Age ---
            /*
             * Description:
             * Write a program that calculates the ticket price based on age:
             * - 0-3 years: Free
             * - 4-12 years: $10
             * - 13-59 years: $20
             * - 60+ years: $15
             *
             * Example Input:
             *   Enter your age: 30
             * Example Output:
             *   The ticket price is $20.
             */
            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine());
            int ticketPrice;
            if (age <= 3)
                ticketPrice = 0;
            else if (age <= 12)
                ticketPrice = 10;
            else if (age <= 59)
                ticketPrice = 20;
            else
                ticketPrice = 15;
            Console.WriteLine(ticketPrice == 0 ? "The ticket is free." : $"The ticket price is ${ticketPrice}.");
            Console.WriteLine();

            // --- Task 10: Determine Passing Grade ---
            /*
             * Description:
             * Write a program that takes a student's grade as input and determines if they have passed.
             * A grade of 50 or higher is a passing grade, while below 50 is a failing grade.
             *
             * Example Input:
             *   Enter your grade: 65
             * Example Output:
             *   You passed!
             *
             * Example Input:
             *   Enter your grade: 45
             * Example Output:
             *   You failed.
             */
            Console.Write("Enter your grade: ");
            int grade = int.Parse(Console.ReadLine());
            if (grade >= 50)
                Console.WriteLine("You passed!");
            else
                Console.WriteLine("You failed.");
            Console.WriteLine();
        }
    }
}

