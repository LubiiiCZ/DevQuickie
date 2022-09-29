namespace Quickie012;

public class Player : Sprite
{
    public Vector2 Direction { get; private set; }

    public Player(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
    }

    public void Update()
    {
        Direction = InputManager.Direction;

        if (Direction != Vector2.Zero)
        {
            Direction = Vector2.Normalize(Direction);
            Position += Direction * Speed * Globals.TotalSeconds;
        }
    }
}
