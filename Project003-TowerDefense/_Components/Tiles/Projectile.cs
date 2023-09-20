namespace Project003;

public class Projectile : Sprite
{
    private Monster _target;
    private float _speed = 500f;
    private int _damage;
    public bool Dead { get; private set; }

    public Projectile(Texture2D texture, Vector2 position, Monster target, int damage) : base(texture, position)
    {
        _target = target;
        _damage = damage;
    }

    public virtual void Update()
    {
        if (_target.Dead)
        {
            Dead = true;
            return;
        }

        Vector2 direction = _target.Position - Position;
        if (direction.Length() < 5)
        {
            Dead = true;
            _target.TakeDamage(_damage);
            return;
        }

        if (direction != Vector2.Zero) direction.Normalize();
        Position += direction * _speed * Globals.Time;
    }
}
