namespace Project004;

public class Bag
{
    public readonly List<Die> Dice = [];
    private readonly Random _random = new();
    private readonly Texture2D _texture;

    public Bag()
    {
        _texture = Globals.Content.Load<Texture2D>("brain");
        Reset();
    }

    public void Reset()
    {
        Dice.Clear();

        DieTypes[] dice = [
            DieTypes.Green, DieTypes.Green, DieTypes.Green, DieTypes.Green, DieTypes.Green, DieTypes.Green,
            DieTypes.Yellow, DieTypes.Yellow, DieTypes.Yellow, DieTypes.Yellow,
            DieTypes.Red, DieTypes.Red, DieTypes.Red,
        ];

        foreach (var die in dice)
        {
            Dice.Add(new(die));
        }
    }

    public Die PickRandomly()
    {
        if (Dice.Count < 1) return null;

        var x = _random.Next(Dice.Count);
        var die = Dice[x];
        Dice.RemoveAt(x);
        return die;
    }

    public void Draw()
    {
        int x = 50;

        foreach (var die in Dice)
        {
            Globals.SpriteBatch.Draw(_texture, new Vector2(x, 100), null, die.color, 0f, Vector2.Zero, 0.25f, SpriteEffects.None, 1f);
            x += 40;
        }
    }
}
