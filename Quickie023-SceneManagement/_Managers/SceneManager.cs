namespace Quickie023;

public class SceneManager
{
    public Scenes ActiveScene { get; private set; }
    private readonly Dictionary<Scenes, Scene> _scenes = [];

    public SceneManager(GameManager gameManager)
    {
        _scenes.Add(Scenes.Scene1, new Scene1(gameManager));
        _scenes.Add(Scenes.Scene2, new Scene2(gameManager));

        ActiveScene = Scenes.Scene1;
        _scenes[ActiveScene].Activate();
    }

    public void SwitchScene(Scenes scene)
    {
        ActiveScene = scene;
        _scenes[ActiveScene].Activate();
    }

    public void Update()
    {
        _scenes[ActiveScene].Update();
    }

    public RenderTarget2D GetFrame()
    {
        return _scenes[ActiveScene].GetFrame();
    }
}
