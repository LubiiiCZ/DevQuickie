namespace Project003;

public class GameManager
{
    private readonly Canvas _canvas;
    private readonly Map _map;
    private readonly Hero _hero;
    private readonly List<Monster> _monsters = new();
    private readonly Texture2D _monsterTex;
    private readonly Button _button;

    public GameManager(GraphicsDeviceManager graphics)
    {
        _canvas = new(graphics.GraphicsDevice, 64 * Map.Size.X, 64 * (Map.Size.Y + 1));
        _map = new();
        _hero = new(Globals.Content.Load<Texture2D>("hero"), Vector2.Zero);
        _monsterTex = Globals.Content.Load<Texture2D>("hero");
        Pathfinder.Init(_map, _hero);

        for (int i = 0; i < 10; i++)
        {
            SpawnMonster();
        }

        Monster.OnDeath += (e, a) => SpawnMonster();

        _button = new(_monsterTex, new Vector2(32, 13 * 64 - 32));
        _button.OnTap += (e, a) => SpawnMonster();
    }

    public void SpawnMonster()
    {
        Random r = new();
        Vector2 pos = new(r.Next(64, 448), 0);

        _monsters.Add(new(_monsterTex, pos));
    }

    public void Update()
    {
        _button.Update();
        _map.Update();
        _hero.Update();

        foreach (var monster in _monsters.ToArray())
        {
            monster.Update();
        }

        _monsters.RemoveAll(m => m.Dead);
    }

    public void Draw()
    {
        _canvas.Activate();

        Globals.SpriteBatch.Begin();

            _map.Draw();

            foreach (var monster in _monsters)
            {
                monster.Draw();
            }

            _button.Draw();

        Globals.SpriteBatch.End();

        _canvas.Draw(Globals.SpriteBatch);
    }
}
