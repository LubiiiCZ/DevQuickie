namespace Quickie003;

public class MouseEmitter : IEmitter
{
    public Vector2 EmitPosition => InputManager.MousePosition;
}
