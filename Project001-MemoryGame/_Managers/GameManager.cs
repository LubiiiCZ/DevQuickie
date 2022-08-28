namespace Project001;

public class GameManager
{
    private readonly Board _board;

    public GameManager()
    {
        _board = new();
    }

    public void Update()
    {
    }

    public void Draw()
    {
        _board.Draw();
    }
}
