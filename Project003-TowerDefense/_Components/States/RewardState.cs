namespace Project003;

public class RewardState : GameState
{
    private readonly Vector2 _rewardLabelPos;
    private readonly string _rewardLabel = "Pick your reward!";

    public RewardState(GameManager gm) : base(gm)
    {
        _gm.rewardManager.OnRewardSelection += SelectReward;
        _rewardLabelPos = new(((Map.SIZE_X * Map.TILE_SIZE) - _gm.uiManager.MeasureString(_rewardLabel).X) / 2, 64);
    }

    public void SelectReward(List<RewardItem> rewards)
    {
        foreach (var item in rewards)
        {
            _gm.Rewards.Enqueue(item);
        }

        StateManager.SwitchState(States.ProcessRewards);
    }

    public override void Update()
    {
        _gm.rewardManager.Update();
    }

    public override void Draw()
    {
        _gm.map.Draw();
        _gm.rewardManager.Draw();
        _gm.uiManager.DrawMonsterCounter(_gm.monstersInWave.Count);
        _gm.uiManager.DrawLiveCounter(_gm.PlayerLives);
        _gm.uiManager.DrawCustomLabel(_rewardLabel, _rewardLabelPos);
    }
}
