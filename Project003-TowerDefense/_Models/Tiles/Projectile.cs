namespace Project003;

public class Projectile : Sprite
{
    private Monster _target;
    private float _speed = 200f;
    private int _damage = 1;
    public bool Dead { get; private set; }

    public Projectile(Texture2D texture, Vector2 position, Monster target) : base(texture, position)
    {
        _target = target;
    }

    public virtual void Update()
    {
        Vector2 direction = _target.Position - Position;
        if (direction.Length() < 5)
        {
            Dead = true;
            _target.Die();
            return;
        }

        if (direction != Vector2.Zero) direction.Normalize();
        Position += direction * _speed * Globals.Time;
    }
}
