namespace Project003;

public class PlayState : GameState
{
    public PlayState(GameManager gm) : base(gm)
    {
        _gm.monsterManager.OnWaveEnd += HandleWaveEnd;
    }

    public void HandleWaveEnd(object sender, EventArgs args)
    {
        StateManager.SwitchState(States.Reward);
        _gm.map.Towers.ForEach(t => t.Reset());
    }

    public override void Update()
    {
        _gm.monsterManager.Update();
        _gm.AssignTargets();
        _gm.map.UpdateTowers();
        _gm.map.UpdateTowersSelection();
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
