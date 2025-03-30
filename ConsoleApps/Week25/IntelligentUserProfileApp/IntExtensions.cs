namespace IntelligentUserProfileApp;

public static class IntExtensions
{
    public static bool IsEven(this int number) => number % 2 == 0;

    public static int NthFibonacci(this int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        int a = 0, b = 1;
        for (int i = 2; i <= n; i++)
        {
            (a, b) = (b, a + b);
        }
        return b;
    }
}