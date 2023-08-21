namespace Project003;

public class MonsterManger
{
    private readonly List<Monster> _monsters = new();
    private readonly Texture2D _monsterTex;

    public MonsterManger()
    {
        _monsterTex = Globals.Content.Load<Texture2D>("hero");
    }

    public void SpawnMonster(int column)
    {
        Vector2 pos = new((column + 0.5f) * Map.TileSize.X, 0);
        Monster monster = new(_monsterTex, pos);
        monster.SetPath(Pathfinder.BFSearch(monster.Position, new(column, Map.Size.Y - 1)));
        _monsters.Add(monster);
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
