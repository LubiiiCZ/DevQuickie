namespace Project003;

public class RewardState : GameState
{
    public RewardState(GameManager gm) : base(gm)
    {
        _gm.rewardManager.OnRewardSelection += SelectReward;
    }

    public void SelectReward(List<RewardItem> rewards)
    {
        _gm.monstersInWave++;

        foreach (var item in rewards)
        {
            _gm.CurrentReward = item.RewardID;
            _gm.RewardCount = (item.RewardID == Rewards.Wall) ? 3 : 1;
        }

        StateManager.SwitchState(States.PlacementState);
    }

    public override void Update()
    {
        _gm.rewardManager.Update();
    }

    public override void Draw()
    {
        _gm.map.Draw();
        _gm.rewardManager.Draw();
        //_gm.uiManager.DrawMonsterCounter(_gm.monsterManager.Monsters.Count);
    }
}
