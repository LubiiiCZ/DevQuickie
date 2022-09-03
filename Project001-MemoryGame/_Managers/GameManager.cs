namespace Project001;

public class GameManager
{
    public Board Board { get; }
    private GameState _gameState;
    public Card FirstCard { get; set; }
    public Card SecondCard { get; set; }

    public GameManager()
    {
        Board = new();
        _gameState = new FlipFirstCardState();
    }

    public void ChangeState(GameState state)
    {
        if (state is not null) _gameState = state;
    }

    public void Update()
    {
        InputManager.Update();
        _gameState.Update(this);
    }

    public void Draw()
    {
        Board.Draw();
    }
}
