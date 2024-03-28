namespace Project001;

public class Label(SpriteFont font, Vector2 position)
{
    private readonly SpriteFont _font = font;
    private Vector2 _centerPos = position;
    private Vector2 _pos;
    public string Text { get; private set; }

    public void SetText(string text)
    {
        Text = text;
        _pos = new(_centerPos.X - (_font.MeasureString(Text).X / 2) + 3, _centerPos.Y);
    }

    public void Draw()
    {
        Globals.SpriteBatch.DrawString(_font, Text, _pos, Color.Black);
    }
}
