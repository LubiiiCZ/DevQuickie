namespace Project009;

public abstract class State(GameManager gm)
{
    protected GameManager GM = gm;
    public abstract void Update();
    public abstract void Draw();
}
