namespace Project001;

public class GameManager
{
    public Board Board { get; }
    private GameState _gameState;
    public Card FirstCard { get; set; }
    public Card SecondCard { get; set; }

    public GameManager()
    {
        GameStateManager.Init();
        Board = new();
        Restart();
    }

    public void Restart()
    {
        Board.Reset();
        ScoreManager.Reset();
        ChangeState(GameStates.FlipFirstCard);
    }

    public void ChangeState(GameStates state)
    {
        _gameState = GameStateManager.States[state];
    }

    public void Update()
    {
        InputManager.Update();
        ScoreManager.Update();
        if (InputManager.MouseRightClicked || ScoreManager.TurnTimeLeft <= 0) Restart();
        _gameState.Update(this);
    }

    public void Draw()
    {
        _gameState.Draw(this);
    }
}
