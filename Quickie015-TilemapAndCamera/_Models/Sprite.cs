namespace Quickie015;

public class Sprite(Texture2D texture, Vector2 position)
{
    private readonly Texture2D _texture = texture;
    public Vector2 Position { get; protected set; } = position;
    public Vector2 Origin { get; protected set; } = new(texture.Width / 2, texture.Height / 2);

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0f);
    }
}
