namespace Project002;

public class Sprite(Texture2D tex, Vector2 pos)
{
    protected readonly Texture2D texture = tex;
    protected readonly Vector2 origin = new(tex.Width / 2, tex.Height / 2);
    public Vector2 Position { get; set; } = pos;
    public float Rotation { get; set; }
    public float Scale { get; set; } = 1f;
    public Color Color { get; set; } = Color.White;

    public virtual void Draw()
    {
        Globals.SpriteBatch.Draw(texture, Position, null, Color, Rotation, origin, Scale, SpriteEffects.None, 1);
    }
}
