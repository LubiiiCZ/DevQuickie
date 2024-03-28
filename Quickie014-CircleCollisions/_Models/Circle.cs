namespace Quickie014;

public class Circle(Texture2D tex)
{
    private static readonly Random _r = new();
    private readonly Texture2D _texture = tex;
    public Vector2 Origin { get; } = new(tex.Width / 2, tex.Height / 2);
    public Vector2 Position { get; set; } = RandomPosition();
    public Vector2 Direction { get; set; } = RandomDirection();
    public int Speed { get; set; } = 200;
    public Color Color { get; set; } = Color.White;

    private static Vector2 RandomPosition()
    {
        const int padding = 50;
        var x = _r.Next(padding, Globals.Bounds.X - padding);
        var y = _r.Next(padding, Globals.Bounds.Y - padding);
        return new(x, y);
    }

    private static Vector2 RandomDirection()
    {
        var angle = _r.NextDouble() * 2 * Math.PI;
        return new((float)Math.Sin(angle), -(float)Math.Cos(angle));
    }

    public void Update()
    {
        Position += Direction * Speed * Globals.TotalSeconds;
        if (Position.X < Origin.X || Position.X > Globals.Bounds.X - Origin.X) Direction = new(-Direction.X, Direction.Y);
        if (Position.Y < Origin.Y || Position.Y > Globals.Bounds.Y - Origin.Y) Direction = new(Direction.X, -Direction.Y);
        Position = new(MathHelper.Clamp(Position.X, Origin.X, Globals.Bounds.X - Origin.X),
                       MathHelper.Clamp(Position.Y, Origin.Y, Globals.Bounds.Y - Origin.Y));
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, Position, null, Color, 0, Origin, 1, SpriteEffects.None, 1);
    }
}
