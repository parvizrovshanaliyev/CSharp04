using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes.ValueTypes
{
    internal class ValueTypesPractices
    {
        public void Practice()
        {
            /*
                     Task 1: Basic Integer Operations
                     - Declare integer variables (int, short, long, byte).
                     - Perform basic arithmetic operations.
                     - Expected: Students should understand how to handle integer types and observe overflow behavior.
                    */
            Console.WriteLine("Task 1: Basic Integer Operations");
            int num1 = 100;
            short num2 = 50;
            long num3 = num1 * num2;
            byte num4 = 255;
            Console.WriteLine($"int: {num1}, short: {num2}, long: {num3}, byte: {num4}");
            Console.WriteLine();

            /*
             Task 2: Floating-Point Arithmetic
             - Declare float, double, and decimal types.
             - Perform arithmetic with these types and observe the differences in precision.
             - Expected: Students should understand the use of floating-point numbers and precision differences.
            */
            Console.WriteLine("Task 2: Floating-Point Arithmetic");
            float piFloat = 3.14f;
            double piDouble = 3.14159265359;
            decimal piDecimal = 3.14159265358979323846m;
            Console.WriteLine($"float: {piFloat}, double: {piDouble}, decimal: {piDecimal}");
            Console.WriteLine();

            /*
             Task 3: Boolean Expressions
             - Use boolean logic with comparison and logical operators.
             - Perform conditional checks and combine multiple conditions.
             - Expected: Students should be able to use logical operators and understand how conditions are evaluated.
            */
            Console.WriteLine("Task 3: Boolean Expressions");
            int x = 10;
            int y = 20;
            bool isXGreater = x > y;
            bool bothConditions = (x > 5) && (y < 30);
            Console.WriteLine($"isXGreater: {isXGreater}, bothConditions: {bothConditions}");
            Console.WriteLine();

            /*
             Task 4: Character Handling
             - Declare a char variable and print its Unicode value.
             - Prompt the user to input a character and determine if it is a vowel or consonant.
             - Expected: Students should learn how to handle char type and work with user input.
            */
            Console.WriteLine("Task 4: Character Handling");
            char letter = 'A';
            Console.WriteLine($"Character: {letter}, Unicode value: {Convert.ToInt32(letter)}");
            Console.WriteLine("Enter a letter: ");
            char userInput = Console.ReadKey().KeyChar;
            Console.WriteLine($"\nYou entered: {userInput}");
            Console.WriteLine();

            /*
             Task 5: Create and Use Structs
             - Define a struct Rectangle with Length and Width fields.
             - Write a method to calculate the area of the rectangle.
             - Expected: Students should understand how to create and use structs to represent data.
            */
            Console.WriteLine("Task 5: Create and Use Structs");
            Rectangle rect = new Rectangle { Length = 5, Width = 10 };
            Console.WriteLine($"Rectangle Area: {rect.Area()}");
            Console.WriteLine();

            /*
             Task 6: Working with Enums
             - Define an enum for days of the week.
             - Write code to take a user input number and display the corresponding day of the week.
             - Expected: Students should know how to define and use enums and work with user input.
            */
            Console.WriteLine("Task 6: Working with Enums");
            Console.WriteLine("Enter a number (1-7) for the day of the week: ");
            int dayNumber = int.Parse(Console.ReadLine());
            if (dayNumber >= 1 && dayNumber <= 7)
            {
                Days day = (Days)dayNumber;
                Console.WriteLine($"Day of the week is: {day}");
            }
            else
            {
                Console.WriteLine("Invalid number. Please enter a value between 1 and 7.");
            }
            Console.WriteLine();

            /*
             Task 7: Nullable Types
             - Use nullable int and demonstrate how to check for null values.
             - Assign a value to the nullable type and print it.
             - Expected: Students should understand nullable types and how to work with them.
            */
            Console.WriteLine("Task 7: Nullable Types");
            int? nullableInt = null;
            Console.WriteLine($"Nullable int: {nullableInt}");
            nullableInt = 10;
            Console.WriteLine($"Nullable int after assignment: {nullableInt}");
            Console.WriteLine();

            /*
             Task 8: Boxing and Unboxing
             - Box an integer into an object and unbox it back to an integer.
             - Demonstrate what happens when unboxing goes wrong (optional for advanced students).
             - Expected: Students should understand the concepts of boxing and unboxing and how value types are handled in memory.
            */
            Console.WriteLine("Task 8: Boxing and Unboxing");
            int num = 123;
            object obj = num;  // Boxing
            int unboxedNum = (int)obj;  // Unboxing
            Console.WriteLine($"Boxed value: {obj}, Unboxed value: {unboxedNum}");
            Console.WriteLine();

            /*
             Task 9: Min/Max Value Limits
             - Display the minimum and maximum values of various integer types.
             - Explore what happens when you exceed these limits.
             - Expected: Students should learn how to use MaxValue and MinValue properties and understand overflow conditions.
            */
            Console.WriteLine("Task 9: Min/Max Value Limits");
            Console.WriteLine($"int Max: {int.MaxValue}, int Min: {int.MinValue}");
            Console.WriteLine($"short Max: {short.MaxValue}, short Min: {short.MinValue}");
            Console.WriteLine($"long Max: {long.MaxValue}, long Min: {long.MinValue}");
            Console.WriteLine($"byte Max: {byte.MaxValue}, byte Min: {byte.MinValue}");
            Console.WriteLine();

            /*
             Task 10: Arithmetic with Different Types
             - Perform arithmetic operations between different numeric types (int, float, double).
             - Use implicit conversion and cast where necessary.
             - Expected: Students should understand type conversion and how arithmetic is handled between different types.
            */
            Console.WriteLine("Task 10: Arithmetic with Different Types");
            int intVal = 10;
            float floatVal = 5.5f;
            double doubleVal = 2.5;
            float result1 = intVal + floatVal;  // Implicit conversion from int to float
            double result2 = floatVal + doubleVal;  // Implicit conversion from float to double
            Console.WriteLine($"int + float = {result1}, float + double = {result2}");
            Console.WriteLine();

            /*
             Task 11: User-Defined Enum with Structs
             - Create an enum TrafficLight with Red, Yellow, and Green values.
             - Define a struct TrafficSignal with a method to return the action for each light.
             - Expected: Students should combine enums and structs to represent real-world scenarios.
            */
            Console.WriteLine("Task 11: User-Defined Enum with Structs");
            TrafficSignal signal = new TrafficSignal { Signal = TrafficLight.Red };
            Console.WriteLine($"Signal: {signal.Signal}, Action: {signal.GetAction()}");
        }
    }

    // Struct Definition for Task 5
    struct Rectangle
    {
        public int Length;
        public int Width;

        public int Area()
        {
            return Length * Width;
        }
    }

    // Enum Definition for Task 6
    enum Days
    {
        Sunday = 1,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    // Enum and Struct for Task 11
    enum TrafficLight
    {
        Red,
        Yellow,
        Green
    }

    struct TrafficSignal
    {
        public TrafficLight Signal;

        public string GetAction()
        {
            switch (Signal)
            {
                case TrafficLight.Red:
                    return "Stop";
                case TrafficLight.Yellow:
                    return "Slow down";
                case TrafficLight.Green:
                    return "Go";
                default:
                    return "Unknown signal";
            }
        }
    }