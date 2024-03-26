namespace Quickie023;

public class GameManager
{
    private readonly SceneManager _sceneManager;
    public Character Character { get; }

    public GameManager()
    {
        Character = new(Globals.Content.Load<Texture2D>("hero"), new(200, 200));
        _sceneManager = new(this);
    }

    public void Update()
    {
        if (InputManager.KeyPressed(Keys.F1)) _sceneManager.SwitchScene(Scenes.Scene1);
        if (InputManager.KeyPressed(Keys.F2)) _sceneManager.SwitchScene(Scenes.Scene2);
        _sceneManager.Update();
    }

    public void Draw()
    {
        var frame = _sceneManager.GetFrame();

        Globals.SpriteBatch.Begin();
        Globals.SpriteBatch.Draw(frame, Vector2.Zero, Color.White);
        Globals.SpriteBatch.End();
    }
}
