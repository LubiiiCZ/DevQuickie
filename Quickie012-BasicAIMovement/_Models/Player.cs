namespace Quickie012;

public class Player(Texture2D tex, Vector2 pos) : Sprite(tex, pos)
{
    public Vector2 Direction { get; private set; }

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
