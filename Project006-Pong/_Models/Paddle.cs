namespace Project006;

public class Paddle(Vector2 position, Keys up, Keys down)
{
    public Vector2 Position = position;
    public Rectangle Body { get; private set; }
    private readonly float _speed = 500f;
    private readonly float _aiSpeed = 400f;
    private readonly Keys _up = up;
    private readonly Keys _down = down;
    public bool Ai;

    public void Update(Ball ball)
    {
        if (Ai)
        {
            if (ball.Position.Y < Position.Y) Position.Y -= _aiSpeed * Globals.Time;
            if (ball.Position.Y > Position.Y) Position.Y += _aiSpeed * Globals.Time;
        }
        else
        {
            if (InputManager.IsKeyDown(_up)) Position.Y -= _speed * Globals.Time;
            if (InputManager.IsKeyDown(_down)) Position.Y += _speed * Globals.Time;
        }

        Position.Y = MathHelper.Clamp(Position.Y, 0, Globals.WindowSize.Y);
        Body = new((int)Position.X - 5, (int)Position.Y - 50, 10, 100);
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(Globals.Texture, Body, Color.White);
    }
}
