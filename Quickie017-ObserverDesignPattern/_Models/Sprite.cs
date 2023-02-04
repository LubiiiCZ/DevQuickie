namespace Quickie017;

public class Sprite
{
    protected Texture2D texture;
    public Vector2 Position { get; protected set; }
    public Rectangle Rectangle => new((int)Position.X, (int)Position.Y, texture.Width, texture.Height);

    public Sprite(Texture2D texture, Vector2 position)
    {
        this.texture = texture;
        Position = position;
    }

    public virtual void Draw()
    {
        Globals.SpriteBatch.Draw(texture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
    }
}
