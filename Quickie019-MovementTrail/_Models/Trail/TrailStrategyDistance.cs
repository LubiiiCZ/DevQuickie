namespace Quickie019;

public class TrailStrategyDistance(Vector2 position) : TrailStrategy
{
    private float _distance;
    private Vector2 _lastPosition = position;
    private const float DISTANCE = 250f;

    public override bool Ready(Vector2 position)
    {
        if (position == _lastPosition) return false;

        _distance -= (_lastPosition - position).LengthSquared();
        _lastPosition = position;

        if (_distance < 0f)
        {
            _distance = DISTANCE;
            return true;
        }

        return false;
    }
}
