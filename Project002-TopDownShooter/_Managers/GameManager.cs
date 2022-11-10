namespace Project002;

public class GameManager
{
    private readonly Player _player;

    public GameManager()
    {
        var texture = Globals.Content.Load<Texture2D>("bullet");
        ProjectileManager.Init(texture);
        UIManager.Init(texture);

        _player = new(Globals.Content.Load<Texture2D>("player"), new(Globals.Bounds.X / 2, Globals.Bounds.Y / 2));
        ZombieManager.Init();
    }

    public void Update()
    {
        InputManager.Update();
        _player.Update();
        ZombieManager.Update(_player);
        ProjectileManager.Update(ZombieManager.Zombies);
    }

    public void Draw()
    {
        ProjectileManager.Draw();
        _player.Draw();
        ZombieManager.Draw();
        UIManager.Draw(_player);
    }
}
