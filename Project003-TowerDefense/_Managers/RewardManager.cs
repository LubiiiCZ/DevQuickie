namespace Project003;

public delegate void RewardOptionHandler(List<RewardItem> rewards);

public class RewardManager
{
    private readonly RewardFactory _rewardFactory;
    private readonly List<RewardOption> _rewardOptions = new();

    public RewardManager()
    {
        _rewardFactory = new();
        AddRewardOption(_rewardFactory.GetRewardOption(new() { Rewards.Tower }));
        AddRewardOption(_rewardFactory.GetRewardOption(new() { Rewards.Wall, Rewards.Wall, Rewards.Wall }));

        RewardOption.OnTap += RewardSelected;
    }

    public event RewardOptionHandler OnRewardSelection;

    public void RewardSelected(List<RewardItem> rewards)
    {
        OnRewardSelection?.Invoke(rewards);
    }

    private void CalculatePositions()
    {
        const int gap = 50;
        const int topPadding = 320;
        int count = _rewardOptions.Count;
        var optionsWidth = count * Map.TILE_SIZE + (count - 1) * gap;
        var width = Map.SIZE_X * Map.TILE_SIZE;
        var paddingLeft = (width - optionsWidth) / 2;
        int counter = 0;

        foreach (var rewardOption in _rewardOptions)
        {
            rewardOption.SetPosition(new(paddingLeft + counter * (Map.TILE_SIZE + gap), topPadding));
            counter++;
        }
    }

    public void AddRewardOption(RewardOption rewardOption)
    {
        _rewardOptions.Add(rewardOption);
        CalculatePositions();
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
