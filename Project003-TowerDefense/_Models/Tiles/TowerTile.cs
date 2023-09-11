namespace Project003;

public class TowerTile : Tile
{
    public Monster Target { get; set; }
    public float Range { get; set; }
    public int Damage { get; set; }
    public float Cooldown { get; private set; }
    public float CooldownLeft { get; private set; }
    public List<Projectile> Projectiles { get; } = new();
    private static Texture2D _projectileTexture;
    public bool Selected { get; set; }
    public bool OnlyAir { get; set; }

    public TowerTile(Tiles tileType, Texture2D texture, int mapX, int mapY) : base(tileType, texture, mapX, mapY)
    {
        _projectileTexture ??= Globals.Content.Load<Texture2D>("projectile");
    }

    public void Reset()
    {
        CooldownLeft = 0;
        Projectiles.Clear();
        Target = null;
        Selected = false;
    }

    public void FireProjectile()
    {
        Projectiles.Add(new(_projectileTexture, Position, Target, Damage));
    }

    public void SetCooldown(float cooldown)
    {
        Cooldown = cooldown;
        CooldownLeft = 0f;
    }

    public void SelectTarget(List<Monster> monsters)
    {
        if (CooldownLeft > 0) return;
        if (Target is not null && !Target.Dead && Vector2.Distance(Position, Target.Position) <= Range) return;

        float minDistance = float.MaxValue;
        Monster result = null;

        foreach (var monster in monsters)
        {
            if (!monster.Data.Flying && OnlyAir) continue;

            var distance = Vector2.Distance(Position, monster.Position);
            if (distance < minDistance && distance <= Range)
            {
                minDistance = distance;
                result = monster;
            }
        }

        Target = result;
    }

    public void UpdateSelection()
    {
        if (InputManager.WasTapped(Rectangle))
        {
            Selected = !Selected;
        }
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

        Projectiles.ForEach(p => p.Update());
        Projectiles.RemoveAll(p => p.Dead);
    }
}
