namespace Project002;

public class GameManager
{
    private readonly Player _player;
    private readonly Background _bg;

    public GameManager()
    {
        _bg = new();
        var texture = Globals.Content.Load<Texture2D>("bullet");
        ProjectileManager.Init(texture);
        UIManager.Init(texture);
        ExperienceManager.Init(Globals.Content.Load<Texture2D>("exp"));

        _player = new(Globals.Content.Load<Texture2D>("player"));
        ZombieManager.Init();
    }

    public void Restart()
    {
        ProjectileManager.Reset();
        ZombieManager.Reset();
        ExperienceManager.Reset();
        _player.Reset();
    }

    public void Update()
    {
        InputManager.Update();
        ExperienceManager.Update(_player);
        _player.Update(ZombieManager.Zombies);
        ZombieManager.Update(_player);
        ProjectileManager.Update(ZombieManager.Zombies);

        if (_player.Dead) Restart();
    }

    public void Draw()
    {
        _bg.Draw();
        ExperienceManager.Draw();
        ProjectileManager.Draw();
        _player.Draw();
        ZombieManager.Draw();
        UIManager.Draw(_player);
    }
}
