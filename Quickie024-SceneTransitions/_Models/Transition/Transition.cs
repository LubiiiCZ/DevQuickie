namespace Quickie024;

public abstract class Transition(RenderTarget2D transitionFrame)
{
    protected RenderTarget2D frame = transitionFrame;
    protected RenderTarget2D oldScene;
    protected RenderTarget2D newScene;
    protected float duration;
    protected float durationLeft;
    protected float percentage;

    protected abstract void Process();

    public void Start(RenderTarget2D oldS, RenderTarget2D newS, float length)
    {
        oldScene = oldS;
        newScene = newS;
        duration = length;
        durationLeft = duration;
    }

    public virtual bool Update()
    {
        durationLeft -= Globals.Time;
        percentage = durationLeft / duration;
        return durationLeft < 0f;
    }

    public RenderTarget2D GetFrame()
    {
        Globals.GraphicsDevice.SetRenderTarget(frame);
        Globals.GraphicsDevice.Clear(Color.Black);
        Globals.SpriteBatch.Begin();
        Process();
        Globals.SpriteBatch.End();
        Globals.GraphicsDevice.SetRenderTarget(null);
        return frame;
    }
}
