namespace Quickie014;

public class GameManager
{
    private readonly List<Circle> _circles = [];

    public GameManager()
    {
        var texture = Globals.Content.Load<Texture2D>("orb-blue");
        for (int i = 0; i < 10; i++)
        {
            _circles.Add(new(texture));
        }
    }

    private void CheckCollisions()
    {
        for (int i = 0; i < _circles.Count - 1; i++)
        {
            for (int j = i + 1; j < _circles.Count; j++)
            {
                if ((_circles[i].Position - _circles[j].Position).Length() < (_circles[i].Origin.X + _circles[j].Origin.X))
                {
                    ResolveCollision(_circles[i], _circles[j]);
                    break;
                }
            }
        }
    }

    private void ResolveCollision(Circle b1, Circle b2)
    {
        var dir = Vector2.Normalize(b1.Position - b2.Position);
        b1.Direction = dir;
        b2.Direction = -dir;
    }

    public void Update()
    {
        foreach (var circle in _circles)
        {
            circle.Update();
        }

        CheckCollisions();
    }

    public void Draw()
    {
        foreach (var circle in _circles)
        {
            circle.Draw();
        }
    }
}
