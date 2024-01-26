using Microsoft.Xna.Framework.Content;

namespace Chill003;

public static class Globals
{
    public static ContentManager Content { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }
    public static GraphicsDevice GraphicsDevice { get; set; }
    public static double Time { get; private set; }

    public static void Update(GameTime gt)
    {
        Time = gt.ElapsedGameTime.TotalSeconds;
    }
}
