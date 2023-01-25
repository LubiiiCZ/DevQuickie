namespace Quickie016;

public class GameManager
{
    private readonly Map _map;
    private readonly Hero _hero;

    public GameManager()
    {
        _map = new();
        _hero = new(Globals.Content.Load<Texture2D>("hero"), Vector2.Zero);
        Pathfinder.Init(_map, _hero);
    }

    public void Update()
    {
        InputManager.Update();
        _map.Update();
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
