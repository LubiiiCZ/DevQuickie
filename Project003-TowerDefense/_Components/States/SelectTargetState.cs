namespace Project003;

public class SelectTargetState : GameState
{
    public SelectTargetState(GameManager gm) : base(gm)
    {
        _gm.map.OnTileSelection += HandleSpellTileSelection;
    }

    public void HandleSpellTileSelection(object sender, Tile tile)
    {
        if (!Active) return;
        _gm.CurrentTile = tile;
        StateManager.SwitchState(States.ProcessSpells);
    }

    public override void Update()
    {
        _gm.map.UpdateTileSelection();
        StateManager.UpdateState(States.Play);
    }

    public override void Draw()
    {
        StateManager.DrawState(States.Play);
    }
}
