using Microsoft.Xna.Framework.Content;

namespace Quickie011;

public static class Globals
{
    public static float TotalSeconds { get; set; }
    public static ContentManager Content { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }

    public static void Update(GameTime gt)
    {
        TotalSeconds = (float)gt.ElapsedGameTime.TotalSeconds;
    }
}
