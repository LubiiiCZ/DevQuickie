namespace Quickie012;

public class PatrolMovementAI : MovementAI
{
    private readonly List<Vector2> _path = [];
    private int _current;

    public void AddWaypoint(Vector2 wp)
    {
        _path.Add(wp);
    }

    public override void Move(Sprite bot)
    {
        if (_path.Count < 1) return;

        var dir = _path[_current] - bot.Position;

        if (dir.Length() > 4)
        {
            dir.Normalize();
            bot.Position += dir * bot.Speed * Globals.TotalSeconds;
        }
        else
        {
            _current = (_current + 1) % _path.Count;
        }
    }
}
