namespace LiveProject001;

public class GameManager
{
    private readonly Canvas _canvas;
    public readonly Map map;
    public readonly MonsterManager monsterManager;
    public readonly SpellManager spellManager;
    public readonly UIManager uiManager;
    public readonly RewardManager rewardManager;
    public readonly GameEventManager gameEventManager;
    public readonly List<Monsters> monstersInWave = new();
    public Queue<RewardItem> Rewards { get; set; } = new();
    public Rewards CurrentReward { get; set; }
    public int RewardsLeft { get; set; }
    public int RewardRerolls { get; set; }
    public Spell CurrentSpell { get; set; }
    public Tile CurrentTile { get; set; }
    public int PlayerLives { get; set; }
    public int WaveNumber { get; set; }
    public bool WaveInProgress { get; set; }

    public GameManager(GraphicsDeviceManager graphics)
    {
        rewardManager = new(graphics.GraphicsDevice);
        map = new();
        monsterManager = new(map, graphics.GraphicsDevice);
        DamageHelper.Initialize(monsterManager);
        spellManager = new();
        gameEventManager = new(this);

        _canvas = new(graphics.GraphicsDevice, Map.TILE_SIZE * Map.SIZE_X, Map.TILE_SIZE * (Map.SIZE_Y + 1));
        uiManager = new();
        uiManager.buttonStartWave.OnTap += StartWave;
        TileObjectFactory.Initialize();
        StateManager.Initialize(this);

        Monster.OnGoalReached += HandleMonsterReachedGoal;

        ResetGame();
    }

    public void HandleMonsterReachedGoal(object sender, EventArgs args)
    {
        PlayerLives--;
    }

    public void ResetGame()
    {
        PlayerLives = 10;
        RewardsLeft = 3;
        RewardRerolls = 3;
        WaveNumber = 1;
        WaveInProgress = false;
        monstersInWave.Clear();
        spellManager.Reset();
        monsterManager.Reset();
        map.Reset();
        StateManager.SwitchState(States.Reward);
        InputManager.IsDragging = false;
    }

    public void AssignTargets()
    {
        map.Towers.ForEach(t => t.SelectTarget(monsterManager.MonstersInWave));
    }

    public void StartWave(object sender, EventArgs eventArgs)
    {
        WaveInProgress = true;
        monsterManager.SpawnMonsters(monstersInWave, WaveNumber);
        gameEventManager.ApplyRandomEvent();
        StateManager.SwitchState(States.Play);
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
