namespace Project003;

public class GameManager
{
    private readonly Canvas _canvas;
    private readonly Map _map;
    private readonly Button _button;
    private readonly Texture2D _buttonTex;
    private readonly MonsterManger _monsterManager;

    public GameManager(GraphicsDeviceManager graphics)
    {
        _monsterManager = new();
        _canvas = new(graphics.GraphicsDevice, 64 * Map.Size.X, 64 * (Map.Size.Y + 1));
        _map = new();
        _buttonTex = Globals.Content.Load<Texture2D>("button");

        Pathfinder.Init(_map);

        SpawnMonsters();

        //Monster.OnDeath += (e, a) => SpawnMonster();

        _button = new(_buttonTex, new Vector2(32, 13 * 64 - 32));
        _button.OnTap += (e, a) => SpawnMonsters();
    }

    public void SpawnMonsters()
    {
        for (int i = 0; i < Map.Size.X; i++)
        {
            _monsterManager.SpawnMonster(i);
        }
    }

    public void Update()
    {
        _monsterManager.Update();
        _button.Update();
        _map.Update();
    }

    public void Draw()
    {
        _canvas.Activate();

        Globals.SpriteBatch.Begin();

            _map.Draw();
            _monsterManager.Draw();
            _button.Draw();

        Globals.SpriteBatch.End();

        _canvas.Draw(Globals.SpriteBatch);
    }
}
