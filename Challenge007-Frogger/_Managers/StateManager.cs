namespace Challenge007;

public static class StateManager
{
    private static States _current;
    private static States _newState;
    private static State _activeState;
    private static Dictionary<States, State> _states = [];

    public static void Initialize(GameManager gm)
    {
        _states.Add(States.Play, new PlayState(gm));
        _states.Add(States.End, new EndState(gm));
        _current = States.Play;
        _newState = _current;
        _activeState = _states[_current];
    }

    public static void SwitchState(States state)
    {
        _newState = state;
    }

    public static void Update()
    {
        if (_newState != _current)
        {
            _current = _newState;
            _activeState = _states[_current];
        }

        _activeState.Update();
    }

    public static void Draw()
    {
        _activeState.Draw();
    }
}
