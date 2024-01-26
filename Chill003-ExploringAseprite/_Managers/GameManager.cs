using MonoGame.Aseprite;
using MonoGame.Aseprite.Sprites;
using MonoGame.Aseprite.Content.Processors;

namespace Chill003;

/*
The Plan
---------------
1) Explore Aseprite, this will be my very first time with the software
2) "Draw" an animated sprite
3) Install MonoGame.Aseprite
4) Load the sprite and play the animation
*/

public class GameManager
{
    private AnimatedSprite _guy;
    private Vector2 _guyPos;

    public GameManager()
    {
        var file = Globals.Content.Load<AsepriteFile>("guy");
        var spriteSheet = SpriteSheetProcessor.Process(Globals.GraphicsDevice, file);
        _guy = spriteSheet.CreateAnimatedSprite("Wave");
        _guy.Play(0);
        _guyPos = new(200, 200);
    }

    public void Update()
    {
        _guy.Update(Globals.Time);
    }

    public void Draw()
    {
        Globals.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _guy.Draw(Globals.SpriteBatch, _guyPos);
        Globals.SpriteBatch.End();
    }
}
