namespace Quickie008;

public class Sprite(Texture2D tex, Vector2 pos)
{
    protected readonly Texture2D texture = tex;
    protected readonly Vector2 origin = new(tex.Width / 2, tex.Height / 2);
    protected Vector2 position = pos;
    protected float rotation;

    public virtual void Draw()
    {
        Globals.SpriteBatch.Draw(texture, position, null, Color.White, rotation, origin, 1, SpriteEffects.None, 1);
    }
}
