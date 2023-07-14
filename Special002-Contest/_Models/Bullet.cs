namespace Special002;

public class Bullet : Sprite
{
    private static readonly Random rand = new();
    private Vector2 _direction;
    private readonly int _speed;
    private readonly Trail _trail;

    private static Vector2 RandomPos()
    {
        const float w = Globals.SCREEN_WIDTH;
        const float h = Globals.SCREEN_HEIGHT;
        const int p = 0;
        Vector2 pos = new();

        if (rand.NextDouble() <  w / (w + h))
        {
            pos.X = (int)(rand.NextDouble() * w);
            pos.Y = (int)(rand.NextDouble() < 0.5 ? -p : h + p);
        }
        else
        {
            pos.Y = (int)(rand.NextDouble() * h);
            pos.X = (int)(rand.NextDouble() < 0.5 ? -p : w + p);
        }

        return pos;
    }

    public Bullet(Texture2D tex) : base(tex, new(0, 0))
    {
        position = RandomPos();
        rotation = MathHelper.ToRadians(rand.Next(0, 360));
         _direction = new((float)Math.Sin(rotation), (float)-Math.Cos(rotation));
        _speed = rand.Next(400, 601);
        _trail = new(Globals.Content.Load<Texture2D>("particle"), position);
    }

    public void Update()
    {
        position += _direction * _speed * Globals.Time;

        if (position.X + texture.Width < 0) position.X += Globals.SCREEN_WIDTH + (2 * texture.Width);
        if (position.Y + texture.Height < 0) position.Y += Globals.SCREEN_HEIGHT + (2 * texture.Height);
        if (position.X - texture.Width > Globals.SCREEN_WIDTH) position.X -= Globals.SCREEN_WIDTH + (2 * texture.Width);
        if (position.Y - texture.Height > Globals.SCREEN_HEIGHT) position.Y -= Globals.SCREEN_HEIGHT + (2 * texture.Height);

        _trail.Update(position);
    }

    public override void Draw()
    {
        _trail.Draw();
        base.Draw();
    }
}
