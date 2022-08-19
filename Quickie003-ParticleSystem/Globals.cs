using Microsoft.Xna.Framework.Content;

namespace Quickie003;

public static class Globals
{
    public static float TotalSeconds { get; set; }
    public static ContentManager Content { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }
    public static Random Random { get; set; } = new();

    public static void Update(GameTime gt)
    {
        TotalSeconds = (float)gt.ElapsedGameTime.TotalSeconds;
    }

    public static float RandomFloat(float min, float max)
    {
        return (float)(Random.NextDouble() * (max - min)) + min;
    }
}
