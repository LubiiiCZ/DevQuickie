namespace Quickie024;

public class FadeTransition(RenderTarget2D transitionFrame) : Transition(transitionFrame)
{
    protected override void Process()
    {
        Globals.SpriteBatch.Draw(oldScene, Vector2.Zero, Color.White * percentage);
        Globals.SpriteBatch.Draw(newScene, Vector2.Zero, Color.White * (1 - percentage));
    }
}
