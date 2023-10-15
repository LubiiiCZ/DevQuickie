namespace Project003;

public class Projectile : Sprite
{
    private Monster _target;
    private float _speed = 500f;
    private int _damage;
    private DamageTypes _damageType;
    public bool Dead { get; private set; }
    public List<Effects> Effects { get; private set; } = new();

    public Projectile(Texture2D texture, Vector2 position, Monster target, int damage, DamageTypes damageType) : base(texture, position)
    {
        _target = target;
        _damage = damage;
        _damageType = damageType;
    }

    public void AddEffect(Effects effect)
    {
        Effects.Add(effect);
    }

    public void SetEffects(List<Effects> effects)
    {
        Effects = effects;
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
            _target.TakeDamage(_damage, _damageType);
            foreach (var effect in Effects)
            {
                BuffFactory.CreateBuff(_target, effect);
            }
            return;
        }

        if (direction != Vector2.Zero) direction.Normalize();
        Position += direction * _speed * Globals.Time;
    }
}
