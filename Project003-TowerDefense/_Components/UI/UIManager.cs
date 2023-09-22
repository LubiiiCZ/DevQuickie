namespace Project003;

public class UIManager
{
    public readonly Button buttonStartWave;
    private readonly Texture2D _buttonTex;
    private readonly Texture2D _liveTex;
    private readonly SpriteFont _font;
    private readonly Vector2 _counterPos;

    public UIManager()
    {
        _font = Globals.Content.Load<SpriteFont>("font");
        _buttonTex = Globals.Content.Load<Texture2D>("button");
        _liveTex = Globals.Content.Load<Texture2D>("heart");
        buttonStartWave = new(_buttonTex, new Vector2(Map.TILE_SIZE / 2, (Map.SIZE_Y + 1) * Map.TILE_SIZE - Map.TILE_SIZE / 2));
        _counterPos = new(Map.SIZE_X / 2 * Map.TILE_SIZE, Map.SIZE_Y * Map.TILE_SIZE + 4);
    }

    public void Update()
    {
        buttonStartWave.Update();
    }

    public Vector2 MeasureString(string msg)
    {
        return _font.MeasureString(msg);
    }

    public void DrawMonsterCounter(int monstersLeft)
    {
        Globals.SpriteBatch.DrawString(_font, monstersLeft.ToString(), _counterPos, Color.Black);
    }

    public void DrawCustomLabel(string msg, Vector2 pos)
    {
        Globals.SpriteBatch.DrawString(_font, msg, pos, Color.Black);
    }

    public void DrawLiveCounter(int lives)
    {
        for (int i = 0; i < lives; i++)
        {
            Globals.SpriteBatch.Draw(_liveTex, new Vector2(32 * i, 0), Color.White);
        }
    }

    public void Draw()
    {
        buttonStartWave.Draw();
    }
}
