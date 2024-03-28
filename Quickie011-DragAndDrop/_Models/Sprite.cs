namespace Quickie011;

public class Sprite(Texture2D tex, Vector2 pos)
{
    protected readonly Texture2D texture = tex;
    protected readonly Vector2 origin = new(tex.Width / 2, tex.Height / 2);
    public Vector2 Position { get; set; } = pos;
    public Rectangle Rectangle => new((int)(Position.X - origin.X),
                                      (int)(Position.Y - origin.Y),
                                      texture.Width,
                                      texture.Height);

    public void Draw()
    {
        Globals.SpriteBatch.Draw(texture, Position, null, Color.White, 0, origin, 1, SpriteEffects.None, 1);
    }
}
