namespace Project001;

public class Card
{
    private readonly Texture2D _back;
    private readonly Texture2D _front;
    public Vector2 Position { get; set; }
    private bool _flipped;
    private Texture2D _activeTexture;

    public Card(Texture2D back, Texture2D front, Vector2 position)
    {
        _back = back;
        _front = front;
        Position = position;
        _activeTexture = _back;
        Flip();
    }

    public void Flip()
    {
        _flipped = !_flipped;
        _activeTexture = _flipped ? _front : _back;
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_activeTexture, Position, Color.White);
    }
}
