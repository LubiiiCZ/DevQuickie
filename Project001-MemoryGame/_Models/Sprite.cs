namespace Project001;

public class Sprite(Texture2D tex, Vector2 pos)
{
    public Vector2 Position { get; set; } = pos;
    protected Vector2 origin = new(tex.Width / 2, tex.Height / 2);
    public Texture2D Texture { get; protected set; } = tex;
    protected Vector2 scale = Vector2.One;
    protected Color color = Color.White;

    public virtual void Draw()
    {
        Globals.SpriteBatch.Draw(Texture, Position, null, color, 0f, origin, scale, SpriteEffects.None, 1f);
    }
}
