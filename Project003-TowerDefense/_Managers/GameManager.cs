namespace Project003;

public class GameManager
{
    private readonly Canvas _canvas;
    public readonly Map map;
    public readonly MonsterManger monsterManager;
    public readonly UIManager uiManager;
    public readonly RewardManager rewardManager;
    public int monstersInWave = 0;
    public Queue<RewardItem> Rewards { get; set; } = new();
    public Rewards CurrentReward { get; set; }

    public GameManager(GraphicsDeviceManager graphics)
    {
        rewardManager = new(graphics.GraphicsDevice);
        map = new();
        monsterManager = new(map, graphics.GraphicsDevice);
        _canvas = new(graphics.GraphicsDevice, Map.TILE_SIZE * Map.SIZE_X, Map.TILE_SIZE * (Map.SIZE_Y + 1));
        uiManager = new();
        uiManager.buttonStartWave.OnTap += StartWave;
        StateManager.Initialize(this);
    }

    public void AssignTargets()
    {
        map.Towers.ForEach(t => t.SelectTarget(monsterManager.Monsters));
    }

    public void StartWave(object sender, EventArgs eventArgs)
    {
        monsterManager.SpawnMonsters(monstersInWave);
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
