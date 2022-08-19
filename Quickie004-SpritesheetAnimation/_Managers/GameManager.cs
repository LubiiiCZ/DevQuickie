namespace Quickie004;

public class GameManager
{
    private Coin _coin;
    private Hero _hero;

    public void Init()
    {
        _coin = new(new(300, 300));
        _hero = new();
    }

    public void Update()
    {
        InputManager.Update();
        _coin.Update();
        _hero.Update();
    }

    public void Draw()
    {
        _coin.Draw();
        _hero.Draw();
    }
}
