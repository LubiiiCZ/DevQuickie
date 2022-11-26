namespace Special001;

public static class Question8
{
    public struct Data
    {
        public int x;
        public int y;
    }

    public static void Print()
    {
        Data a = new()
        {
            x = 3,
            y = 5
        };

        Data b = a;
        b.y = 1;

        Console.WriteLine(a.y);
    }
}
