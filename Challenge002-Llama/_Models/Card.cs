namespace Challenge002;

public class Card(Values value, Texture2D texture)
{
    private Texture2D _texture = texture;
    public Values Value { get; } = value;
    public Vector2 Position { get; set; }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, Position, Color.White);
    }
}
