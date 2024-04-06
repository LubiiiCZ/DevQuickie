using Microsoft.Xna.Framework.Content;

namespace Challenge007;

public static class Globals
{
    public static float Time { get; set; }
    public static ContentManager Content { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }
    public static GraphicsDevice GraphicsDevice { get; set; }
    public static Point WindowSize { get; set; }
    public static Texture2D Texture { get; set; }
    public static int TileSize { get; } = 64;

    public static void Update(GameTime gt)
    {
        Time = (float)gt.ElapsedGameTime.TotalSeconds;
    }
}
