namespace Project001;

public class Card : Sprite
{
    private readonly Texture2D _back;
    private readonly Texture2D _front;
    public bool Flipped { get; private set; }
    public Rectangle CardRectangle => new((int)(Position.X - origin.X), (int)(Position.Y - origin.Y),
                                          Texture.Width, Texture.Height);
    public int Id { get; }
    public bool Visible { get; set; }
    private readonly float _flipTime;
    private float _flipTimeLeft;
    public bool Flipping { get; private set; }
    private int _flippingDir;

    public Card(int id, Texture2D back, Texture2D front, Vector2 position) : base(back, position)
    {
        Id = id;
        _back = back;
        _front = front;
        _flipTime = 0.1f;
        Reset();
    }

    public void Reset()
    {
        Texture = _back;
        Visible = true;
        Flipped = false;
        Flipping = false;
        scale = Vector2.One;
        _flippingDir = -1;
        _flipTimeLeft = _flipTime;
    }

    public void Flip()
    {
        Flipping = true;
        Flipped = !Flipped;
        _flippingDir = -1;
        _flipTimeLeft = _flipTime;
        SoundManager.PlayFlipFx();
    }

    public void Update()
    {
        if (Flipping)
        {
            _flipTimeLeft += Globals.Time * _flippingDir;
            scale.X = _flipTimeLeft / _flipTime;

            if (_flipTimeLeft <= 0)
            {
                _flippingDir = 1;
                Texture = Flipped ? _front : _back;
            }
            else if (_flipTimeLeft > _flipTime)
            {
                _flippingDir = -1;
                Flipping = false;
                scale = Vector2.One;
            }
        }
    }

    public override void Draw()
    {
        if (Visible) base.Draw();
    }
}
