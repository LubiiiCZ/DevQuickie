namespace Project001;

public class Card
{
    private readonly Texture2D _back;
    private readonly Texture2D _front;
    public Vector2 Position { get; set; }
    private bool _flipped;
    private Texture2D _activeTexture;
    public Rectangle CardRectangle => new((int)Position.X, (int)Position.Y, _activeTexture.Width, _activeTexture.Height);
    public int Id { get; }
    public bool Visible { get; set; }

    public Card(int id, Texture2D back, Texture2D front, Vector2 position)
    {
        Id = id;
        _back = back;
        _front = front;
        Position = position;
        _activeTexture = _back;
        Visible = true;
    }

    public bool IsFlipped()
    {
        return _flipped;
    }

    public void Flip()
    {
        _flipped = !_flipped;
        _activeTexture = _flipped ? _front : _back;
    }

    public void Draw()
    {
        if (Visible) Globals.SpriteBatch.Draw(_activeTexture, Position, Color.White);
    }
}
