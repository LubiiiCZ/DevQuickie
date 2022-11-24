namespace Project001;

public class Sprite
{
    public Vector2 Position { get; set; }
    protected Vector2 origin;
    public Texture2D Texture { get; protected set; }
    protected Vector2 scale;

    public Sprite(Texture2D tex, Vector2 pos)
    {
        Texture = tex;
        Position = pos;
        origin = new(tex.Width / 2, tex.Height / 2);
        scale = Vector2.One;
    }

    public virtual void Draw()
    {
        Globals.SpriteBatch.Draw(Texture, Position, null, Color.White, 0f, origin, scale, SpriteEffects.None, 1f);
    }
}
