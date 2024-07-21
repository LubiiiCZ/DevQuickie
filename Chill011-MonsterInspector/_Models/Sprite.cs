namespace Chill011;

public class Sprite(Texture2D texture)
{
    public readonly Texture2D Texture = texture;
    public Vector2 Origin = Vector2.Zero;
    public Vector2 Position;
    public float Rotation;
    public Color color = Color.White;
    public SpriteEffects flip = SpriteEffects.None;

    public virtual void Draw()
    {
        Globals.SpriteBatch.Draw(Texture, Position, null, color, Rotation, Origin, 1f, flip, 1f);
    }
}
