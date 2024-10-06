namespace DataTypes.ValueTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Integer Types
            int intVal = 100;           // 32-bit signed integer
            short shortVal = -3000;      // 16-bit signed integer
            long longVal = 10000000000L; // 64-bit signed integer
            byte byteVal = 255;          // 8-bit unsigned integer
            Console.WriteLine("Integer Types:");
            Console.WriteLine("int: " + intVal);
            Console.WriteLine("short: " + shortVal);
            Console.WriteLine("long: " + longVal);
            Console.WriteLine("byte: " + byteVal);
            Console.WriteLine();

            // Floating-Point Types
            float floatVal = 3.14f;      // 32-bit floating-point
            double doubleVal = 3.14159265358979; // 64-bit floating-point
            decimal decimalVal = 12345.6789m;    // 128-bit decimal
            Console.WriteLine("Floating-Point Types:");
            Console.WriteLine("float: " + floatVal);
            Console.WriteLine("double: " + doubleVal);
            Console.WriteLine("decimal: " + decimalVal);
            Console.WriteLine();

            // Boolean Type
            bool isTrue = true;          // Boolean value
            bool isFalse = false;
            Console.WriteLine("Boolean Types:");
            Console.WriteLine("true: " + isTrue);
            Console.WriteLine("false: " + isFalse);
            Console.WriteLine();

            // Character Type
            char letter = 'A';           // Single character
            char symbol = '#';
            Console.WriteLine("Character Type:");
            Console.WriteLine("Character: " + letter);
            Console.WriteLine("Symbol: " + symbol);
            Console.WriteLine();

            // Struct Example: Point
            Point p1 = new Point(5, 10);
            Console.WriteLine("Struct Example (Point):");
            Console.WriteLine("Point X: " + p1.X + ", Y: " + p1.Y);
            Console.WriteLine();

            // Enum Example: Weekdays
            Weekdays today = Weekdays.Monday;
            Console.WriteLine("Enum Example:");
            Console.WriteLine("Today is: " + today);
            Console.WriteLine("Numeric value of today: " + (int)today); // Enum as integer
            Console.WriteLine();

            // Nullable Type
            int? nullableInt = null;     // Nullable integer
            Console.WriteLine("Nullable Type:");
            Console.WriteLine("Nullable int: " + nullableInt);

            nullableInt = 10;            // Assigning a value
            Console.WriteLine("Nullable int after assignment: " + nullableInt);
            Console.WriteLine();

            // Boxing and Unboxing
            int num = 100;               // Value type
            object obj = num;            // Boxing
            Console.WriteLine("Boxing and Unboxing:");
            Console.WriteLine("Boxed value: " + obj);

            int unboxedNum = (int)obj;   // Unboxing
            Console.WriteLine("Unboxed value: " + unboxedNum);
            Console.WriteLine();

            // Min/Max Values for Value Types
            Console.WriteLine("Min/Max Values:");
            Console.WriteLine("int Max: " + int.MaxValue);
            Console.WriteLine("int Min: " + int.MinValue);
            Console.WriteLine("short Max: " + short.MaxValue);
            Console.WriteLine("short Min: " + short.MinValue);
            Console.WriteLine("long Max: " + long.MaxValue);
            Console.WriteLine("long Min: " + long.MinValue);
            Console.WriteLine("byte Max: " + byte.MaxValue);
            Console.WriteLine("byte Min: " + byte.MinValue);
        }
    }

    // Struct Definition
    struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    // Enum Definition
    enum Weekdays
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

}
