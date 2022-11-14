namespace Project002;

public class Player : Sprite
{
    public Weapon Weapon { get; set; }
    private readonly Weapon _weapon1 = new MachineGun();
    private readonly Weapon _weapon2 = new Shotgun();

    public Player(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
        Weapon = _weapon1;
    }

    public void SwapWeapon()
    {
        Weapon = (Weapon == _weapon1) ? _weapon2 : _weapon1;
    }

    public void Update()
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
    }
}
