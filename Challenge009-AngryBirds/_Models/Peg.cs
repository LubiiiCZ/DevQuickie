using nkast.Aether.Physics2D.Dynamics;

namespace Challenge009;

public class Peg
{
    private static Texture2D _texture;
    public readonly Body body;
    private Vector2 _origin;
    private readonly float _scale;

    public Peg(float size, World world, Vector2 position)
    {
        _texture ??= Globals.Content.Load<Texture2D>("orb");
        _origin = new(_texture.Width / 2f, _texture.Height / 2f);
        _scale = size;
        body = world.CreateBody(position, bodyType: BodyType.Static);
        var fix = body.CreateCircle(size/2f, 1f);
        fix.Restitution = 0.75f;
        fix.Friction = 1f;
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, body.Position, null, Color.White, body.Rotation, _origin, _scale/Globals.COEF, SpriteEffects.None, 0f);
    }
}
