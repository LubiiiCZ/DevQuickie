namespace Project003;

public class ProcessSpellsState : GameState
{
    private readonly Dictionary<Spells, Action<Spell>> _spellActions;

    public ProcessSpellsState(GameManager gm) : base(gm)
    {
        _spellActions = new()
        {
            { Spells.Fireball, (s) => _gm.monsterManager.DoSplashDamage(s.Data.Damage, DamageTypes.Fire, _gm.CurrentSpell.Position, s.Data.Range) },
            { Spells.Freeze, (s) => _gm.monsterManager.ApplyEffectArea(_gm.CurrentSpell.Position, s.Data.Range, Effects.Freeze, 5) },
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
