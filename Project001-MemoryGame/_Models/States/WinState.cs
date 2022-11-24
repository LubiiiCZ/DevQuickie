namespace Project001;

public class WinState : GameState
{
    private static Texture2D _texture;
    private static Vector2 _position;
    private static SpriteFont _font;
    private static Vector2 _textPosition;
    private static string _text = "";

    public WinState()
    {
        _texture = Globals.Content.Load<Texture2D>("win");
        _font = Globals.Content.Load<SpriteFont>("font");
        _position = new((Globals.Bounds.X - _texture.Width) / 2, (Globals.Bounds.Y - _texture.Height) / 2);
    }

    public override void Update(GameManager gm)
    {
        if (InputManager.MouseClicked)
        {
            gm.ChangeState(GameStates.Menu);
        }

        _text = Math.Round(ScoreManager.Score).ToString();
        var size = _font.MeasureString(_text);
        _textPosition = new((Globals.Bounds.X - size.X) / 2, _position.Y + (_texture.Height / 4));
    }

    public override void Draw(GameManager gm)
    {
        Globals.SpriteBatch.Draw(_texture, _position, Color.White);
        Globals.SpriteBatch.DrawString(_font, _text, _textPosition, Color.Black);
    }
}
