namespace Special001;

public static class Question9
{
    public static void Print()
    {
        int a, b;
        a = 7;
        b = a++;
        b += ++a;
        Console.WriteLine(a + b);
    }
}
