namespace Quickie024;

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
        if (_sceneManager.Ready)
        {
            var newScene = _sceneManager.ActiveScene == Scenes.Scene1 ? Scenes.Scene2 : Scenes.Scene1;

            if (InputManager.KeyPressed(Keys.F1)) _sceneManager.SwitchScene(newScene, Transitions.Fade);
            else if (InputManager.KeyPressed(Keys.F2)) _sceneManager.SwitchScene(newScene, Transitions.Wipe);
            else if (InputManager.KeyPressed(Keys.F3)) _sceneManager.SwitchScene(newScene, Transitions.Push);
            else if (InputManager.KeyPressed(Keys.F4)) _sceneManager.SwitchScene(newScene, Transitions.Curtains);
            else if (InputManager.KeyPressed(Keys.F5)) _sceneManager.SwitchScene(newScene, Transitions.Rectangle);
            else if (InputManager.KeyPressed(Keys.F6)) _sceneManager.SwitchScene(newScene, Transitions.Checker);
        }

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
