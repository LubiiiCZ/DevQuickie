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
        monsterManager = new();
        _canvas = new(graphics.GraphicsDevice, 64 * Map.Size.X, 64 * (Map.Size.Y + 1));
        map = new();
        _buttonTex = Globals.Content.Load<Texture2D>("button");

        Pathfinder.Init(map);

        //SpawnMonsters();
        //Monster.OnDeath += (e, a) => SpawnMonster();

        button = new(_buttonTex, new Vector2(32, 13 * 64 - 32));
        button.OnTap += (e, a) => StartWave();
    }

    public void StartWave()
    {
        for (int i = 0; i < Map.Size.X; i++)
        {
            monsterManager.SpawnMonster(i);
        }

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
