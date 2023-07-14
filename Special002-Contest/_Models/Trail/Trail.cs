namespace Special002;

public class Trail
{
    private readonly Texture2D _texture;
    private readonly List<TrailPart> _trail;
    private readonly TrailStrategy _strategy;
    private const float LIFESPAN = 0.5f;

    public Trail(Texture2D tex, Vector2 position)
    {
        _texture = tex;
        _trail = new();
        _strategy = new TrailStrategyTime(position);
    }

    private void AddTrail(Vector2 position)
    {
        _trail.Add(new(_texture, position, LIFESPAN));
    }

    public void Update(Vector2 position)
    {
        UpdateTrail();
        if (_strategy.Ready(position))
        {
            AddTrail(position);
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
