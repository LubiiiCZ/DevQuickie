using Microsoft.Xna.Framework.Content;

namespace Quickie002;

public static class Globals
{
    public static ContentManager Content { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }
    public static float ElapsedSeconds { get; set; }

    public static void Update(GameTime gameTime)
    {
        ElapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}
