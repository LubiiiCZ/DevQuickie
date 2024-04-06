namespace LiveProject001;

public class RewardState : GameState
{
    private readonly Vector2 _rewardLabelPos;
    private readonly Vector2 _rewardRerollPos;
    private readonly string _rewardLabel = "Pick your reward!";
    public Button RerollButton;

    public RewardState(GameManager gm) : base(gm)
    {
        _gm.rewardManager.OnRewardSelection += SelectReward;
        _rewardLabelPos = new(((Map.SIZE_X * Map.TILE_SIZE) - _gm.uiManager.MeasureString(_rewardLabel).X) / 2, 64);
        _rewardRerollPos = new(10, Map.SIZE_Y * Map.TILE_SIZE + 10);
        RerollButton = new(Globals.Content.Load<Texture2D>("reroll"), new Vector2(Map.TILE_SIZE / 2, (Map.SIZE_Y + 1) * Map.TILE_SIZE - Map.TILE_SIZE / 2));
        RerollButton.OnTap += HandleReroll;
    }

    public void HandleReroll(object sender, EventArgs args)
    {
        if (_gm.RewardRerolls > 0)
        {
            _gm.RewardRerolls--;
            _gm.rewardManager.GenerateRandomRewardOptions(4);
        }
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
        RerollButton.Update();
    }

    public override void Draw()
    {
        _gm.map.Draw();
        _gm.rewardManager.Draw();
        _gm.uiManager.DrawMonsterCounter(_gm.monstersInWave.Count);
        _gm.uiManager.DrawLiveCounter(_gm.PlayerLives);
        _gm.uiManager.DrawCustomLabel(_rewardLabel, _rewardLabelPos);
        RerollButton.Draw();
        _gm.uiManager.DrawCustomLabel(_gm.RewardRerolls.ToString(), _rewardRerollPos);
    }
}
