namespace Project003;

public class GameManager
{
    private readonly Canvas _canvas;
    public readonly Map map;
    public readonly Button button;
    private readonly Texture2D _buttonTex;
    public readonly MonsterManger monsterManager;

    public GameManager(GraphicsDeviceManager graphics)
    {
        StateManager.Initialize(this);
        map = new();
        monsterManager = new(map);
        _canvas = new(graphics.GraphicsDevice, Map.TILE_SIZE * Map.SIZE_X,
            Map.TILE_SIZE * (Map.SIZE_Y + 1));

        _buttonTex = Globals.Content.Load<Texture2D>("button");
        button = new(_buttonTex, new Vector2(32, 13 * 64 - 32));
        button.OnTap += StartWave;
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
        monsterManager.SpawnMonsters(16);
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
