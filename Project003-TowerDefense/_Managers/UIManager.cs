namespace Project003;

public class UIManager
{
    public readonly Button buttonStartWave;
    private readonly Texture2D _buttonTex;
    private readonly SpriteFont _font;
    private readonly Vector2 _counterPos;

    public UIManager()
    {
        _font = Globals.Content.Load<SpriteFont>("font");
        _buttonTex = Globals.Content.Load<Texture2D>("button");
        buttonStartWave = new(_buttonTex, new Vector2(Map.TILE_SIZE / 2, (Map.SIZE_Y + 1) * Map.TILE_SIZE - Map.TILE_SIZE / 2));
        _counterPos = new(Map.SIZE_X / 2 * Map.TILE_SIZE, Map.SIZE_Y * Map.TILE_SIZE + 4);
    }

    public void Update()
    {
        buttonStartWave.Update();
    }

    public void DrawMonsterCounter(int monstersLeft)
    {
        Globals.SpriteBatch.DrawString(_font, monstersLeft.ToString(), _counterPos, Color.Black);
    }

    public void Draw()
    {
        buttonStartWave.Draw();
    }
}
