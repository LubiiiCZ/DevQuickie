namespace LiveProject001;

public class GameEventManager
{
    private readonly GameManager _gameManager;

    public GameEventManager(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void ApplyRandomEvent()
    {
        Random r = new();
        var x = r.Next(2);

        switch (x)
        {
            case 0:
                _gameManager.monsterManager.AdjustAllMonstersSpeed(50);
                break;

            case 1:
                _gameManager.monsterManager.AdjustAllMonstersHealth(100);
                break;

            default: break;
        }
    }
}
