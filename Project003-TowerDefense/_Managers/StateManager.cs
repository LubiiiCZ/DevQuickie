namespace Project003;

public enum States
{
    IdleState,
    PlayState,
}

public class StateManager
{
    private static GameState _currentState;
    private static GameManager _gm;
    private static Dictionary<States, GameState> _states;
    private static GameState _nextState;

    public static void Initialize(GameManager gm)
    {
        _states = new();
        _gm = gm;

        _states.Add(States.IdleState, new IdleState(_gm));
        _states.Add(States.PlayState, new PlayState(_gm));

        _currentState = _states[States.IdleState];
    }

    public static void SwitchState(States state)
    {
        _nextState = _states[state];
    }

    public static void Update()
    {
        if (_nextState is not null)
        {
            _currentState = _nextState;
            _nextState = null;
        }

        _currentState.Update();
    }

    public static void Draw()
    {
        _currentState.Draw();
    }
}
