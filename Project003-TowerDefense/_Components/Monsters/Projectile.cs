namespace Project003;

public class Projectile : Sprite
{
    private Monster _target;
    private float _speed = 500f;
    private int _damage;
    private float _radius = 1f;
    private DamageTypes _damageType;
    private AttackTypes _attackType;
    private TargetingTypes _targetingType;
    public bool Dead { get; private set; }
    public List<Effects> Effects { get; private set; } = new();

    public Projectile(Texture2D texture, Vector2 position, Monster target, int damage, float radius, DamageTypes damageType, AttackTypes attackType, TargetingTypes targetingType) : base(texture, position)
    {
        _target = target;
        _damage = damage;
        _radius = radius;
        _damageType = damageType;
        _attackType = attackType;
        _targetingType = targetingType;
    }

    public void AddEffect(Effects effect)
    {
        Effects.Add(effect);
    }

    public void SetEffects(List<Effects> effects)
    {
        Effects = effects;
    }

    private void HitTarget()
    {
        Dead = true;

        if (_attackType == AttackTypes.SingleTarget)
        {
            _target.TakeDamage(_damage, _damageType);
            foreach (var effect in Effects)
            {
                BuffFactory.CreateBuff(_target, effect);
            }
        }
        else if (_attackType == AttackTypes.Splash)
        {
            DamageHelper.MonsterManager.DoSplashDamage(_damage, _damageType, _targetingType, _target.Position, _radius);
            foreach (var effect in Effects)
            {
                DamageHelper.MonsterManager.ApplyEffectArea(_target.Position, _radius, _targetingType, effect);
            }
        }
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
            HitTarget();
            return;
        }

        if (direction != Vector2.Zero) direction.Normalize();
        Position += direction * _speed * Globals.Time;
    }
}
