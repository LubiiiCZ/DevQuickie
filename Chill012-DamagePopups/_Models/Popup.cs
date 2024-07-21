namespace Chill012;

public class Popup
{
    private static SpriteFont _font;
    private Vector2 _position;
    private int _damage;
    private Color _color;
    private float _rotation;
    private Vector2 _origin;
    private Vector2 _direction;
    private float _scale;
    private float _speed;
    public float Lifespan { get; private set; }
    private const float LIFESPAN = 1f;

    public Popup(Vector2 position, int damage, Color color)
    {
        _font ??= Globals.Content.Load<SpriteFont>("font");

        _position = position;
        _damage = damage;
        _color = color;
        _scale = 1f;
        Lifespan = LIFESPAN;
        _speed = 150f;

        _direction = new((float)Globals.R.NextDouble() - 0.5f, -1f);
        _rotation = 0f; //MathF.Atan2(_direction.Y, _direction.X) + MathF.PI/2;

        _origin = _font.MeasureString(_damage.ToString()) / 2;
    }

    public void Update()
    {
        Lifespan -= Globals.Time;
        _scale = Lifespan / LIFESPAN;
        _position += _direction * _speed * Globals.Time;

        _position = new(_position.X + MathF.Sin(Lifespan * 10), _position.Y);
    }

    public void Draw()
    {
        Globals.SpriteBatch.DrawString(_font, _damage.ToString(), _position, _color * _scale, _rotation, _origin, _scale, SpriteEffects.None, 1f);
    }
}
