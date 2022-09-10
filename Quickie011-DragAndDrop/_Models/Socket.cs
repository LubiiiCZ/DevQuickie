namespace Quickie011;

public class Socket : Sprite, ITargetable
{
    public Socket(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
        (this as ITargetable).RegisterTargetable();
    }
}
