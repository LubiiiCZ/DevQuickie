namespace Challenge002;

public static class FontWriter
{
    private static SpriteFont _font;

    public static void Initialize()
    {
        _font = Globals.Content.Load<SpriteFont>("font");
    }

    public static void DrawText(string text, Vector2 position, Color color)
    {
        Globals.SpriteBatch.DrawString(_font, text, position, color);
    }
}
