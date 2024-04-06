namespace Challenge004;

public class Explosion(Texture2D texture, Vector2 position)
{
    public Vector2 Position = position;
    private readonly Texture2D _texture = texture;
    private Rectangle _sourceRectangle;
    private float _frameTime = FRAME_TIME;
    private const float FRAME_TIME = 0.05f;
    public int _currentFrame; // 0 .. 7
    private readonly Point _frameSize = new(texture.Width / 8, texture.Height);

    private void UpdateAnimation()
    {
        _frameTime -= Globals.Time;
        if (_frameTime < 0)
        {
            _frameTime += FRAME_TIME;
            _currentFrame++;
        }
    }

    private void UpdateRectangle()
    {
        Point location = new(_currentFrame * _frameSize.X, 0);
        _sourceRectangle = new(location, _frameSize);
    }

    public void Update()
    {
        UpdateAnimation();
        UpdateRectangle();
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, Position, _sourceRectangle, Color.White);
    }
}
