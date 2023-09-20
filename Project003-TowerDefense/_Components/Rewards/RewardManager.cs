using System.Linq;

namespace Project003;

public delegate void RewardOptionHandler(List<RewardItem> rewards);

public class RewardManager
{
    private readonly RewardFactory _rewardFactory;
    private readonly List<RewardOption> _rewardOptions = new();
    private Rectangle _frame = new();
    private readonly Texture2D _frameTexture;

    public RewardManager(GraphicsDevice graphicsDevice)
    {
        _rewardFactory = new();
        AddRewardOption(_rewardFactory.GetRewardOption(new() { Rewards.Tower, Rewards.MonsterNinja }));
        AddRewardOption(_rewardFactory.GetRewardOption(new() { Rewards.Wall, Rewards.Wall, Rewards.Fireball, Rewards.MonsterFlyingNinja }));
        AddRewardOption(_rewardFactory.GetRewardOption(new() { Rewards.TowerAir, Rewards.Wall, Rewards.MonsterRedNinja }));
        AddRewardOption(_rewardFactory.GetRewardOption(new() { Rewards.Mine, Rewards.Wall, Rewards.MonsterRedNinja }));

        RewardOption.OnTap += RewardSelected;

        _frameTexture = new(graphicsDevice, 1, 1);
        _frameTexture.SetData(new Color[] { Color.Sienna });
    }

    public Texture2D GetRewardTexture(Rewards type)
    {
        return _rewardFactory.RewardTextures[type];
    }

    public event RewardOptionHandler OnRewardSelection;

    public void RewardSelected(List<RewardItem> rewards)
    {
        OnRewardSelection?.Invoke(rewards);
    }

    private void CalculatePositions()
    {
        const int gap = Map.TILE_SIZE / 2;
        const int topPadding = Map.TILE_SIZE * 3;
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

        _frame.Location = new((int)_rewardOptions[0].Position.X - gap, (int)_rewardOptions[0].Position.Y - gap);
        _frame.Width = optionsWidth + 2 * gap;
        _frame.Height = _rewardOptions.Max(r => r.Rewards.Count) * Map.TILE_SIZE + 2 * gap;
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
        Globals.SpriteBatch.Draw(_frameTexture, _frame, Color.White);
        _rewardOptions.ForEach(r => r.Draw());
    }
}
