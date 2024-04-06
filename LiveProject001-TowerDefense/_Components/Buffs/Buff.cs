namespace LiveProject001;

public class Buff
{
    private Monster _monster;
    public float Lifespan { get; set; }
    public float TickLength { get; set; }
    private float _tickCurrent;
    public Effects Effect { get; set; }
    public Action<Monster> OnApply;
    public Action<Monster> OnExpire;
    public Action<Monster> OnTick;

    public Buff(Monster monster, Effects effect, float lifespan, float tickLength,
                Action<Monster> apply = null, Action<Monster> expire = null, Action<Monster> tick = null)
    {
        _monster = monster;
        Lifespan = lifespan;
        TickLength = tickLength;
        _tickCurrent = TickLength;
        Effect = effect;
        OnApply = apply;
        OnExpire = expire;
        OnTick = tick;

        _monster.ApplyBuff(this);
        OnApply?.Invoke(_monster);
    }

    public void Update()
    {
        _tickCurrent -= Globals.Time;
        if (_tickCurrent <= 0)
        {
            OnTick?.Invoke(_monster);
            _tickCurrent += TickLength;
        }

        Lifespan -= Globals.Time;
        if (Lifespan <= 0)
        {
            _monster.RemoveBuff(this);
            OnExpire?.Invoke(_monster);
        }
    }
}
