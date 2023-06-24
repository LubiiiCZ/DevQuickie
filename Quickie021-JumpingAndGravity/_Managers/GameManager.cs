namespace Quickie021;

public class GameManager
{
    private readonly Map _map;
    private readonly Hero _hero;

    public GameManager()
    {
        _map = new();
        _hero = new(Globals.Content.Load<Texture2D>("hero"), new(Globals.WindowSize.X / 2, 200));
    }

    public void Update()
    {
        _hero.Update();
    }

    public void Draw()
    {
        Globals.SpriteBatch.Begin();
        _map.Draw();
        _hero.Draw();
        Globals.SpriteBatch.End();
    }
}
