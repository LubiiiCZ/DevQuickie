namespace Special001;

public static class Question5
{
    public static void Print()
    {
        //List<int> list;
        List<int> list = new();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        for (int i = list.Count - 1; i >= 0; i--)
        {
            Console.WriteLine(list[i]);
        }
    }
}
