namespace Project003;

public class RewardState : GameState
{
    public RewardState(GameManager gm) : base(gm)
    {
        _gm.rewardsManager.buttonReward1.OnTap += SelectReward;
    }

    public void SelectReward(object sender, EventArgs e)
    {
        _gm.monstersInWave++;
        StateManager.SwitchState(States.PlacementState);
    }

    public override void Update()
    {
        _gm.rewardsManager.Update();
    }

    public override void Draw()
    {
        _gm.map.Draw();
        _gm.rewardsManager.Draw();
        //_gm.uiManager.DrawMonsterCounter(_gm.monsterManager.Monsters.Count);
    }
}
