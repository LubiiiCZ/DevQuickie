namespace Project001;

public static class ScoreManager
{
    private static float _firstRoundTime;
    private static float _turnTime;
    public static float TurnTimeLeft { get; private set; }
    private static Texture2D _texture;
    private static Rectangle _rectangle;
    public static float Score { get; private set; }
    public static bool Active { get; private set; }

    public static void Init()
    {
        _texture = new Texture2D(Globals.SpriteBatch.GraphicsDevice, 1, 1);
        _texture.SetData(new Color[] { new(200, 80, 30) });
        _rectangle = new(0, 0, Globals.Bounds.X, 20);
    }

    public static void SetDifficulty(Difficulty dificulty)
    {
        _firstRoundTime = dificulty switch
        {
            Difficulty.Easy => 30,
            Difficulty.Medium => 25,
            Difficulty.Hard => 20,
            _ => 20
        };
    }

    public static void Start()
    {
        Active = true;
    }

    public static void Stop()
    {
        Active = false;
    }

    public static void Reset()
    {
        _turnTime = _firstRoundTime;
        TurnTimeLeft = _turnTime;
        Score = 0;
        Active = false;
        _rectangle.Width = Globals.Bounds.X;
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
        if (!Active) return;

        TurnTimeLeft -= Globals.Time;
        _rectangle.Width = (int)(Globals.Bounds.X * TurnTimeLeft / _turnTime);
    }

    public static void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, _rectangle, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
    }
}
