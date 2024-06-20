using nkast.Aether.Physics2D.Dynamics;

namespace Chill010;

public class Box
{
    private static Texture2D _boxTexture;
    public readonly Body body;
    private Vector2 _origin;
    private readonly float _scale;

    public Box(float size, World world, Vector2 position)
    {
        _boxTexture ??= Globals.Content.Load<Texture2D>("box");
        _origin = new(_boxTexture.Width / 2f, _boxTexture.Height / 2f);
        _scale = size;
        body = world.CreateBody(position, bodyType: BodyType.Dynamic);
        var fix = body.CreateRectangle(size, size, 1f, Vector2.Zero);
        fix.Restitution = 0.5f;
        fix.Friction = 1f;
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_boxTexture, body.Position, null, Color.White, body.Rotation, _origin, _scale/Globals.COEF, SpriteEffects.None, 0f);
    }
}
