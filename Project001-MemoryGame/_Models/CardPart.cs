namespace Project001;

public enum CardDirection
{
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight
}

public class CardPart : Sprite
{
    private readonly Vector2 _direction;
    public float Lifespan { get; private set; }
    private readonly Rectangle _rectangle;
    private const float _lifespan = 0.5f;
    private float _scale = 1f;
    private readonly float _speed = 175f;
    private float _rotation;

    public CardPart(Texture2D tex, CardDirection dir, Vector2 pos) : base(tex, pos)
    {
        origin /= 2;
        var w = tex.Width / 2;
        var h = tex.Height / 2;

        switch (dir)
        {
            case CardDirection.TopLeft:
                _direction = new(-1, -1);
                _rectangle = new(0, 0, w, h);
                break;
            case CardDirection.TopRight:
                _direction = new(1, -1);
                _rectangle = new(w, 0, w, h);
                break;
            case CardDirection.BottomLeft:
                _direction = new(-1, 1);
                _rectangle = new(0, w, w, h);
                break;
            case CardDirection.BottomRight:
                _direction = new(1, 1);
                _rectangle = new(w, h, w, h);
                break;
        }

        Vector2 shift = new(w / 2, h / 2);
        Position += _direction * shift;
        Lifespan = _lifespan;
    }

    public void Update()
    {
        Lifespan -= Globals.Time;
        _scale = Lifespan / _lifespan;
        Position += _direction * _speed * _scale * Globals.Time;
        _rotation += 10f * Globals.Time;
    }

    public override void Draw()
    {
        Globals.SpriteBatch.Draw(Texture, Position, _rectangle, Color.White * _scale, _rotation, origin, _scale, SpriteEffects.None, 1f);
    }
}
