namespace Project003;

public class GameManager
{
    private readonly Canvas _canvas;
    public readonly Map map;
    public readonly MonsterManger monsterManager;
    public readonly UIManager uiManager;
    public readonly RewardManager rewardManager;
    public int monstersInWave = 0;
    public Rewards CurrentReward { get; set; }
    public int RewardCount { get; set; }

    public GameManager(GraphicsDeviceManager graphics)
    {
        rewardManager = new();
        map = new();
        monsterManager = new(map, graphics.GraphicsDevice);
        _canvas = new(graphics.GraphicsDevice, Map.TILE_SIZE * Map.SIZE_X, Map.TILE_SIZE * (Map.SIZE_Y + 1));
        uiManager = new();
        uiManager.buttonStartWave.OnTap += StartWave;
        StateManager.Initialize(this);
    }

    public void AssignTargets()
    {
        foreach (var tower in map.Towers)
        {
            if (tower.CooldownLeft > 0) continue;
            var monster = monsterManager.GetClosestMonster(tower.Position, tower.Range);
            if (monster is not null) tower.Target = monster;
        }
    }

    public void StartWave(object sender, EventArgs eventArgs)
    {
        monsterManager.SpawnMonsters(monstersInWave);
        StateManager.SwitchState(States.PlayState);
    }

    public void Update()
    {
        StateManager.Update();
    }

    public void Draw()
    {
        _canvas.Activate();

        Globals.SpriteBatch.Begin();
            StateManager.Draw();
        Globals.SpriteBatch.End();

        _canvas.Draw(Globals.SpriteBatch);
    }
}
