namespace Project004;

public class Die(DieTypes type)
{
    private readonly Icons[] _sides = type switch
    {
        DieTypes.Green => [Icons.Brain, Icons.Brain, Icons.Brain, Icons.Blast, Icons.Feet, Icons.Feet,],
        DieTypes.Yellow => [Icons.Brain, Icons.Brain, Icons.Blast, Icons.Blast, Icons.Feet, Icons.Feet,],
        DieTypes.Red => [Icons.Brain, Icons.Blast, Icons.Blast, Icons.Blast, Icons.Feet, Icons.Feet,],
        _ => [Icons.Brain, Icons.Brain, Icons.Brain, Icons.Blast, Icons.Feet, Icons.Feet,],
    };

    public static readonly Dictionary<Icons, Texture2D> Textures = [];
    private static readonly Random _random = new();
    public Icons ActiveSide = Icons.Brain;
    public Vector2 Position = Vector2.Zero;
    public Color color = type switch
    {
        DieTypes.Green => Color.Green,
        DieTypes.Yellow => Color.Yellow,
        DieTypes.Red => Color.Red,
        _ => Color.Green,
    };
    public bool used;

    public static void Load()
    {
        Textures.Add(Icons.Brain, Globals.Content.Load<Texture2D>("brain"));
        Textures.Add(Icons.Blast, Globals.Content.Load<Texture2D>("blast"));
        Textures.Add(Icons.Feet, Globals.Content.Load<Texture2D>("feet"));
    }

    public void Roll()
    {
        var x = _random.Next(0, 6);
        ActiveSide = _sides[x];
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(Textures[ActiveSide], Position, color);
    }
}
