namespace Quickie024;

public class WipeTransition(RenderTarget2D transitionFrame) : Transition(transitionFrame)
{
    protected override void Process()
    {
        int mid = (int)(oldScene.Width * percentage);
        Rectangle newR = new(mid, 0, newScene.Width, newScene.Height);

        Globals.SpriteBatch.Draw(oldScene, Vector2.Zero, Color.White);
        Globals.SpriteBatch.Draw(newScene, newR, newR, Color.White);
    }
}
