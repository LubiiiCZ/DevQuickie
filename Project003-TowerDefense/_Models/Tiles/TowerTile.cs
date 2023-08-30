namespace Project003;

public class TowerTile : Tile
{
    public Monster Target { get; set; }
    public float Range { get; set; }
    public float Cooldown { get; private set; }
    public float CooldownLeft { get; private set; }
    public List<Projectile> Projectiles { get; } = new();
    private static Texture2D _projectileTexture;
    public bool Selected { get; set; }

    public TowerTile(Tiles tileType, Texture2D texture, int mapX, int mapY) : base(tileType, texture, mapX, mapY)
    {
        _projectileTexture ??= Globals.Content.Load<Texture2D>("projectile");
    }

    public void FireProjectile()
    {
        Projectiles.Add(new(_projectileTexture, Position, Target));
    }

    public void SetCooldown(float cooldown)
    {
        Cooldown = cooldown;
        CooldownLeft = 0f;
    }

    public override void Update()
    {
        if (CooldownLeft > 0)
        {
            CooldownLeft -= Globals.Time;
        }
        else
        {
            if (Target is not null)
            {
                FireProjectile();
                CooldownLeft += Cooldown;
            }
        }

        if (InputManager.WasTapped(Rectangle))
        {
            Selected = !Selected;
        }

        Projectiles.ForEach(p => p.Update());
        Projectiles.RemoveAll(p => p.Dead);
        Target = null;
    }
}
