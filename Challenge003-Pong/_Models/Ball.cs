namespace Challenge003;

public class Ball
{
    public Vector2 Position;
    public Rectangle Body { get; private set; }
    private float _speed = 400f;
    public Vector2 Direction;
    private const int HALF = 10;

    public Ball()
    {
        Reset();
    }

    public void Reset()
    {
        Random r = new();
        Position = new(Globals.WindowSize.X / 2, Globals.WindowSize.Y / 2);
        Direction = Vector2.Normalize(new(r.Next(2) == 0 ? 1 : -1, r.Next(2) == 0 ? 1 : -1));
        _speed = 400f;
    }

    public void Update()
    {
        _speed += Globals.Time * 25f;
        Position += Direction * _speed * Globals.Time;
        if (Position.Y - HALF < 0 || Position.Y + HALF > Globals.WindowSize.Y) Direction.Y *= -1;
        Body = new((int)Position.X - HALF, (int)Position.Y - HALF, 2 * HALF, 2 * HALF);
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(Globals.Texture, Body, Color.White);
    }
}
