using Microsoft.Xna.Framework.Content;

namespace Quickie023;

public static class Globals
{
    public static float Time { get; private set; }
    public static ContentManager Content { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }
    public static GraphicsDevice GraphicsDevice { get; set; }
    public static Point WindowSize { get; } = new(800, 600);

    public static RenderTarget2D GetNewRenderTarget()
    {
        return new(GraphicsDevice, WindowSize.X, WindowSize.Y);
    }

    public static void Update(GameTime gt)
    {
        Time = (float)gt.ElapsedGameTime.TotalSeconds;
    }
}
