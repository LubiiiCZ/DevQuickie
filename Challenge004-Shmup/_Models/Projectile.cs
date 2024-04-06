namespace Challenge004;

public class Projectile(Texture2D texture, Vector2 position, Vector2 direction, float speed)
{
    private readonly Texture2D _texture = texture;
    public Vector2 Position = position;
    private readonly float _speed = speed;
    private Vector2 _direction = direction;
    public Rectangle CollisionRectangle => new(Position.ToPoint(), _texture.Bounds.Size);

    public void Update()
    {
        Position += _direction * _speed * Globals.Time;
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, Position, Color.White);
    }
}
