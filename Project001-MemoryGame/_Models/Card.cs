namespace Project001;

public class Card
{
    private readonly Texture2D _back;
    private readonly Texture2D _front;
    public Vector2 Position { get; set; }
    private Vector2 _origin;
    public bool Flipped { get; private set; }
    private Texture2D _activeTexture;
    public Rectangle CardRectangle => new((int)(Position.X - _origin.X), (int)(Position.Y - _origin.Y),
                                          _activeTexture.Width, _activeTexture.Height);
    public int Id { get; }
    public bool Visible { get; set; }
    private Vector2 _scale;
    private readonly float _flipTime;
    private float _flipTimeLeft;
    public bool Flipping { get; private set; }
    private int _flippingDir;

    public Card(int id, Texture2D back, Texture2D front, Vector2 position)
    {
        Id = id;
        _back = back;
        _front = front;
        Position = position;
        _origin = new(back.Width / 2, back.Height / 2);
        _flipTime = 0.1f;
        Reset();
    }

    public void Reset()
    {
        _activeTexture = _back;
        Visible = true;
        Flipped = false;
        Flipping = false;
        _scale = Vector2.One;
        _flippingDir = -1;
        _flipTimeLeft = _flipTime;
    }

    public void Flip()
    {
        Flipping = true;
        Flipped = !Flipped;
        _flippingDir = -1;
        _flipTimeLeft = _flipTime;
    }

    public void Update()
    {
        if (Flipping)
        {
            _flipTimeLeft += Globals.Time * _flippingDir;
            _scale.X = _flipTimeLeft / _flipTime;

            if (_flipTimeLeft <= 0)
            {
                _flippingDir = 1;
                _activeTexture = Flipped ? _front : _back;
            }
            else if (_flipTimeLeft > _flipTime)
            {
                _flippingDir = -1;
                Flipping = false;
                _scale = Vector2.One;
            }
        }
    }

    public void Draw()
    {
        if (Visible) Globals.SpriteBatch.Draw(_activeTexture, Position, null, Color.White, 0f, _origin, _scale, SpriteEffects.None, 1f);
    }
}
