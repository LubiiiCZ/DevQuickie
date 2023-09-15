namespace Project003;

public enum States
{
    Idle,
    Play,
    Reward,
    ProcessRewards,
    Placement,
    SelectTarget,
    ProcessSpells,
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

        _states.Add(States.Idle, new IdleState(_gm));
        _states.Add(States.Play, new PlayState(_gm));
        _states.Add(States.Reward, new RewardState(_gm));
        _states.Add(States.ProcessRewards, new ProcessRewardsState(_gm));
        _states.Add(States.Placement, new PlacementState(_gm));
        _states.Add(States.SelectTarget, new SelectTargetState(_gm));
        _states.Add(States.ProcessSpells, new ProcessSpellState(_gm));

        _currentState = _states[States.Reward];
    }

    public static void SwitchState(States state)
    {
        _nextState = _states[state];
    }

    public static void UpdateState(States state)
    {
        _states[state].Update();
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

    public static void DrawState(States state)
    {
        _states[state].Draw();
    }

    public static void Draw()
    {
        _currentState.Draw();
    }
}
