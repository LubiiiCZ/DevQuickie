namespace Quickie019;

public class GameManager
{
    private readonly Hero _hero;

    public GameManager()
    {
        _hero = new(Globals.Content.Load<Texture2D>("hero"), new(100, 100));
    }

    public void Update()
    {
        InputManager.Update();
        _hero.Update();
    }

    public void Draw()
    {
        Globals.SpriteBatch.Begin();
        _hero.Draw();
        Globals.SpriteBatch.End();
    }
}
