namespace Project001;

public enum GameStates
{
    FlipFirstCard,
    FlipSecondCard,
    ResolveTurn,
    Win
}

public static class GameStateManager
{
    public static Dictionary<GameStates, GameState> States { get; } = new();

    public static void Init()
    {
        States.Clear();
        States.Add(GameStates.FlipFirstCard, new FlipFirstCardState());
        States.Add(GameStates.FlipSecondCard, new FlipSecondCardState());
        States.Add(GameStates.ResolveTurn, new ResolveTurnState());
        States.Add(GameStates.Win, new WinState());
    }
}
