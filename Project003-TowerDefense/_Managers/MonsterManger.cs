namespace Project003;

public class MonsterManger
{
    private readonly List<Monster> _monsters = new();
    private readonly Texture2D _monsterTex;
    private readonly Pathfinder _pathfinder;

    public MonsterManger(Map map)
    {
        _monsterTex = Globals.Content.Load<Texture2D>("hero");
        _pathfinder = new(map);
    }

    public void SpawnMonster(int column)
    {
        Vector2 pos = new((column + 0.5f) * Map.TILE_SIZE, 0);
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
