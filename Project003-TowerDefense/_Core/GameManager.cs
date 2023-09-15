namespace Project003;

public class GameManager
{
    private readonly Canvas _canvas;
    public readonly Map map;
    public readonly MonsterManager monsterManager;
    public readonly SpellManager spellManager;
    public readonly UIManager uiManager;
    public readonly RewardManager rewardManager;
    public readonly List<Monsters> monstersInWave = new();
    public Queue<RewardItem> Rewards { get; set; } = new();
    public Rewards CurrentReward { get; set; }
    public Spells CurrentSpell { get; set; }
    public SelectionData CurrentSelectionData { get; set; }

    public GameManager(GraphicsDeviceManager graphics)
    {
        rewardManager = new(graphics.GraphicsDevice);
        map = new();
        monsterManager = new(map, graphics.GraphicsDevice);
        spellManager = new();
        _canvas = new(graphics.GraphicsDevice, Map.TILE_SIZE * Map.SIZE_X, Map.TILE_SIZE * (Map.SIZE_Y + 1));
        uiManager = new();
        uiManager.buttonStartWave.OnTap += StartWave;
        StateManager.Initialize(this);
    }

    public void AssignTargets()
    {
        map.Towers.ForEach(t => t.SelectTarget(monsterManager.MonstersInWave));
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
