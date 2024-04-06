namespace Challenge004;

public static class ExplosionManager
{
    public static readonly List<Explosion> Explosions = [];
    private static Texture2D _texture;

    public static void Restart()
    {
        Explosions.Clear();
    }

    public static void AddExplosion(Vector2 position)
    {
        _texture ??= Globals.Content.Load<Texture2D>("explosion");
        Explosion explosion = new(_texture, position);
        Explosions.Add(explosion);
    }

    public static void UpdateExplosions()
    {
        Explosions.ForEach(e => e.Update());
        Explosions.RemoveAll(e => e._currentFrame > 7);
    }

    public static void DrawExplosions()
    {
        Explosions.ForEach(e => e.Draw());
    }
}
