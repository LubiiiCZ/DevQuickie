namespace Quickie019;

public class Trail
{
    private readonly Texture2D _texture;
    private readonly List<TrailPart> _trail;
    private readonly TrailStrategy _strategy;
    private const float LIFESPAN = 1f;

    public Trail(Texture2D tex, Vector2 position)
    {
        _texture = tex;
        _trail = new();
        _strategy = new TrailStrategyDistance(position);
    }

    private void AddTrail(Vector2 position, float rotation)
    {
        _trail.Add(new(_texture, position, rotation, LIFESPAN));
    }

    public void Update(Vector2 position)
    {
        UpdateTrail();
        if (_strategy.Ready(position))
        {
            var rotation = (float)Math.Atan2(InputManager.Direction.X, -InputManager.Direction.Y);
            AddTrail(position, rotation);
        }
    }

    private void UpdateTrail()
    {
        foreach (var part in _trail) part.Update();
        _trail.RemoveAll(p => p.Lifespan <= 0);
    }

    public void Draw()
    {
        foreach (var part in _trail) part.Draw();
    }
}
