namespace Project001;

public enum GameStates
{
    Menu,
    FlipFirstCard,
    FlipSecondCard,
    ResolveTurn,
    Win
}

public static class GameStateManager
{
    public static Dictionary<GameStates, GameState> States { get; } = [];

    public static void Init(GameManager gm)
    {
        States.Clear();
        States.Add(GameStates.Menu, new MenuState(gm));
        States.Add(GameStates.FlipFirstCard, new FlipFirstCardState());
        States.Add(GameStates.FlipSecondCard, new FlipSecondCardState());
        States.Add(GameStates.ResolveTurn, new ResolveTurnState());
        States.Add(GameStates.Win, new WinState());
    }
}
