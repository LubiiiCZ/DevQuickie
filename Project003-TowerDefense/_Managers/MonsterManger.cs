namespace Project003;

public class MonsterManger
{
    public List<Monster> Monsters { get; } = new();
    private readonly Texture2D _monsterTex;
    private readonly Pathfinder _pathfinder;
    private readonly List<int>[] _monsterQueues = new List<int>[Map.SIZE_X];
    private readonly Texture2D _hpBarTexture;

    public MonsterManger(Map map, GraphicsDevice graphicsDevice)
    {
        _monsterTex = Globals.Content.Load<Texture2D>("hero");
        _pathfinder = new(map);
        _hpBarTexture = new(graphicsDevice, 1, 1);
        _hpBarTexture.SetData(new Color[] { Color.DarkGreen });

        for (int i = 0; i < Map.SIZE_X; i++)
        {
            _monsterQueues[i] = new();
        }
    }

    public bool CheckPlacementValidity(int x, int y)
    {
        return _pathfinder.CheckPlacementValidity(x, y);
    }

    private void DrawHPBar(Monster monster)
    {
        Vector2 barPosition = new(monster.Position.X - monster.Origin.X + 4, monster.Position.Y - monster.Origin.Y - 5);
        var width = (float)monster.Health / monster.MaxHealth * (Map.TILE_SIZE - 8);
        Rectangle destRectangle = new((int)barPosition.X, (int)barPosition.Y, (int)width, 3);
        Globals.SpriteBatch.Draw(_hpBarTexture, destRectangle, Color.White);
    }

    public void DrawHPBars()
    {
        foreach (var monster in Monsters)
        {
            DrawHPBar(monster);
        }
    }

    private int RandomColumn()
    {
        Random r = new();
        return r.Next(0, Map.SIZE_X);
    }

    private void FillMonsterQueues(int count)
    {
        for (int i = 0; i < Map.SIZE_X; i++)
        {
            _monsterQueues[i].Clear();
        }

        for (int i = 0; i < count; i++)
        {
            _monsterQueues[RandomColumn()].Add(1);
        }
    }

    public void SpawnMonsters(int count)
    {
        FillMonsterQueues(count);

        for (int i = 0; i < _monsterQueues.Length; i++)
        {
            var row = 0;
            foreach (var monster in _monsterQueues[i])
            {
                SpawnMonster(i, row);
                row++;
            }
        }
    }

    public void SpawnMonster(int column, int row)
    {
        Vector2 pos = new((column + 0.5f) * Map.TILE_SIZE, -row * Map.TILE_SIZE);
        Monster monster = new(_monsterTex, pos);
        monster.SetPath(_pathfinder.BFSearch(monster.Position, new(column, Map.SIZE_Y - 1)));
        Monsters.Add(monster);
    }

    public Monster GetClosestMonster(TowerTile tower)
    {
        /*if (tower.Target is not null && Vector2.Distance(tower.Position, tower.Target.Position) <= tower.Range)
        {
            return tower.Target;
        }*/

        Monster result = null;
        float minDistance = float.MaxValue;

        foreach (var monster in Monsters)
        {
            var distance = Vector2.Distance(tower.Position, monster.Position);
            if (distance < minDistance)
            {
                minDistance = distance;
                result = monster;
            }
        }

        if (minDistance > tower.Range) result = null;
        return result;
    }

    public void Update()
    {
        foreach (var monster in Monsters.ToArray())
        {
            monster.Update();
        }

        Monsters.RemoveAll(m => m.Dead);

        if (Monsters.Count < 1)
        {
            StateManager.SwitchState(States.Reward);
        }
    }

    public void Draw()
    {
        foreach (var monster in Monsters)
        {
            monster.Draw();
        }
    }
}
