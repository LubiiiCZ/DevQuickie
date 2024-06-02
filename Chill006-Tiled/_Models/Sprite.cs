namespace Chill006_Tiled;

public class Sprite(Texture2D texture, Vector2 position)
{
    private readonly Texture2D _texture = texture;
    public Vector2 Origin = new(texture.Width / 2, texture.Height / 2);
    public Vector2 Position = position;
    public float Rotation;

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, Position, null, Color.White, Rotation, Origin, 1f, SpriteEffects.None, 1f);
    }
}
