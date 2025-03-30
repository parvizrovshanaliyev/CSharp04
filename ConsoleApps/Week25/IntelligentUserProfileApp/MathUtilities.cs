namespace IntelligentUserProfileApp;

public static class MathUtilities
{
    public static int Square(int number) => number * number;
    public static int Cube(int number) => number * number * number;

    public static long Factorial(int number)
    {
        if (number < 0) return -1;
        long result = 1;
        for (int i = 2; i <= number; i++)
        {
            result *= i;
        }
        return result;
    }
}