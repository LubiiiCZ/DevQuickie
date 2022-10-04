namespace Project002;

public static class ProjectileManager
{
    private static Texture2D _texture;
    public static List<Projectile> Projectiles { get; } = new();

    public static void Init()
    {
        _texture = Globals.Content.Load<Texture2D>("bullet");
    }

    public static void AddProjectile(ProjectileData data)
    {
        Projectiles.Add(new(_texture, data));
    }

    public static void Update()
    {
        foreach (var p in Projectiles)
        {
            p.Update();
        }
        Projectiles.RemoveAll((p) => p.Lifespan <= 0);
    }

    public static void Draw()
    {
        foreach (var p in Projectiles)
        {
            p.Draw();
        }
    }
}
