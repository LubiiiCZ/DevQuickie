namespace Project003;

public class SelectTargetState : GameState
{
    public SelectTargetState(GameManager gm) : base(gm)
    {
        _gm.map.OnSpellTileSelection += HandleSpellTileSelection;
    }

    public void HandleSpellTileSelection(object sender, SelectionData data)
    {
        _gm.CurrentSelectionData = data;
        StateManager.SwitchState(States.ProcessSpells);
    }

    public override void Update()
    {
        _gm.monsterManager.Update();
        _gm.AssignTargets();
        _gm.map.UpdateTowers();
        _gm.map.CheckSpellTileSelection();
        _gm.monsterManager.CheckWaveEnd();
    }

    public override void Draw()
    {
        _gm.map.Draw();
        _gm.monsterManager.Draw();
        _gm.monsterManager.DrawHPBars();
        _gm.map.DrawProjectiles();
        _gm.uiManager.DrawMonsterCounter(_gm.monsterManager.MonstersInWave.Count);
    }
}
