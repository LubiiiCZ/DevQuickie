namespace Quickie011;

public class Gem : Sprite, IDraggable
{
    public Gem(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
        (this as IDraggable).RegisterDraggable();
    }
}
