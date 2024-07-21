using nkast.Aether.Physics2D.Dynamics;

namespace Challenge009;

public class Sensor
{
    private static Texture2D _boxTexture;
    public readonly Body body;
    private Vector2 _origin;
    private readonly float _scale;
    public int value;

    public Sensor(float size, World world, Vector2 position)
    {
        _boxTexture ??= Globals.Content.Load<Texture2D>("box");
        _origin = new(_boxTexture.Width / 2f, _boxTexture.Height / 2f);
        _scale = size;
        body = world.CreateBody(position, bodyType: BodyType.Static);
        var fix = body.CreateRectangle(size, size, 1f, Vector2.Zero);
        fix.Restitution = 0f;
        fix.Friction = 1f;
        fix.IsSensor = true;

        body.Tag = this;
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_boxTexture, body.Position, null, Color.White, body.Rotation, _origin, _scale/Globals.COEF, SpriteEffects.None, 0f);
    }
}
