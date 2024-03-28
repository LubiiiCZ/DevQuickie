namespace Quickie016;

public class Sprite(Texture2D texture, Vector2 position)
{
    protected Texture2D texture = texture;
    public Vector2 Position { get; protected set; } = position;
    public Vector2 Origin { get; protected set; } = Vector2.Zero;
    public Color Color { get; set; } = Color.White;
    public Rectangle Rectangle => new((int)Position.X, (int)Position.Y, texture.Width, texture.Height);

    public virtual void Draw()
    {
        Globals.SpriteBatch.Draw(texture, Position, null, Color, 0f, Origin, 1f, SpriteEffects.None, 0f);
    }
}
