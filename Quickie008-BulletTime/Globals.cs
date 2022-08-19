using Microsoft.Xna.Framework.Content;

namespace Quickie008;

public static class Globals
{
    public const int SCREEN_WIDTH = 1024;
    public const int SCREEN_HEIGHT = 768;
    public static float Time => TimeManager.Time;
    public static float BulletTime => TimeManager.BulletTime;
    public static ContentManager Content { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }

    public static void Update(GameTime gt)
    {
        TimeManager.Update(gt);
    }
}
