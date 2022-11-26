namespace Special001;

public static class Question2
{
    public static void Print()
    {
        string s = string.Empty;
        s = s == null ? "GD" : "GameDev";
        s += "Quickie";
        s ??= "Special";
        Console.WriteLine(s);
    }
}
