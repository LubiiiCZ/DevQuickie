namespace Challenge002;

public class AIPlayer
{
    public List<Values> Hand { get; set; } = [];
    private readonly Texture2D _texture;
    private readonly Vector2 _position;

    public AIPlayer()
    {
        _texture = Globals.Content.Load<Texture2D>("0");
        _position = new(50, 150);
    }

    public void Reset()
    {
        Hand.Clear();
    }

    public void AddCard(Card card)
    {
        Hand.Add(card.Value);
    }

    public (bool, Values) PlayCard(Values current)
    {
        var currentValue = (int)current;

        foreach (var value in Hand.ToArray())
        {
            var cardValue = (int)value;

            if (cardValue == currentValue || cardValue == currentValue + 1 || (cardValue == 1 && currentValue == 7))
            {
                Hand.Remove(value);
                return (true, value);
            }
        }

        return (false, Values.Back);
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, _position, Color.White);
        FontWriter.DrawText(Hand.Count.ToString(), new(_position.X + 15, _position.Y - 60), Color.Black);
    }
}
