namespace Project003;

public static class Extensions
{
    public static void Shuffle<T>(this List<T> list)
    {
        Random random = new();
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }
}
