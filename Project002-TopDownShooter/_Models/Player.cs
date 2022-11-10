namespace Project002;

public class Player : Sprite
{
    private readonly float _cooldown;
    private float _cooldownLeft;
    private readonly int _maxAmmo;
    public int Ammo { get; private set; }
    private readonly float _reloadTime;
    public bool Reloading { get; private set; }

    public Player(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
        _cooldown = 0.25f;
        _cooldownLeft = 0f;
        _maxAmmo = 30;
        Ammo = _maxAmmo;
        _reloadTime = 2f;
        Reloading = false;
    }

    private void Reload()
    {
        if (Reloading) return;
        _cooldownLeft = _reloadTime;
        Reloading = true;
        Ammo = _maxAmmo;
    }

    private void Fire()
    {
        if (_cooldownLeft > 0 || Reloading) return;

        Ammo--;
        if (Ammo > 0)
        {
            _cooldownLeft = _cooldown;
        }
        else
        {
            Reload();
        }

        ProjectileData pd = new()
        {
            Position = Position,
            Rotation = Rotation,
            Lifespan = 2,
            Speed = 600
        };

        ProjectileManager.AddProjectile(pd);
    }

    public void Update()
    {
        if (_cooldownLeft > 0)
        {
            _cooldownLeft -= Globals.TotalSeconds;
        }
        else if (Reloading)
        {
            Reloading = false;
        }

        if (InputManager.Direction != Vector2.Zero)
        {
            var dir = Vector2.Normalize(InputManager.Direction);
            Position = new(
                MathHelper.Clamp(Position.X + (dir.X * Speed * Globals.TotalSeconds), 0, Globals.Bounds.X),
                MathHelper.Clamp(Position.Y + (dir.Y * Speed * Globals.TotalSeconds), 0, Globals.Bounds.Y)
            );
        }

        var toMouse = InputManager.MousePosition - Position;
        Rotation = (float)Math.Atan2(toMouse.Y, toMouse.X);

        if (InputManager.MouseLeftDown)
        {
            Fire();
        }

        if (InputManager.MouseRightClicked)
        {
            Reload();
        }
    }
}
