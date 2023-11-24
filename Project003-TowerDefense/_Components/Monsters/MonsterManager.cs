namespace Project003;

public class MonsterManager
{
    public List<Monster> MonstersInWave { get; } = new();
    private readonly MonsterFactory _monsterFactory;
    private readonly Pathfinder _pathfinder;
    private readonly int[] _monsterLaneSlots = new int[Map.SIZE_X];
    private readonly Texture2D _hpBarTexture;

    public MonsterManager(Map map, GraphicsDevice graphicsDevice)
    {
        _monsterFactory = new();
        _pathfinder = new(map);
        _hpBarTexture = new(graphicsDevice, 1, 1);
        _hpBarTexture.SetData(new Color[] { Color.DarkGreen });
    }

    public void Reset()
    {
        MonstersInWave.Clear();
    }

    public void AdjustAllMonstersSpeed(int percentage)
    {
        foreach (var monster in MonstersInWave)
        {
            var newSpeed = (100 + percentage) / 100 * monster.Data.Speed;
            monster.Data.Speed = newSpeed;
            monster.Data.CurrentSpeed = newSpeed;
        }
    }

    public void AdjustAllMonstersHealth(int percentage)
    {
        foreach (var monster in MonstersInWave)
        {
            var newHealth = (100 + percentage) / 100 * monster.Data.MaxHealth;
            monster.Data.MaxHealth = newHealth;
            monster.Data.Health = newHealth;
        }
    }

    public bool CheckPlacementValidity(int x, int y)
    {
        return _pathfinder.CheckPlacementValidity(x, y);
    }

    private void DrawHPBar(Monster monster)
    {
        Vector2 barPosition = new(monster.Position.X - monster.Origin.X + 4, monster.Position.Y - monster.Origin.Y - 5);
        var width = monster.Data.Health / monster.Data.MaxHealth * (Map.TILE_SIZE - 8);
        Rectangle destRectangle = new((int)barPosition.X, (int)barPosition.Y, (int)width, 3);
        Globals.SpriteBatch.Draw(_hpBarTexture, destRectangle, Color.White);
    }

    public void DrawHPBars()
    {
        MonstersInWave.ForEach(DrawHPBar);
    }

    private void PrepareMonsterSlots(int count)
    {
        Random r = new();

        for (int i = 0; i < Map.SIZE_X; i++)
        {
            _monsterLaneSlots[i] = 0;
        }

        for (int i = 0; i < count; i++)
        {
            _monsterLaneSlots[r.Next(0, Map.SIZE_X)]++;
        }
    }

    public void SpawnMonsters(List<Monsters> monsters, int waveNumber)
    {
        List<Monsters> currentMonsters = new();
        currentMonsters.AddRange(monsters);

        if (waveNumber % 3 == 0)
        {
            currentMonsters.Clear();
            currentMonsters.Add(Monsters.Boss);
        }

        PrepareMonsterSlots(currentMonsters.Count);
        currentMonsters.Shuffle();
        var monsterCounter = 0;

        for (int i = 0; i < _monsterLaneSlots.Length; i++)
        {
            var row = 0;
            for (int m = 0; m < _monsterLaneSlots[i]; m++)
            {
                SpawnMonster(currentMonsters[monsterCounter], i, row);
                monsterCounter++;
                row++;
            }
        }
    }

    private void SpawnMonster(Monsters type, int column, int row)
    {
        Vector2 pos = new((column + 0.5f) * Map.TILE_SIZE, -row * Map.TILE_SIZE);
        Monster monster = _monsterFactory.CreateMonster(type, pos);

        if (!monster.Data.Flying)
        {
            monster.SetPath(_pathfinder.BFSearch(monster.Position, new(column, Map.SIZE_Y - 1)));
        }
        else
        {
            monster.SetPath(new(){ new(monster.Position.X, Map.SIZE_Y * Map.TILE_SIZE) });
        }

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

    public void DoSplashDamage(int dmg, DamageTypes damageType, TargetingTypes targetingType, Vector2 center, float radius)
    {
        foreach (var monster in MonstersInWave)
        {
            if (!monster.Data.Flying && targetingType == TargetingTypes.Air) continue;
            if (monster.Data.Flying && targetingType == TargetingTypes.Ground) continue;

            if (Vector2.Distance(monster.Position, center) <= radius)
            {
                monster.TakeDamage(dmg, damageType);
            }
        }
    }

    public void ApplyEffectArea(Vector2 center, float radius, TargetingTypes targetingType, Effects effect, int count = 1)
    {
        foreach (var monster in MonstersInWave)
        {
            if (!monster.Data.Flying && targetingType == TargetingTypes.Air) continue;
            if (monster.Data.Flying && targetingType == TargetingTypes.Ground) continue;

            if (Vector2.Distance(monster.Position, center) <= radius)
            {
                for (int i = 0; i < count; i++)
                {
                    BuffFactory.CreateBuff(monster, effect);
                }
            }
        }
    }

    public Monster SelectNearestTarget(Vector2 position, TargetingTypes targetingType)
    {
        float minDistance = float.MaxValue;
        Monster result = null;

        foreach (var monster in MonstersInWave)
        {
            if (!monster.Data.Flying && targetingType == TargetingTypes.Air) continue;
            if (monster.Data.Flying && targetingType == TargetingTypes.Ground) continue;

            var distance = Vector2.Distance(position, monster.Position);
            if (distance < minDistance)
            {
                minDistance = distance;
                result = monster;
            }
        }

        return result;
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

    public void UpdateMineCollisions(List<Mine> mines)
    {
        foreach (var monster in MonstersInWave)
        {
            if (monster.Dead) continue;

            foreach (var mine in mines)
            {
                if (mine.Used) continue;

                if (Vector2.Distance(monster.Position, mine.Position) <= mine.Range)
                {
                    monster.TakeDamage(mine.Damage, mine.DamageType);
                    mine.Used = true;
                }
            }
        }
    }
}
