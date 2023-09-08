namespace Project003;

public class MonsterManager
{
    public List<Monster> MonstersInWave { get; } = new();
    private readonly MonsterFactory _monsterFactory;
    private readonly Pathfinder _pathfinder;
    private readonly int[] _monsterLaneCounter = new int[Map.SIZE_X];
    private readonly Texture2D _hpBarTexture;

    public MonsterManager(Map map, GraphicsDevice graphicsDevice)
    {
        _monsterFactory = new();
        _pathfinder = new(map);
        _hpBarTexture = new(graphicsDevice, 1, 1);
        _hpBarTexture.SetData(new Color[] { Color.DarkGreen });

        for (int i = 0; i < Map.SIZE_X; i++)
        {
            _monsterLaneCounter[i] = new();
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
        foreach (var monster in MonstersInWave)
        {
            DrawHPBar(monster);
        }
    }

    private int RandomColumn()
    {
        Random r = new();
        return r.Next(0, Map.SIZE_X);
    }

    private void FillMonsterLanes(int count)
    {
        for (int i = 0; i < Map.SIZE_X; i++)
        {
            _monsterLaneCounter[i] = 0;
        }

        for (int i = 0; i < count; i++)
        {
            _monsterLaneCounter[RandomColumn()]++;
        }
    }

    public void SpawnMonsters(List<Monsters> monsters)
    {
        FillMonsterLanes(monsters.Count);
        var monsterCounter = 0;
        var row = 0;
        //Shuffle the list first?

        while (monsterCounter < monsters.Count)
        {
            for (int i = 0; i < _monsterLaneCounter.Length; i++)
            {
                if (_monsterLaneCounter[i] > 0)
                {
                    SpawnMonster(monsters[monsterCounter], i, row);
                    monsterCounter++;
                    if (monsterCounter >= monsters.Count) break;
                }
            }
            row++;
        }
    }

    public void SpawnMonster(Monsters type, int column, int row)
    {
        Vector2 pos = new((column + 0.5f) * Map.TILE_SIZE, -row * Map.TILE_SIZE);
        Monster monster = _monsterFactory.CreateMonster(type, pos);
        monster.SetPath(_pathfinder.BFSearch(monster.Position, new(column, Map.SIZE_Y - 1)));
        MonstersInWave.Add(monster);
    }

    public event EventHandler OnWaveEnd;

    public void Update()
    {
        foreach (var monster in MonstersInWave.ToArray())
        {
            monster.Update();
        }

        MonstersInWave.RemoveAll(m => m.Dead);

        if (MonstersInWave.Count < 1)
        {
            OnWaveEnd?.Invoke(this, EventArgs.Empty);
        }
    }

    public void CheckWaveEnd()
    {
        if (MonstersInWave.Count < 1)
        {
            OnWaveEnd?.Invoke(this, EventArgs.Empty);
        }
    }

    public void Draw()
    {
        foreach (var monster in MonstersInWave)
        {
            monster.Draw();
        }
    }
}
