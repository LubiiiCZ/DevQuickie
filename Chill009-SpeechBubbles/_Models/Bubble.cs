namespace Chill009_SpeechBubbles;

public class Bubble
{
    private readonly Texture2D _texture;
    private Rectangle[] _sourceRectangles;
    private Rectangle[] _destinationRectangles;
    private Vector2 _position;
    public int Width { get; private set; }
    public int Height { get; private set; }
    private readonly int _cornerSize;
    private readonly SpriteFont _font;
    private string _text = "";
    private Vector2 _textPosition;
    public Color TextColor { get; set; } = Color.White;

    public Bubble(Texture2D texture, int cornerSize, SpriteFont font)
    {
        _font = font;

        _cornerSize = cornerSize;
        _texture = texture;
        _sourceRectangles = new Rectangle[9];
        _destinationRectangles = new Rectangle[9];

        /*
        012
        345
        678
        */

        _sourceRectangles[0] = new(0, 0, cornerSize, cornerSize);
        _sourceRectangles[1] = new(cornerSize, 0, _texture.Width - 2 * cornerSize, cornerSize);
        _sourceRectangles[2] = new(_texture.Width - cornerSize, 0, cornerSize, cornerSize);
        _sourceRectangles[3] = new(0, cornerSize, cornerSize, _texture.Height - 2 * cornerSize);
        _sourceRectangles[4] = new(cornerSize, cornerSize, _texture.Width - 2 * cornerSize, _texture.Height - 2 * cornerSize);
        _sourceRectangles[5] = new(_texture.Width - cornerSize, cornerSize, cornerSize, _texture.Height - 2 * cornerSize);
        _sourceRectangles[6] = new(0, _texture.Height - cornerSize, cornerSize, cornerSize);
        _sourceRectangles[7] = new(cornerSize, _texture.Height - cornerSize, _texture.Width - 2 * cornerSize, cornerSize);
        _sourceRectangles[8] = new(_texture.Width - cornerSize, _texture.Height - cornerSize, cornerSize, cornerSize);
    }

    public void CalculateDestinationRectangles()
    {
        var textSize = _font.MeasureString(_text);
        Width = (int)textSize.X + 2 * _cornerSize;
        Height = (int)textSize.Y + 2 * _cornerSize;

        int x = (int)_position.X;
        int y = (int)_position.Y;
        int w = Width - 2 * _cornerSize;
        int h = Height - 2 * _cornerSize;

        _textPosition = new(x + _cornerSize, y + _cornerSize);

        _destinationRectangles[0] = new(x, y, _cornerSize, _cornerSize);
        _destinationRectangles[1] = new(x + _cornerSize, y, w, _cornerSize);
        _destinationRectangles[2] = new(x + Width - _cornerSize, y, _cornerSize, _cornerSize);
        _destinationRectangles[3] = new(x, y + _cornerSize, _cornerSize, h);
        _destinationRectangles[4] = new(x + _cornerSize, y + _cornerSize, w, h);
        _destinationRectangles[5] = new(x + Width - _cornerSize, y + _cornerSize, _cornerSize, h);
        _destinationRectangles[6] = new(x, y + Height - _cornerSize, _cornerSize, _cornerSize);
        _destinationRectangles[7] = new(x + _cornerSize, y + Height - _cornerSize, w, _cornerSize);
        _destinationRectangles[8] = new(x + Width - _cornerSize, y + Height - _cornerSize, _cornerSize, _cornerSize);
    }

    public void SetText(string text)
    {
        _text = text;
        CalculateDestinationRectangles();
    }

    public void SetPosition(Vector2 position)
    {
        _position = position;
        CalculateDestinationRectangles();
    }

    public void Draw()
    {
        for (int i = 0; i < _sourceRectangles.Length; i++)
        {
            Globals.SpriteBatch.Draw(_texture, _destinationRectangles[i], _sourceRectangles[i], Color.White);
        }

        Globals.SpriteBatch.DrawString(_font, _text, _textPosition, TextColor);
    }
}
