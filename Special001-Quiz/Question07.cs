namespace Special001;

public static class Question7
{
    public static void Print()
    {
        string[] data = new string[] {"abc", "mno", "xyz"};
        Console.WriteLine(data[^1][..2]);
    }
}
