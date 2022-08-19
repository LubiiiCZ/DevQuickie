namespace Quickie008;

public class Bullet : Sprite
{
    private static readonly Random rand = new();
    private Vector2 _direction;
    private readonly int _speed;

    private static Vector2 RandomPos()
    {
        var x = rand.Next(0, Globals.SCREEN_WIDTH);
        var y = rand.Next(0, Globals.SCREEN_HEIGHT);
        return new(x, y);
    }

    public Bullet(Texture2D tex) : base(tex, RandomPos())
    {
        rotation = MathHelper.ToRadians(rand.Next(0, 360));
        _direction = new((float)Math.Sin(rotation), (float)-Math.Cos(rotation));
        _speed = 600;
    }

    public void Update()
    {
        position += _direction * _speed * Globals.BulletTime;

        if (position.X + texture.Width < 0) position.X += Globals.SCREEN_WIDTH + (2 * texture.Width);
        if (position.Y + texture.Height < 0) position.Y += Globals.SCREEN_HEIGHT + (2 * texture.Height);
        if (position.X - texture.Width > Globals.SCREEN_WIDTH) position.X -= Globals.SCREEN_WIDTH + (2 * texture.Width);
        if (position.Y - texture.Height > Globals.SCREEN_HEIGHT) position.Y -= Globals.SCREEN_HEIGHT + (2 * texture.Height);
    }
}
