namespace Quickie024;

public class CheckerTransition(RenderTarget2D transitionFrame) : Transition(transitionFrame)
{
    protected override void Process()
    {
        int w = (int)(newScene.Width / 6f);
        int w2 = w / 2;
        int wp = (int)(w * (1 - percentage) / 2f);
        int h = (int)(newScene.Height / 4f);
        int h2 = h / 2;
        int hp = (int)(h * (1 - percentage) / 2f);
        List<Rectangle> newR = [];

        for (int x = 0; x < 6; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                Rectangle r = new(x * w + w2, y * h + h2, 0, 0);
                r.Inflate(wp, hp);
                newR.Add(r);
            }
        }

        Globals.SpriteBatch.Draw(oldScene, Vector2.Zero, Color.White);

        foreach (var r in newR)
        {
            Globals.SpriteBatch.Draw(newScene, r, r, Color.White);
        }
    }
}
