namespace Quickie019;

public class TrailStrategyTime(Vector2 position) : TrailStrategy
{
    private const float TIME = 0.1f;
    private float _time;
    private Vector2 _lastPosition = position;

    public override bool Ready(Vector2 position)
    {
        _time -= Globals.Time;

        if (position == _lastPosition) return false;

        if (_time < 0)
        {
            _time = TIME;
            _lastPosition = position;
            return true;
        }

        return false;
    }
}
