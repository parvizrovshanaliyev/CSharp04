using System;

namespace Operators.Math
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //C# Arithmetic Operators
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
            increment++;  // a= a + 1;
            Console.WriteLine($"Increment: {a}++ = {increment}");

            int aa = 5;
            ++aa;  // a= a + 1;
            Console.WriteLine($"Increment: ++{aa} = {increment}");

            // Example 7: Decrement
            int decrement = a;
            decrement--; // a = a-1;
            Console.WriteLine($"Decrement: {a}-- = {decrement}");
            --decrement; // a = a-1;
            Console.WriteLine($"Decrement: --{a} = {decrement}");

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


            //C# Assignment Operators-------------------------------------

            // 1. Basic Assignment Operator
            int a1 = 5;  // Assigns 5 to a
            Console.WriteLine($"a = {a1}"); // Output: a = 5

            // 2. Addition Assignment Operator
            int b1 = 10;
            b += 5;  // Equivalent to b = b + 5
            Console.WriteLine($"b += 5 -> b = {b1}"); // Output: b = 15

            // 3. Subtraction Assignment Operator
            int c = 10;
            c -= 3;  // Equivalent to c = c - 3
            Console.WriteLine($"c -= 3 -> c = {c}"); // Output: c = 7

            // 4. Multiplication Assignment Operator
            int d = 4;
            d *= 3;  // Equivalent to d = d * 3
            Console.WriteLine($"d *= 3 -> d = {d}"); // Output: d = 12

            // 5. Division Assignment Operator
            int e = 20;
            e /= 5;  // Equivalent to e = e / 5
            Console.WriteLine($"e /= 5 -> e = {e}"); // Output: e = 4

            // 6. Modulus Assignment Operator
            int f = 10;
            f %= 3;  // Equivalent to f = f % 3
            Console.WriteLine($"f %= 3 -> f = {f}"); // Output: f = 1

            // 7. Bitwise AND Assignment Operator
            int g = 6;  // Binary: 110  6/2 - 110
            g &= 3;     // Equivalent to g = g & 3; Binary: 110 & 011 = 010  -> 2^0 * 0,
            Console.WriteLine($"g &= 3 -> g = {g}"); // Output: g = 2

            // 8. Bitwise OR Assignment Operator
            int h = 6;  // Binary: 110
            h |= 3;     // Equivalent to h = h | 3; Binary: 110 | 011 = 111
            Console.WriteLine($"h |= 3 -> h = {h}"); // Output: h = 7

            // 9. Bitwise XOR Assignment Operator
            int i = 6;  // Binary: 110
            i ^= 3;     // Equivalent to i = i ^ 3; Binary: 110 ^ 011 = 101
            Console.WriteLine($"i ^= 3 -> i = {i}"); // Output: i = 5

            // 10. Left Shift Assignment Operator
            int j = 3;  // Binary: 0000 0011
            j <<= 1;    // Equivalent to j = j << 1; Binary shift: 0000 0110
            Console.WriteLine($"j <<= 1 -> j = {j}"); // Output: j = 6

            // 11. Right Shift Assignment Operator
            int k = 6;  // Binary: 0000 0110
            k >>= 1;    // Equivalent to k = k >> 1; Binary shift: 0000 0011
            Console.WriteLine($"k >>= 1 -> k = {k}"); // Output: k = 3


            // C# Comparison Operators
            int a2 = 5;
            int b2 = 10;
            int c2 = 5;

            // Equal to
            Console.WriteLine($"a == b: {a2 == b2}"); // Output: False
            Console.WriteLine($"a == c: {a2 == c2}"); // Output: True

            // Not equal to
            Console.WriteLine($"a != b: {a2 != b2}"); // Output: True
            Console.WriteLine($"a != c: {a2 != c2}"); // Output: False

            // Greater than
            Console.WriteLine($"b > a: {b2 > a2}");   // Output: True
            Console.WriteLine($"a > b: {a2 > b2}");   // Output: False

            // Less than
            Console.WriteLine($"a < b: {a2 < b2}");   // Output: True
            Console.WriteLine($"b < a: {b2 < a2}");   // Output: False

            // Greater than or equal to
            Console.WriteLine($"a >= c: {a2 >= c2}"); // Output: True
            Console.WriteLine($"b >= a: {b2 >= a2}"); // Output: True

            // Less than or equal to
            Console.WriteLine($"a <= b: {a2 <= b2}"); // Output: True
            Console.WriteLine($"b <= a: {b2 <= a2}"); // Output: False


            // C# Logical Operators

            bool a3 = true;
            bool b3 = false;
            bool c3 = true;

            // Logical AND
            Console.WriteLine($"a && b: {a3 && b3}"); // Output: False
            Console.WriteLine($"a && c: {a3 && c3}"); // Output: True

            // Logical OR
            Console.WriteLine($"a || b: {a3 || b3}"); // Output: True
            Console.WriteLine($"b || b: {b3 || b3}"); // Output: False

            // Logical NOT
            Console.WriteLine($"!a: {!a3}");         // Output: False
            Console.WriteLine($"!b: {!b3}");         // Output: True

            // Logical XOR (Exclusive OR)
            Console.WriteLine($"a ^ b: {a3 ^ b3}");   // Output: True
            Console.WriteLine($"a ^ c: {a3 ^ c3}");   // Output: False


            int age = 25;
            int income = 30000;

            // Logical AND: Check if a person is eligible for a loan
            if (age >= 18 && income >= 20000)
            {
                Console.WriteLine("Eligible for loan");
            }
            else
            {
                Console.WriteLine("Not eligible for loan");
            }

            // Logical OR: Check if a person is eligible for a discount (either based on age or income)
            if (age < 18 || age > 65 || income < 15000)
            {
                Console.WriteLine("Eligible for discount");
            }
            else
            {
                Console.WriteLine("Not eligible for discount");
            }

            // Logical NOT: Checking if a person is not a minor
            bool isMinor = age < 18;
            if (!isMinor)
            {
                Console.WriteLine("Not a minor");
            }

            // Logical XOR: Checking if exactly one of two conditions is true
            bool hasLicense = true;
            bool hasCar = false;

            if (hasLicense ^ hasCar)
            {
                Console.WriteLine("Needs to get either a car or a license.");
            }
            else
            {
                Console.WriteLine("Either has both or neither.");
            }


            int day = 4;

            if (day == 1)
            {
                Console.WriteLine("Monday");
            }else if (day == 2)
            {
                Console.WriteLine("Tuesday");
            }
            else if (day == 2)
            {
                Console.WriteLine("Tuesday");
            }
            else if (day == 2)
            {
                Console.WriteLine("Tuesday");
            }
            else if (day == 2)
            {
                Console.WriteLine("Tuesday");
            }
            else if (day == 2)
            {
                Console.WriteLine("Tuesday");
            }




            switch (day)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;

                default:
                    Console.WriteLine("invalid");
                    break;
            }
        }
    }
}