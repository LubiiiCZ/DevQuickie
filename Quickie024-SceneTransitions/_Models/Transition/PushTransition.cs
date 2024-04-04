namespace Quickie024;

public class PushTransition(RenderTarget2D transitionFrame) : Transition(transitionFrame)
{
    protected override void Process()
    {
        int mid = (int)(oldScene.Width * percentage);
        Vector2 oldPos = new(mid - oldScene.Width, 0);
        Vector2 newPos = new(mid, 0);

        Globals.SpriteBatch.Draw(oldScene, oldPos, Color.White);
        Globals.SpriteBatch.Draw(newScene, newPos, Color.White);
    }
}
