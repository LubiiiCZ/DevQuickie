namespace Quickie002;

public class Layer
{
    private readonly Texture2D _texture;
    private Vector2 _position;
    private Vector2 _position2;
    private readonly float _depth;
    private readonly float _moveScale;
    private readonly float _defaultSpeed;

    public Layer(Texture2D texture, float depth, float moveScale, float defaultSpeed = 0.0f)
    {
        _texture = texture;
        _depth = depth;
        _moveScale = moveScale;
        _defaultSpeed = defaultSpeed;
        _position = Vector2.Zero;
        _position2 = Vector2.Zero;
    }

    public void Update(float movement)
    {
        _position.X += ((movement * _moveScale) + _defaultSpeed) * Globals.ElapsedSeconds;
        _position.X %= _texture.Width;

        if (_position.X >= 0)
        {
            _position2.X = _position.X - _texture.Width;
        }
        else
        {
            _position2.X = _position.X + _texture.Width;
        }
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, _position, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, _depth);
        Globals.SpriteBatch.Draw(_texture, _position2, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, _depth);
    }
}
