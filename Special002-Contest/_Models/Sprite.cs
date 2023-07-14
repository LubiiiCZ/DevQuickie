namespace Special002;

public class Sprite
{
    protected readonly Texture2D texture;
    protected readonly Vector2 origin;
    public Vector2 position;
    public bool Dead { get; set; }
    protected float rotation;
    protected Color color = Color.White;

    public Sprite(Texture2D tex, Vector2 pos)
    {
        texture = tex;
        position = pos;
        origin = new(tex.Width / 2, tex.Height / 2);
    }

    public virtual void Draw()
    {
        Globals.SpriteBatch.Draw(texture, position, null, color, rotation, origin, 1, SpriteEffects.None, 1);
    }
}
