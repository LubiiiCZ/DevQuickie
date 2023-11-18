namespace Project007;

public class Enemy(Texture2D texture)
{
    public Vector2 Position;
    private Vector2 _direction = Vector2.Zero;
    private Vector2 _destination;
    private readonly float _speed = 250f;
    private readonly Texture2D _texture = texture;
    private Rectangle _sourceRectangle;
    private float _shotCooldown = SHOT_COOLDOWN;
    private const float SHOT_COOLDOWN = 1f;
    private float _frameTime = 0.1f;
    private int _currentFrame; // 0 - 1 - 2 - 1 - ...
    private int _increment = 1;
    private readonly Point _frameSize = new(texture.Width / 3, texture.Height);
    public Rectangle CollisionRectangle => new(Position.ToPoint(), _frameSize);

    public void SetRandomDestination()
    {
        Random r = new();
        var x = r.Next(Globals.WindowSize.X - 48);
        var y = r.Next(Globals.WindowSize.Y - 48);
        _destination = new(x, y);

        _direction = _destination - Position;
        if (_direction != Vector2.Zero) _direction.Normalize();
    }

    private void UpdateAnimation()
    {
        _frameTime -= Globals.Time;
        if (_frameTime < 0)
        {
            _frameTime += 0.1f;
            _currentFrame += _increment;

            if (_currentFrame == 2) _increment = -1;
            if (_currentFrame == 0) _increment = 1;
        }
    }

    public void Update()
    {
        UpdateAnimation();
        UpdateRectangle();
        UpdatePosition();

        _shotCooldown -= Globals.Time;
        if (_shotCooldown < 0)
        {
            _shotCooldown += SHOT_COOLDOWN;
            ProjectileManager.AddEnemyProjectile(new(Position.X + 16, Position.Y + _frameSize.Y));
        }
    }

    private void UpdatePosition()
    {
        Position += _direction * _speed * Globals.Time;

        if (Vector2.Distance(Position, _destination) < 5f)
        {
            SetRandomDestination();
        }
    }

    private void UpdateRectangle()
    {
        Point location = new(_currentFrame * _frameSize.X, 0);
        _sourceRectangle = new(location, _frameSize);
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, Position, _sourceRectangle, Color.White);
    }
}
