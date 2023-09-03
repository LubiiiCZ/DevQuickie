namespace Project003;

public delegate void RewardOptionHandler(List<RewardItem> rewards);

public class RewardManager
{
    private readonly RewardFactory _rewardFactory;
    private readonly List<RewardOption> _rewardOptions = new();

    public RewardManager()
    {
        _rewardFactory = new();
        AddRewardOption(_rewardFactory.GetRewardOption(new() { Rewards.Tower }, new(300, 500)));
        AddRewardOption(_rewardFactory.GetRewardOption(new() { Rewards.Wall }, new(400, 500)));

        RewardOption.OnTap += RewardSelected;
    }

    public event RewardOptionHandler OnRewardSelection;

    public void RewardSelected(List<RewardItem> rewards)
    {
        OnRewardSelection?.Invoke(rewards);
    }

    public void AddRewardOption(RewardOption rewardOption)
    {
        _rewardOptions.Add(rewardOption);
    }

    public void ClearRewardOptions()
    {
        _rewardOptions.Clear();
    }

    public void Update()
    {
        _rewardOptions.ForEach(r => r.Update());
    }

    public void Draw()
    {
        _rewardOptions.ForEach(r => r.Draw());
    }
}
