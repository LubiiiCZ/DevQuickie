namespace Special001;

public static class Question3
{
    public static void Print()
    {
        int x = 7;
        int y = 2;
        (x, y) = (y, x);
        Console.WriteLine(x - y);
    }
}
