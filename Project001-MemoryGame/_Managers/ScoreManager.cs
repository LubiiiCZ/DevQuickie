namespace Project001;

public static class ScoreManager
{
    private const float FIRST_ROUND_TIME = 20;
    private static readonly int _screenWidth;
    private static float _turnTime;
    public static float TurnTimeLeft { get; private set; }
    private static readonly Texture2D _texture;
    private static Rectangle _rectangle;
    public static float Score { get; private set; }
    private static bool _active;

    static ScoreManager()
    {
        _turnTime = FIRST_ROUND_TIME;
        TurnTimeLeft = _turnTime;
        _active = false;

        _texture = new Texture2D(Globals.SpriteBatch.GraphicsDevice, 1, 1);
        _texture.SetData(new Color[] { new(200, 80, 30) });

        _screenWidth = Globals.SpriteBatch.GraphicsDevice.PresentationParameters.BackBufferWidth;
        _rectangle = new(0, 0, _screenWidth, 20);
    }

    public static void Start()
    {
        _active = true;
    }

    public static void Stop()
    {
        _active = false;
    }

    public static void Reset()
    {
        _turnTime = FIRST_ROUND_TIME;
        TurnTimeLeft = _turnTime;
        Score = 0;
        _active = false;
        _rectangle.Width = _screenWidth;
    }

    public static void NextTurn()
    {
        Score += 10 * TurnTimeLeft;
        _turnTime--;
        TurnTimeLeft = _turnTime;
    }

    public static void Miss()
    {
        Score -= 10;
    }

    public static void Update()
    {
        if (!_active) return;

        TurnTimeLeft -= Globals.Time;
        _rectangle.Width = (int)(_screenWidth * TurnTimeLeft / _turnTime);
    }

    public static void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, _rectangle, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
    }
}
