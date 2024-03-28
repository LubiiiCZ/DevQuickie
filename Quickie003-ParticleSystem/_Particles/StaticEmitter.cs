namespace Quickie003;

public class StaticEmitter(Vector2 pos) : IEmitter
{
    public Vector2 EmitPosition { get; } = pos;
}
