namespace Project003;

public class ProcessSpellState : GameState
{
    private readonly Dictionary<Spells, Action> _spellActions;

    public ProcessSpellState(GameManager gm) : base(gm)
    {
        _spellActions = new()
        {
            { Spells.Fireball, () => _gm.monsterManager.DoSplashDamage(3, Map.MapToScreen(_gm.CurrentTile.MapX, _gm.CurrentTile.MapY), Map.TILE_SIZE * 2) },
        };
    }

    public override void Update()
    {
        _spellActions[_gm.CurrentSpell]();
        StateManager.UpdateState(States.Play);
        StateManager.SwitchState(States.Play);
    }

    public override void Draw()
    {
        StateManager.DrawState(States.Play);
    }
}
