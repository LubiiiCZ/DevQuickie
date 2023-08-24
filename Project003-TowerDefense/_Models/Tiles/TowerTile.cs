namespace Project003;

public class TowerTile : Tile
{
    public Monster Target { get; set; }
    public float Range { get; set; }
    private float _cooldown;
    private float _cooldownLeft;
    public List<Projectile> Projectiles { get; } = new();
    private static Texture2D _projectileTexture;

    public TowerTile(Tiles tileType, Texture2D texture, int mapX, int mapY) : base(tileType, texture, mapX, mapY)
    {
    }

    public void FireProjectile()
    {
        _projectileTexture ??= Globals.Content.Load<Texture2D>("projectile");
        Projectiles.Add(new(_projectileTexture, Position, Target));
    }

    public void SetCooldown(float cooldown)
    {
        _cooldown = cooldown;
        _cooldownLeft = 0f;
    }

    public override void Update()
    {
        if (_cooldownLeft > 0)
        {
            _cooldownLeft -= Globals.Time;
        }
        else
        {
            if (Target is not null)
            {
                FireProjectile();
                _cooldownLeft = _cooldown;
            }
        }

        Projectiles.ForEach(p => p.Update());
        Projectiles.RemoveAll(p => p.Dead);
        Target = null;
    }
}
