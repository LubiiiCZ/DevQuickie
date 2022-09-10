namespace Quickie011;

public class Sprite
{
    protected readonly Texture2D texture;
    protected readonly Vector2 origin;
    public Vector2 Position { get; set; }
    public Rectangle Rectangle => new((int)(Position.X - origin.X),
                                      (int)(Position.Y - origin.Y),
                                      texture.Width,
                                      texture.Height);

    public Sprite(Texture2D tex, Vector2 pos)
    {
        texture = tex;
        Position = pos;
        origin = new(tex.Width / 2, tex.Height / 2);
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(texture, Position, null, Color.White, 0, origin, 1, SpriteEffects.None, 1);
    }
}
