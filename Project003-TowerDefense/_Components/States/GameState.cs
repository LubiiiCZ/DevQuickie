namespace Project003;

public abstract class GameState
{
    protected GameManager _gm;

    public GameState(GameManager gm)
    {
        _gm = gm;
    }

    public abstract void Update();
    public abstract void Draw();
}
