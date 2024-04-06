namespace Challenge007;

public class ThingManager
{
    private readonly List<Thing> _cars = [];
    private readonly List<Thing> _logs = [];

    public void AddCar(Thing c)
    {
        _cars.Add(c);
    }

    public void AddLog(Thing l)
    {
        _logs.Add(l);
    }

    public void Reset()
    {
        _logs.Clear();
        _cars.Clear();
        GenerateCars();
        GenerateLogs();
    }

    public void GenerateLogs()
    {
        AddLog(new(new(Globals.TileSize * 1, Globals.TileSize * 5, Globals.TileSize * 3, Globals.TileSize),
            200, new(1, 0), Color.Brown));
        AddLog(new(new(Globals.TileSize * 5, Globals.TileSize * 5, Globals.TileSize * 3, Globals.TileSize),
            200, new(1, 0), Color.Brown));

        AddLog(new(new(Globals.TileSize * 1, Globals.TileSize * 4, Globals.TileSize * 2, Globals.TileSize),
            150, new(-1, 0), Color.Brown));
        AddLog(new(new(Globals.TileSize * 4, Globals.TileSize * 4, Globals.TileSize * 3, Globals.TileSize),
            150, new(-1, 0), Color.Brown));

        AddLog(new(new(Globals.TileSize * 0, Globals.TileSize * 3, Globals.TileSize * 2, Globals.TileSize),
            250, new(1, 0), Color.Brown));
        AddLog(new(new(Globals.TileSize * 3, Globals.TileSize * 3, Globals.TileSize * 2, Globals.TileSize),
            250, new(1, 0), Color.Brown));
        AddLog(new(new(Globals.TileSize * 7, Globals.TileSize * 3, Globals.TileSize * 2, Globals.TileSize),
            250, new(1, 0), Color.Brown));

        AddLog(new(new(Globals.TileSize * 3, Globals.TileSize * 2, Globals.TileSize * 4, Globals.TileSize),
            200, new(-1, 0), Color.Brown));

        AddLog(new(new(Globals.TileSize * 1, Globals.TileSize * 1, Globals.TileSize * 3, Globals.TileSize),
            150, new(1, 0), Color.Brown));
    }

    public void GenerateCars()
    {
        AddCar(new(new(Globals.TileSize * 2, Globals.TileSize * 11, Globals.TileSize, Globals.TileSize),
            200, new(-1, 0), Color.Red));
        AddCar(new(new(Globals.TileSize * 6, Globals.TileSize * 11, Globals.TileSize, Globals.TileSize),
            200, new(-1, 0), Color.Red));

        AddCar(new(new(Globals.TileSize * 0, Globals.TileSize * 10, Globals.TileSize, Globals.TileSize),
            200, new(1, 0), Color.Yellow));
        AddCar(new(new(Globals.TileSize * 4, Globals.TileSize * 10, Globals.TileSize, Globals.TileSize),
            200, new(1, 0), Color.Yellow));

        AddCar(new(new(Globals.TileSize * 3, Globals.TileSize * 9, Globals.TileSize, Globals.TileSize),
            250, new(-1, 0), Color.Red));
        AddCar(new(new(Globals.TileSize * 7, Globals.TileSize * 9, Globals.TileSize, Globals.TileSize),
            250, new(-1, 0), Color.Red));

        AddCar(new(new(Globals.TileSize * 1, Globals.TileSize * 8, Globals.TileSize * 2, Globals.TileSize),
            150, new(1, 0), Color.Orange));
        AddCar(new(new(Globals.TileSize * 6, Globals.TileSize * 8, Globals.TileSize * 2, Globals.TileSize),
            150, new(1, 0), Color.Orange));

        AddCar(new(new(Globals.TileSize * 5, Globals.TileSize * 7, Globals.TileSize * 3, Globals.TileSize),
            300, new(-1, 0), Color.Purple));
    }

    public bool CheckCarCollision(Frog frog)
    {
        foreach (var car in _cars)
        {
            if (car.R.Intersects(frog.R)) return true;
        }

        return false;
    }

    public bool CheckLogCollision(Frog frog)
    {
        if (frog.Moving) return false;

        foreach (var log in _logs)
        {
            if (log.R.Intersects(frog.R))
            {
                frog.Log = log;
                return true;
            }
        }

        return false;
    }

    public void Update()
    {
        _cars.ForEach(c => c.UpdateMovement());
        _logs.ForEach(l => l.UpdateMovement());
    }

    public void Draw()
    {
        _cars.ForEach(c => c.Draw());
        _logs.ForEach(l => l.Draw());
    }
}
