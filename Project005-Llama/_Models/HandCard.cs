namespace Project005;

public class HandCard : Clickable
{
    public int Count { get; set; } = 0;
    public Values Value { get; }
    private readonly Texture2D _texture;
    private readonly Vector2 _position;

    public HandCard(Values value, Texture2D texture, Vector2 position)
    {
        Value = value;
        _texture = texture;
        _position = position;
        RectangleArea = new(position.ToPoint(), new(_texture.Width, _texture.Height));
    }

    public void Draw()
    {
        if (Count > 0)
        {
            Globals.SpriteBatch.Draw(_texture, _position, Color.White);
            if (Count > 1)
            {
                FontWriter.DrawText(Count.ToString(), new(_position.X + 30, _position.Y - 60), Color.Black);
            }
        }
    }
}
