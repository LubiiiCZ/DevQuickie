namespace Project003;

public class RewardFactory
{
    private Dictionary<Rewards, Texture2D> _rewardTextures = new();

    public RewardFactory()
    {
        _rewardTextures.Add(Rewards.Tower, Globals.Content.Load<Texture2D>("tower"));
        _rewardTextures.Add(Rewards.Wall, Globals.Content.Load<Texture2D>("wall"));
        _rewardTextures.Add(Rewards.MonsterNinja, Globals.Content.Load<Texture2D>("hero"));
        _rewardTextures.Add(Rewards.MonsterRedNinja, Globals.Content.Load<Texture2D>("hero_boss"));
    }

    private RewardItem GetItem(Rewards rewardID)
    {
        return new(rewardID, _rewardTextures[rewardID]);
    }

    public RewardOption GetRewardOption(List<Rewards> rewards)
    {
        RewardOption result = new();

        foreach (var reward in rewards)
        {
            RewardItem item = GetItem(reward);
            result.AddRewardItem(item);
        }

        return result;
    }
}
