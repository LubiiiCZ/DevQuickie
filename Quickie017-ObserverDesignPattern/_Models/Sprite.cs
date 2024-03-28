namespace Quickie017;

public class Sprite(Texture2D texture, Vector2 position)
{
    protected Texture2D texture = texture;
    public Vector2 Position { get; protected set; } = position;
    public Rectangle Rectangle => new((int)Position.X, (int)Position.Y, texture.Width, texture.Height);

    public virtual void Draw()
    {
        Globals.SpriteBatch.Draw(texture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
    }
}
