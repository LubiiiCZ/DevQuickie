namespace Project007;

public static class EnemyManager
{
    public static readonly List<Enemy> Enemies = [];
    private static float _spawnCooldown = SPAWN_RATE;
    private const float SPAWN_RATE = 0.3f;

    public static void Restart()
    {
        Enemies.Clear();
        _spawnCooldown = SPAWN_RATE;
    }

    public static void AddEnemy()
    {
        Random r = new();
        var s = r.Next(2) == 0 ? "1" : "2";
        Enemy enemy = new(Globals.Content.Load<Texture2D>($"enemy{s}"))
        {
            Position = GeneratePosition()
        };
        enemy.SetRandomDestination();

        Enemies.Add(enemy);
    }

    private static Vector2 GeneratePosition()
    {
        Random r = new();
        return new(r.Next(Globals.WindowSize.X), -100);
    }

    public static void UpdateEnemies()
    {
        Enemies.ForEach(e => e.Update());

        _spawnCooldown -= Globals.Time;
        if (_spawnCooldown < 0)
        {
            _spawnCooldown += SPAWN_RATE;
            AddEnemy();
        }
    }

    public static void DrawEnemies()
    {
        Enemies.ForEach(e => e.Draw());
    }
}
