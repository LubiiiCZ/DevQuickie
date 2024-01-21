namespace Quickie022;

public class GameManager
{
    private readonly Map _map;

    public GameManager()
    {
        _map = new(16, 7);
    }

    public void Update()
    {
        _map.Update();
    }

    public void Draw()
    {
        Globals.SpriteBatch.Begin();
        _map.Draw();
        Globals.SpriteBatch.End();
    }
}
