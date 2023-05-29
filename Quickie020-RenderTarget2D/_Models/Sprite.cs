namespace Quickie020;

public class Sprite
{
    protected Texture2D texture;
    public Vector2 Position { get; set; }

    public Sprite(Texture2D texture, Vector2 position)
    {
        this.texture = texture;
        Position = position;
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, Position, Color.White);
    }
}
