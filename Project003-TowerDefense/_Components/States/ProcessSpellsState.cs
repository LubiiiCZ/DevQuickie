namespace Project003;

public class ProcessSpellsState : GameState
{
    private readonly Dictionary<Spells, Action> _spellActions;

    public ProcessSpellsState(GameManager gm) : base(gm)
    {
        _spellActions = new()
        {
            { Spells.Fireball, () => _gm.monsterManager.DoSplashDamage(3, DamageTypes.Fire, _gm.CurrentSpell.Position, Map.TILE_SIZE * 2) },
        };
    }

    public override void Update()
    {
        _spellActions[_gm.CurrentSpell.SpellID]();
        _gm.CurrentSpell.Used = true;
        _gm.CurrentSpell.Position = InputManager.StartPosition;
        StateManager.UpdateState(States.Play);
        StateManager.SwitchState(States.Play);
    }

    public override void Draw()
    {
        StateManager.DrawState(States.Play);
    }
}
