namespace Project005;

public class Card
{
    private Texture2D _texture;
    public Values Value { get; }
    public Vector2 Position { get; set; }

    public Card(Values value, Texture2D texture)
    {
        Value = value;
        _texture = texture;
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, Position, Color.White);
    }
}
