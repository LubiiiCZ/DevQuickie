namespace Challenge007;

public class Frog(Rectangle r)
{
    public Rectangle R = r;
    private int _speed = 500;
    private Point _destination = r.Location;
    private Vector2 _direction = Vector2.Zero;
    public bool Moving;
    public bool OnLog;
    public Thing Log;

    public void UpdateControls()
    {
        var ks = Keyboard.GetState();

        if (ks.IsKeyDown(Keys.Up))
        {
            _destination.Y = R.Top - Globals.TileSize;
            _direction = new(0, -1);
        }
        else if (ks.IsKeyDown(Keys.Down))
        {
            _destination.Y = R.Top + Globals.TileSize;
            _direction = new(0, 1);
        }
        else if (ks.IsKeyDown(Keys.Left))
        {
            _destination.X = R.Left - Globals.TileSize;
            _direction = new(-1, 0);
        }
        else if (ks.IsKeyDown(Keys.Right))
        {
            _destination.X = R.Left + Globals.TileSize;
            _direction = new(1, 0);
        }

        if (_direction != Vector2.Zero)
        {
            Moving = true;
            Log = null;
            OnLog = false;
        }
    }

    public void UpdateMovement()
    {
        if (_destination != R.Location)
        {
            var travelDistance = _direction * Globals.Time * _speed;
            R.Location = new(R.Location.X + (int)travelDistance.X, R.Location.Y + (int)travelDistance.Y);
        }

        if (_direction.X == 0 && _direction.Y == -1 && R.Location.Y < _destination.Y) R.Location = _destination;
        if (_direction.X == 0 && _direction.Y == 1 && R.Location.Y > _destination.Y) R.Location = _destination;
        if (_direction.X == -1 && _direction.Y == 0 && R.Location.X < _destination.X) R.Location = _destination;
        if (_direction.X == 1 && _direction.Y == 0 && R.Location.X > _destination.X) R.Location = _destination;

        if (_destination == R.Location)
        {
            _direction = Vector2.Zero;
            Moving = false;
        }

        if (OnLog)
        {
            var travelDistance = Log.Direction * Globals.Time * Log.Speed;
            R.Location = new(R.Location.X + (int)travelDistance.X, R.Location.Y + (int)travelDistance.Y);
            _destination = R.Location;
        }
    }

    public void Update()
    {
        if (!Moving) UpdateControls();
        UpdateMovement();
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(Globals.Texture, R, Color.Green);
    }
}
