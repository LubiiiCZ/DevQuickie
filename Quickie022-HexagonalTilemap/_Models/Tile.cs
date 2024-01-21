namespace Quickie022;

public class Tile(Texture2D texture, int x, int y)
{
    public Texture2D Texture { get; } = texture;
    public Color Color = Color.White;
    public Vector2 Origin = new(texture.Width / 2, texture.Height / 2);
    public Vector2 Position = GetPosition(texture, x, y);

    private static Vector2 GetPosition(Texture2D tex, int x, int y)
    {
        if (tex.Height > tex.Width)
        {
           return new(
                x * tex.Width + (y % 2 * tex.Width / 2) + tex.Width / 2,
                y * 0.75f * tex.Height + tex.Height / 2);
        }
        else
        {
            return new(
                x * 0.75f * tex.Width + tex.Width / 2,
                y * tex.Height + (x % 2 * tex.Height / 2) + tex.Height / 2);
        }
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(Texture, Position, null, Color, 0f, Origin, 1f, SpriteEffects.None, 1f);
    }
}
