namespace Project009;

public static class StateManager
{
    private static States _current;
    private static States _newState;
    private static Dictionary<States, State> _states = [];

    public static void Initialize(GameManager gm)
    {
        _states.Add(States.Play, new PlayState(gm));
        _states.Add(States.End, new EndState(gm));
        _current = States.Play;
        _newState = States.Play;
    }

    public static void SwitchState(States state)
    {
        _newState = state;
    }

    public static void Update()
    {
        if (_newState != _current) _current = _newState;

        _states[_current].Update();
    }

    public static void Draw()
    {
        _states[_current].Draw();
    }
}
