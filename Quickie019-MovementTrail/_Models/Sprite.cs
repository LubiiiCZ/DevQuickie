namespace Quickie019;

public class Sprite(Texture2D texture, Vector2 position)
{
    protected Texture2D texture = texture;
    public Vector2 Position { get; protected set; } = position;
    private Vector2 _origin = new(texture.Width / 2, texture.Height / 2);
    protected Color color = Color.White;
    protected float rotation;

    public virtual void Draw()
    {
        Globals.SpriteBatch.Draw(texture, Position, null, color, rotation, _origin, 1f, SpriteEffects.None, 0f);
    }
}
