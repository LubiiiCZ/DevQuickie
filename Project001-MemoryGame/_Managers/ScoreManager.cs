namespace Project001;

public static class ScoreManager
{
    private static float _firstRoundTime;
    private static float _turnTime;
    public static float TurnTimeLeft { get; private set; }
    private static Texture2D _texture;
    private static Rectangle _rectangle;
    public static int Score { get; private set; }
    public static bool Active { get; private set; }
    private const string _fileName = "highscores.dat";
    private static Difficulty _currentDifficulty;
    public static Dictionary<Difficulty, int> HighScores { get; } = new();
    public static Dictionary<Difficulty, Label> Labels { get; } = new();

    public static void Init()
    {
        var font = Globals.Content.Load<SpriteFont>("Menu/font");
        var y = Globals.Bounds.Y / 2;
        var x = Globals.Bounds.X / 2;

        HighScores.Add(Difficulty.Easy, 0);
        HighScores.Add(Difficulty.Medium, 0);
        HighScores.Add(Difficulty.Hard, 0);

        Labels.Add(Difficulty.Easy, new(font, new(x - 300, y + 120)));
        Labels[Difficulty.Easy].SetText(HighScores[Difficulty.Easy].ToString());
        Labels.Add(Difficulty.Medium, new(font, new(x, y + 120)));
        Labels[Difficulty.Medium].SetText(HighScores[Difficulty.Medium].ToString());
        Labels.Add(Difficulty.Hard, new(font, new(x + 300, y + 120)));
        Labels[Difficulty.Hard].SetText(HighScores[Difficulty.Hard].ToString());

        _texture = new Texture2D(Globals.SpriteBatch.GraphicsDevice, 1, 1);
        _texture.SetData(new Color[] { new(200, 80, 30) });
        _rectangle = new(0, 0, Globals.Bounds.X, 20);
        LoadScores();
    }

    public static void UpdateScores()
    {
        Labels[Difficulty.Easy].SetText(HighScores[Difficulty.Easy].ToString());
        Labels[Difficulty.Medium].SetText(HighScores[Difficulty.Medium].ToString());
        Labels[Difficulty.Hard].SetText(HighScores[Difficulty.Hard].ToString());
    }

    public static void DrawHighScores()
    {
        foreach (var label in Labels)
        {
            label.Value.Draw();
        }
    }

    public static void LoadScores()
    {
        if (File.Exists(_fileName))
        {
            using BinaryReader binaryReader = new(File.Open(_fileName, FileMode.Open));

            HighScores[Difficulty.Easy] = binaryReader.ReadInt32();
            HighScores[Difficulty.Medium] = binaryReader.ReadInt32();
            HighScores[Difficulty.Hard] = binaryReader.ReadInt32();

            binaryReader.Close();
        }

        UpdateScores();
    }

    public static void SaveScores()
    {
        HighScores[_currentDifficulty] = Math.Max(HighScores[_currentDifficulty], Score);
        UpdateScores();

        using BinaryWriter binaryWriter = new(File.Create(_fileName));

        binaryWriter.Write(HighScores[Difficulty.Easy]);
        binaryWriter.Write(HighScores[Difficulty.Medium]);
        binaryWriter.Write(HighScores[Difficulty.Hard]);

        binaryWriter.Close();
    }

    public static void SetDifficulty(Difficulty difficulty)
    {
        _currentDifficulty = difficulty;
        _firstRoundTime = difficulty switch
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
        Score += (int)Math.Round(10 * TurnTimeLeft);
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
