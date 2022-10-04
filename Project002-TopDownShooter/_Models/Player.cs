namespace Project002;

public class Player : Sprite
{
    public Player(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
    }

    private void Fire()
    {
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
        if (InputManager.Direction != Vector2.Zero)
        {
            var dir = Vector2.Normalize(InputManager.Direction);
            Position += dir * Speed * Globals.TotalSeconds;
        }

        var toMouse = InputManager.MousePosition - Position;
        Rotation = (float)Math.Atan2(toMouse.Y, toMouse.X);

        if (InputManager.MouseClicked)
        {
            Fire();
        }
    }
}
