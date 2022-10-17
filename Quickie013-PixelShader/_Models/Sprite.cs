namespace Quickie013;

public class Sprite
{
    protected readonly Texture2D texture;

    public Sprite(Texture2D tex)
    {
        texture = tex;
    }

    public virtual void Draw(Vector2 pos)
    {
        Globals.SpriteBatch.Draw(texture, pos, Color.White);
    }
}
