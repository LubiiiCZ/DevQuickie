namespace Quickie013;

public class Sprite(Texture2D tex)
{
    protected readonly Texture2D texture = tex;

    public virtual void Draw(Vector2 pos)
    {
        Globals.SpriteBatch.Draw(texture, pos, Color.White);
    }
}
