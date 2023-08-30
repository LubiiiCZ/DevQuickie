namespace Project003;

public class MonsterManger
{
    private readonly List<Monster> _monsters = new();
    private readonly Texture2D _monsterTex;
    private readonly Pathfinder _pathfinder;
    private readonly List<int>[] _monsterQueues = new List<int>[Map.SIZE_X];

    public MonsterManger(Map map)
    {
        _monsterTex = Globals.Content.Load<Texture2D>("hero");
        _pathfinder = new(map);

        for (int i = 0; i < Map.SIZE_X; i++)
        {
            _monsterQueues[i] = new();
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
        _monsters.Add(monster);
    }

    public Monster GetClosestMonster(Vector2 position, float range)
    {
        Monster result = null;
        float minDistance = float.MaxValue;

        foreach (var monster in _monsters)
        {
            var distance = Vector2.Distance(position, monster.Position);
            if (distance < minDistance)
            {
                minDistance = distance;
                result = monster;
            }
        }

        if (minDistance > range) result = null;

        return result;
    }

    public void Update()
    {
        foreach (var monster in _monsters.ToArray())
        {
            monster.Update();
        }

        _monsters.RemoveAll(m => m.Dead);

        if (_monsters.Count < 1)
        {
            StateManager.SwitchState(States.IdleState);
        }
    }

    public void Draw()
    {
        foreach (var monster in _monsters)
        {
            monster.Draw();
        }
    }
}
