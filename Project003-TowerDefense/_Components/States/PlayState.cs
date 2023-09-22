namespace Project003;

public class PlayState : GameState
{
    public PlayState(GameManager gm) : base(gm)
    {
        _gm.monsterManager.OnWaveEnd += HandleWaveEnd;
        _gm.spellManager.OnCast += HandleSpellCast;
    }

    public void HandleWaveEnd(object sender, EventArgs args)
    {
        StateManager.SwitchState(States.Reward);
        _gm.map.Towers.ForEach(t => t.Reset());
        _gm.map.ResetMines();
    }

    public void HandleSpellCast(object sender, Spells id)
    {
        if (!Active) return;
        _gm.CurrentSpell = id;
        StateManager.SwitchState(States.SelectTarget); //switch by spell id here
    }

    public override void Update()
    {
        _gm.monsterManager.Update();
        _gm.monsterManager.UpdateMineCollisions(_gm.map.Mines);
        _gm.AssignTargets();
        _gm.map.UpdateTowers();
        _gm.monsterManager.CheckWaveEnd();

        if (Active)
        {
            _gm.map.UpdateTowerSelection();
            _gm.spellManager.UpdateSpells();
        }

        if (_gm.PlayerLives < 1)
        {
            _gm.ResetGame();
        }
    }

    public override void Draw()
    {
        _gm.map.Draw();
        _gm.monsterManager.Draw();
        _gm.monsterManager.DrawHPBars();
        _gm.map.DrawProjectiles();
        _gm.spellManager.DrawSpells();
        _gm.uiManager.DrawMonsterCounter(_gm.monsterManager.MonstersInWave.Count);
        _gm.uiManager.DrawLiveCounter(_gm.PlayerLives);
    }
}
