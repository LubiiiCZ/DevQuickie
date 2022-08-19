namespace Quickie010;

public class Timer
{
    private readonly Texture2D _texture;
    private readonly Vector2 _position;
    private readonly SpriteFont _font;
    private readonly Vector2 _textPosition;
    private string _text;
    private readonly float _timeLength;
    private float _timeLeft;
    private bool _active;
    public bool Repeat { get; set; }

    public Timer(Texture2D texture, SpriteFont font, Vector2 position, float length)
    {
        _texture = texture;
        _font = font;
        _position = position;
        _textPosition = new(position.X + 32, position.Y + 2);
        _timeLength = length;
        _timeLeft = length;
    }

    private void FormatText()
    {
        _text = TimeSpan.FromSeconds(_timeLeft).ToString(@"mm\:ss\.ff");
    }

    public void StartStop()
    {
        _active = !_active;
    }

    public void Reset()
    {
        _timeLeft = _timeLength;
        FormatText();
    }

    public event EventHandler OnTimer;

    public void Update()
    {
        if (!_active) return;
        _timeLeft -= Globals.Time;

        if (_timeLeft <= 0)
        {
            OnTimer?.Invoke(this, EventArgs.Empty);

            if (Repeat)
            {
                Reset();
            }
            else
            {
                StartStop();
                _timeLeft = 0f;
            }
        }

        FormatText();
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, _position, Color.White);
        Globals.SpriteBatch.DrawString(_font, _text, _textPosition, Color.Black);
    }
}
