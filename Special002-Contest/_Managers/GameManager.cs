namespace Special002;

public class GameManager
{
    private const int BULLET_COUNT = 50;
    private readonly Game _game;
    private readonly GraphicsDeviceManager _graphics;
    private readonly List<Bullet> _bullets = new();
    private readonly List<Sprite> _targets = new();
    private readonly Hero _hero;
    private readonly Texture2D _bTex;
    private readonly Texture2D _tTex;
    private readonly Canvas _canvas;
    private readonly Timer _timer;

    public GameManager(Game game, GraphicsDeviceManager graphics)
    {
        _game = game;
        _graphics = graphics;
        _canvas = new(_graphics.GraphicsDevice, 1600, 900);

        _hero = new(Globals.Content.Load<Texture2D>("orb"));
        _bTex = Globals.Content.Load<Texture2D>("bullet");
        _tTex = Globals.Content.Load<Texture2D>("target");

        _timer = new(
            Globals.Content.Load<SpriteFont>("font"),
            Color.DimGray * 0.5f,
            new((Globals.SCREEN_WIDTH / 2) - 110, (Globals.SCREEN_HEIGHT / 2) - 128),
            20f
        );

        _timer.OnTimer += ResetEvent;

        Reset();

        SetFullScreen();
    }

    private void SetFullScreen()
    {
        _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        _game.Window.IsBorderless = true;
        _graphics.ApplyChanges();
        InputManager.Scale = _canvas.SetDestinationRectangle();
    }

    public void ResetEvent(object sender, EventArgs e)
    {
        Reset();
    }

    public void Reset()
    {
        Globals.Slowed = true;
        _bullets.Clear();
        _targets.Clear();
        _hero.Reset();

        for (int i = 0; i < BULLET_COUNT; i++)
        {
            AddBullet();
        }

        _targets.Add(new(_tTex, new(100, 100)));
        _targets.Add(new(_tTex, new(Globals.SCREEN_WIDTH - 100, 100)));
        _targets.Add(new(_tTex, new(100, Globals.SCREEN_HEIGHT - 100)));
        _targets.Add(new(_tTex, new(Globals.SCREEN_WIDTH - 100, Globals.SCREEN_HEIGHT - 100)));

        _timer.Reset();
    }

    public void AddBullet()
    {
        _bullets.Add(new(_bTex));
    }

    public void CheckCollision()
    {
        bool reset = false;

        foreach (var _bullet in _bullets)
        {
            if (Vector2.Distance(_bullet.position, _hero.position) < 46)
            {
                reset = true;
            }
        }

        if (reset) Reset();
    }

    public void CheckTargets()
    {
        foreach (var _target in _targets)
        {
            if (Vector2.Distance(_target.position, _hero.position) < 52)
            {
                _target.Dead = true;
                for (int i = 0; i < 10; i++)
                {
                    AddBullet();
                }
            }
        }

        _targets.RemoveAll(t => t.Dead);
    }

    public void Update()
    {
        if (_targets.Count < 1)
        {
            Reset();
            return;
        }

        _timer.Update();

        foreach (var _bullet in _bullets)
        {
            _bullet.Update();
        }

        _hero.Update();

        CheckTargets();
        CheckCollision();
    }

    public void Draw()
    {
        _canvas.Activate();
        Globals.SpriteBatch.Begin();

        _timer.Draw();

        foreach (var _target in _targets)
        {
            _target.Draw();
        }

        _hero.Draw();

        foreach (var _bullet in _bullets)
        {
            _bullet.Draw();
        }

        Globals.SpriteBatch.End();
        _canvas.Draw(Globals.SpriteBatch);
    }
}
