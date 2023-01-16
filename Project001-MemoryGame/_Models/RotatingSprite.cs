namespace Project001;

public class RotatingSprite : Sprite
{
    private float _rotation;
    private Vector2 _direction;

    public RotatingSprite(Texture2D tex, Vector2 pos, Vector2 dir) : base(tex, pos)
    {
        var r = new Random();
        _direction = dir;
        _rotation = r.NextSingle() * 2 * (float)Math.PI;
    }

    public void Update()
    {
        _rotation += Globals.Time;
        Position += _direction * Globals.Time * 75;

        if (Position.X + origin.X < 0) Position = new(Globals.Bounds.X + origin.X, Position.Y);
        if (Position.X - origin.X > Globals.Bounds.X) Position = new(-origin.X, Position.Y);
        if (Position.Y + origin.Y < 0) Position = new(Position.X, Globals.Bounds.Y + origin.Y);
        if (Position.Y - origin.Y > Globals.Bounds.Y) Position = new(Position.X, -origin.Y);
    }

    public override void Draw()
    {
        Globals.SpriteBatch.Draw(Texture, Position, null, Color.White * 0.2f, _rotation, origin, Vector2.One, SpriteEffects.None, 1f);
    }
}
