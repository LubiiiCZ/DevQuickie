namespace Quickie024;

public class CurtainsTransition(RenderTarget2D transitionFrame) : Transition(transitionFrame)
{
    protected override void Process()
    {
        int amount = (int)(oldScene.Width * percentage / 2);
        Rectangle newR = new(amount, 0, oldScene.Width - 2 * amount, newScene.Height);

        Globals.SpriteBatch.Draw(oldScene, Vector2.Zero, Color.White);
        Globals.SpriteBatch.Draw(newScene, newR, newR, Color.White);
    }
}
