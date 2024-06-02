namespace Chill006;

public class Sprite(Texture2D texture, Vector2 position)
{
    public Texture2D Texture { get; } = texture;
    public Vector2 position = position;

    public void Draw()
    {
        Globals.SpriteBatch.Draw(Texture, position, Color.White);
    }
}
