using Microsoft.Xna.Framework.Content;

namespace Challenge009;

public static class Globals
{
    public static float Time { get; private set; }
    public static ContentManager Content { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }
    public static GraphicsDevice GraphicsDevice { get; set; }
    public static Point WindowSize { get; } = new(1600, 900);
    public const float COEF = 68f;

    public static void Update(GameTime gt)
    {
        Time = (float)gt.ElapsedGameTime.TotalSeconds;
    }
}
