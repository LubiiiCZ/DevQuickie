namespace Quickie006;

public class OrbMouseFollow : Sprite
{
    protected virtual Vector2 Destination => InputManager.MousePosition;

    public OrbMouseFollow(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
    }

    public virtual void Update()
    {
        var dir = Destination - position;

        if (dir != Vector2.Zero && dir.Length() > 4)
        {
            dir.Normalize();
            position += dir * speed * Globals.TotalSeconds;
        }
    }
}
