namespace Challenge004;

public class Ship(Texture2D texture)
{
    public Vector2 Position = new(Globals.WindowSize.X / 2, Globals.WindowSize.Y - 100);
    private Vector2 _direction = Vector2.Zero;
    private readonly float _speed = 500f;
    private float _shotCooldown = SHOT_COOLDOWN;
    private const float SHOT_COOLDOWN = 0.25f;
    private readonly Texture2D _texture = texture;
    private Rectangle _sourceRectangle;
    private float _frameTime = 0.1f;
    private int _currentFrame; // 0 - 1 - 2 - 1 - ...
    private int _increment = 1;
    private readonly Point _frameSize = new(texture.Width / 3, texture.Height / 3);
    public Rectangle CollisionRectangle => new(Position.ToPoint(), _frameSize);

    public void Restart()
    {
        _shotCooldown = SHOT_COOLDOWN;
        Position = new(Globals.WindowSize.X / 2, Globals.WindowSize.Y - 100);
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
        UpdateControls();
        UpdateRectangle();
        UpdatePosition();

        _shotCooldown -= Globals.Time;
        if (_shotCooldown < 0)
        {
            _shotCooldown += SHOT_COOLDOWN;
            ProjectileManager.AddProjectile(new(Position.X + 20, Position.Y));
        }
    }

    private void UpdatePosition()
    {
        Position += _direction * _speed * Globals.Time;
        Position = Vector2.Clamp(Position, Vector2.Zero, new(Globals.WindowSize.X - _frameSize.X, Globals.WindowSize.Y - _frameSize.Y));
    }

    private void UpdateRectangle()
    {
        var row = 0;
        if (_direction.X > 0) row = 1;
        if (_direction.X < 0) row = 2;
        Point location = new(_currentFrame * _frameSize.X, row * _frameSize.Y);
        _sourceRectangle = new(location, _frameSize);
    }

    private void UpdateControls()
    {
        _direction = Vector2.Zero;

        if (InputManager.IsKeyDown(Keys.Left)) _direction.X = -1;
        if (InputManager.IsKeyDown(Keys.Right)) _direction.X = 1;
        if (InputManager.IsKeyDown(Keys.Up)) _direction.Y = -1;
        if (InputManager.IsKeyDown(Keys.Down)) _direction.Y = 1;

        if (_direction != Vector2.Zero) _direction.Normalize();
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, Position, _sourceRectangle, Color.White);
    }
}
