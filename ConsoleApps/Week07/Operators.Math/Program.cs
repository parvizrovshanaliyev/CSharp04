using System;

namespace Operators.Math
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Example 1: Addition
            int a = 5;
            int b = 3;
            int sum = a + b;
            Console.WriteLine($"Addition: {a} + {b} = {sum}");

            // Example 2: Subtraction
            int difference = a - b;
            Console.WriteLine($"Subtraction: {a} - {b} = {difference}");

            // Example 3: Multiplication
            int product = a * b;
            Console.WriteLine($"Multiplication: {a} * {b} = {product}");

            // Example 4: Division
            int quotient = a / b;
            Console.WriteLine($"Division: {a} / {b} = {quotient}");

            // Example 5: Modulus
            int remainder = a % b;
            Console.WriteLine($"Modulus: {a} % {b} = {remainder}");

            // Example 6: Increment
            int increment = a;
            increment++;
            Console.WriteLine($"Increment: {a}++ = {increment}");

            // Example 7: Decrement
            int decrement = a;
            decrement--;
            Console.WriteLine($"Decrement: {a}-- = {decrement}");

            // Example 8: Power
            double power = System.Math.Pow(a, b);
            Console.WriteLine($"Power: {a} ^ {b} = {power}");

            // Example 9: Square Root
            double squareRoot = System.Math.Sqrt(a);
            Console.WriteLine($"Square Root: √{a} = {squareRoot}");

            // Example 10: Absolute Value
            int negative = -a;
            int absoluteValue = System.Math.Abs(negative);
            Console.WriteLine($"Absolute Value: |{-a}| = {absoluteValue}");

            // Example 11: Trigonometric Functions
            // Define an angle in degrees
            double angle = 45.0;

            // Convert the angle from degrees to radians
            double radians = angle * (System.Math.PI / 180); // 1 degree = π/180 radians

            // Calculate the sine of the angle
            double sine = System.Math.Sin(radians);

            // Calculate the cosine of the angle
            double cosine = System.Math.Cos(radians);

            // Calculate the tangent of the angle
            double tangent = System.Math.Tan(radians);

            // Output the results
            Console.WriteLine($"Trigonometric Functions for {angle} degrees:");
            Console.WriteLine($"Sine: sin({angle}) = {sine}");
            Console.WriteLine($"Cosine: cos({angle}) = {cosine}");
            Console.WriteLine($"Tangent: tan({angle}) = {tangent}");
        }
    }
}