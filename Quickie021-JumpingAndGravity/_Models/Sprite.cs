namespace Quickie021;

public class Sprite
{
    public Texture2D Texture { get; }
    public Vector2 position;

    public Sprite(Texture2D texture, Vector2 position)
    {
        Texture = texture;
        this.position = position;
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(Texture, position, Color.White);
    }
}
