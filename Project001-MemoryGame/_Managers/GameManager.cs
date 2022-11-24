namespace Project001;

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

public class GameManager
{
    public Board Board { get; }
    private GameState _gameState;
    public Card FirstCard { get; set; }
    public Card SecondCard { get; set; }

    public GameManager()
    {
        Board = new();
        ScoreManager.Init();
        GameStateManager.Init(this);
        ChangeState(GameStates.Menu);
    }

    public void StartEasy(object sender, EventArgs e)
    {
        Init(Difficulty.Easy);
    }

    public void StartMedium(object sender, EventArgs e)
    {
        Init(Difficulty.Medium);
    }

    public void StartHard(object sender, EventArgs e)
    {
        Init(Difficulty.Hard);
    }

    public void Init(Difficulty difficulty)
    {
        Board.SetDifficulty(difficulty);
        ScoreManager.SetDifficulty(difficulty);
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
        CardPartsManager.Update();
        if (ScoreManager.Active && (InputManager.MouseRightClicked || ScoreManager.TurnTimeLeft <= 0)) Restart();
        _gameState.Update(this);
    }

    public void Draw()
    {
        _gameState.Draw(this);
        CardPartsManager.Draw();
    }
}
