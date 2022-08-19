namespace Quickie003;

public class Particle
{
    private readonly ParticleData _data;
    private Vector2 _position;
    private float _lifespanLeft;
    private float _lifespanAmount;
    private Color _color;
    private float _opacity;
    public bool isFinished = false;
    private float _scale;
    private Vector2 _origin;
    private Vector2 _direction;

    public Particle(Vector2 pos, ParticleData data)
    {
        _data = data;
        _lifespanLeft = data.lifespan;
        _lifespanAmount = 1f;
        _position = pos;
        _color = data.colorStart;
        _opacity = data.opacityStart;
        _origin = new(_data.texture.Width / 2, _data.texture.Height / 2);

        if (data.speed != 0)
        {
            _data.angle = MathHelper.ToRadians(_data.angle);
            _direction = new Vector2((float)Math.Sin(_data.angle), -(float)Math.Cos(_data.angle));
        }
        else
        {
            _direction = Vector2.Zero;
        }
    }

    public void Update()
    {
        _lifespanLeft -= Globals.TotalSeconds;
        if (_lifespanLeft <= 0f)
        {
            isFinished = true;
            return;
        }

        _lifespanAmount = MathHelper.Clamp(_lifespanLeft / _data.lifespan, 0, 1);
        _color = Color.Lerp(_data.colorEnd, _data.colorStart, _lifespanAmount);
        _opacity = MathHelper.Clamp(MathHelper.Lerp(_data.opacityEnd, _data.opacityStart, _lifespanAmount), 0, 1);
        _scale = MathHelper.Lerp(_data.sizeEnd, _data.sizeStart, _lifespanAmount) / _data.texture.Width;
        _position += _direction * _data.speed * Globals.TotalSeconds;
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_data.texture, _position, null, _color * _opacity, 0f, _origin, _scale, SpriteEffects.None, 1f);
    }
}
