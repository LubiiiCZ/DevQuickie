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
        if (!_gm.WaveInProgress) return;

        _gm.WaveInProgress = false;
        StateManager.SwitchState(States.Reward);
        _gm.RewardsLeft = 1;
        _gm.map.Towers.ForEach(t => t.Reset());
        _gm.map.ResetMines();
        _gm.spellManager.ResetSpells();
        _gm.rewardManager.GenerateRandomRewardOptions(4);
        if (InputManager.IsDragging)
        {
            (InputManager.DraggedItem as Sprite).Position = InputManager.StartPosition;
            InputManager.IsDragging = false;
        }
        _gm.WaveNumber++;
    }

    public void HandleSpellCast(object sender, Spell spell)
    {
        if (!Active) return;
        _gm.CurrentSpell = spell;
        StateManager.SwitchState(States.ProcessSpells); //switch by spell id here
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
        if (InputManager.IsDragging)
        {
            _gm.map.DrawRange((InputManager.DraggedItem as Spell).Position, (InputManager.DraggedItem as Spell).Data.Radius);
        }
    }
}
