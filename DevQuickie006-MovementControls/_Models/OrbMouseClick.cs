namespace Quickie006;

public class OrbMouseClick : OrbMouseFollow
{
    private Vector2 _destination;
    protected override Vector2 Destination => _destination;

    public OrbMouseClick(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
        _destination = position;
    }

    public override void Update()
    {
        if (InputManager.MouseClicked)
        {
            _destination = InputManager.MousePosition;
        }

        base.Update();
    }
}
