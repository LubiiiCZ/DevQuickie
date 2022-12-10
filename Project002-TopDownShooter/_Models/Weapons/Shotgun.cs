namespace Project002;

public class Shotgun : Weapon
{
    private const float ANGLE_STEP = (float)(Math.PI / 16);

    public Shotgun()
    {
        cooldown = 0.75f;
        maxAmmo = 8;
        Ammo = maxAmmo;
        reloadTime = 3f;
    }

    protected override void CreateProjectiles(Player player)
    {
        ProjectileData pd = new()
        {
            Position = player.Position,
            Rotation = player.Rotation - (3 * ANGLE_STEP),
            Lifespan = 0.5f,
            Speed = 800,
            Damage = 2
        };

        for (int i = 0; i < 5; i++)
        {
            pd.Rotation += ANGLE_STEP;
            ProjectileManager.AddProjectile(pd);
        }
    }
}
