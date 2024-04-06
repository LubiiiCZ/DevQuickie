namespace LiveProject001;

public class ProcessSpellsState : GameState
{
    private readonly Dictionary<Spells, Action<Spell>> _spellActions;

    public ProcessSpellsState(GameManager gm) : base(gm)
    {
        _spellActions = new()
        {
            { Spells.Fireball, (s) => _gm.monsterManager.DoSplashDamage(s.Data.Damage, DamageTypes.Fire, TargetingTypes.All, _gm.CurrentSpell.Position, s.Data.Radius) },
            { Spells.Freeze, (s) => _gm.monsterManager.ApplyEffectArea(_gm.CurrentSpell.Position, s.Data.Radius, TargetingTypes.All, Effects.Freeze, 5) },
            { Spells.Ligthing, (s) => _gm.monsterManager.SelectNearestTarget(_gm.CurrentSpell.Position, TargetingTypes.All)?.TakeDamage(_gm.CurrentSpell.Data.Damage, DamageTypes.Electricity) },
        };
    }

    public override void Update()
    {
        _spellActions[_gm.CurrentSpell.SpellID](_gm.CurrentSpell);
        _gm.CurrentSpell.Charges--;
        _gm.CurrentSpell.Position = InputManager.StartPosition;
        StateManager.UpdateState(States.Play);
        StateManager.SwitchState(States.Play);
    }

    public override void Draw()
    {
        StateManager.DrawState(States.Play);
    }
}
