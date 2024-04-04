namespace Quickie024;

public class SceneManager
{
    public Scenes ActiveScene { get; private set; }
    private readonly Dictionary<Scenes, Scene> _scenes = [];
    private readonly RenderTarget2D _transitionFrame;
    private readonly Dictionary<Transitions, Transition> _transitions = [];
    private Transition _transition;
    public bool Ready { get; private set; } = true;

    public SceneManager(GameManager gameManager)
    {
        _scenes.Add(Scenes.Scene1, new Scene1(gameManager));
        _scenes.Add(Scenes.Scene2, new Scene2(gameManager));

        ActiveScene = Scenes.Scene1;
        _scenes[ActiveScene].Activate();

        _transitionFrame = Globals.GetNewRenderTarget();
        _transitions.Add(Transitions.Fade, new FadeTransition(_transitionFrame));
        _transitions.Add(Transitions.Wipe, new WipeTransition(_transitionFrame));
        _transitions.Add(Transitions.Push, new PushTransition(_transitionFrame));
        _transitions.Add(Transitions.Curtains, new CurtainsTransition(_transitionFrame));
        _transitions.Add(Transitions.Rectangle, new RectangleTransition(_transitionFrame));
        _transitions.Add(Transitions.Checker, new CheckerTransition(_transitionFrame));
    }

    public void SwitchScene(Scenes scene, Transitions transition, float duration = 0.5f)
    {
        var oldScene = _scenes[ActiveScene].GetFrame();
        ActiveScene = scene;
        _scenes[ActiveScene].Activate();
        var newScene = _scenes[ActiveScene].GetFrame();

        _transition = _transitions[transition];
        _transition.Start(oldScene, newScene, duration);
        Ready = false;
    }

    public void Update()
    {
        if (Ready)
        {
            _scenes[ActiveScene].Update();
        }
        else
        {
            Ready = _transition.Update();
        }
    }

    public RenderTarget2D GetFrame()
    {
        return Ready ? _scenes[ActiveScene].GetFrame() : _transition.GetFrame();
    }
}
