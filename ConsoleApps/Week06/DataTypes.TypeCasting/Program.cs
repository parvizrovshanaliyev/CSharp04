namespace DataTypes.TypeCasting;

public class Program
{
    public static void Main()
    {
        //C# Type Casting
        //Type casting is when you assign a value of one data type to another type.

        //    In C#, there are two types of casting:

        //Implicit Casting(automatically) -converting a smaller type to a larger type size
        //char -> int -> long -> float -> double

        //    Explicit Casting(manually) - converting a larger type to a smaller size type
        //double -> float -> long -> int -> char


        byte age = 24;  // 0-255

        int age2 = age; // 32 bit 

        long age3 = age2; // 64 bit


        double age4 = age3; // 128

        double doubleMaxValue = double.MaxValue;

        //float age5 = age4;

        // explicit casting 
        float age5 = (float)age4;

        float floatMaxValue = float.MaxValue;

        floatMaxValue = (float)doubleMaxValue;

        long age6 = age3;

        age6 = (long)floatMaxValue;


        double myDouble = 9.78;
        int myInt = (int)myDouble;  // Manual casting: double to int

        Console.WriteLine(myDouble);
        Console.WriteLine(myInt);


        //Type Conversion Methods
        //It is also possible to convert data types explicitly by using built-in methods,
        // such as
        // Convert.ToBoolean,
        // Convert.ToDouble,
        // Convert.ToString,
        // Convert.ToInt32(int)
        // and Convert.ToInt64(long):


        int myInt1 = 10;
        double myDouble1 = 5.25;
        bool myBool = true;

        Console.WriteLine(Convert.ToString(myInt));    // convert int to string
        Console.WriteLine(myInt);                      // .ToString()
        Console.WriteLine(Convert.ToDouble(myInt));    // convert int to double
        Console.WriteLine(Convert.ToInt32(myDouble));  // convert double to int
        Console.WriteLine(Convert.ToString(myBool));   // convert bool to string
    }
}
