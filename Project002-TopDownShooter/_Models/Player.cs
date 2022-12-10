namespace Project002;

public class Player : MovingSprite
{
    public Weapon Weapon { get; set; }
    private Weapon _weapon1;
    private Weapon _weapon2;
    public bool Dead { get; private set; }
    public int Experience { get; private set; }

    public Player(Texture2D tex) : base(tex, GetStartPosition())
    {
        Reset();
    }

    private static Vector2 GetStartPosition()
    {
        return new(Globals.Bounds.X / 2, Globals.Bounds.Y / 2);
    }

    public void GetExperience(int exp)
    {
        Experience += exp;
    }

    public void Reset()
    {
        _weapon1 = new MachineGun();
        _weapon2 = new Shotgun();
        Dead = false;
        Weapon = _weapon1;
        Position = GetStartPosition();
        Experience = 0;
    }

    public void SwapWeapon()
    {
        Weapon = (Weapon == _weapon1) ? _weapon2 : _weapon1;
    }

    private void CheckDeath(List<Zombie> zombies)
    {
        foreach (var z in zombies)
        {
            if (z.HP <= 0) continue;
            if ((Position - z.Position).Length() < 50)
            {
                Dead = true;
                break;
            }
        }
    }

    public void Update(List<Zombie> zombies)
    {
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

        Weapon.Update();

        if (InputManager.SpacePressed)
        {
            SwapWeapon();
        }

        if (InputManager.MouseLeftDown)
        {
            Weapon.Fire(this);
        }

        if (InputManager.MouseRightClicked)
        {
            Weapon.Reload();
        }

        CheckDeath(zombies);
    }
}
