namespace Quickie024;

public class RectangleTransition(RenderTarget2D transitionFrame) : Transition(transitionFrame)
{
    protected override void Process()
    {
        Rectangle newR = new(newScene.Width / 2, newScene.Height / 2, 2, 2);
        newR.Inflate(newScene.Width * (1 - percentage) / 2, newScene.Height * (1 - percentage) / 2);

        Globals.SpriteBatch.Draw(oldScene, Vector2.Zero, Color.White);
        Globals.SpriteBatch.Draw(newScene, newR, newR, Color.White);
    }
}
