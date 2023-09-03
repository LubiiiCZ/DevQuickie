namespace Project003;

public class RewardFactory
{
    private Dictionary<Rewards, Texture2D> _rewardTextures = new();

    public RewardFactory()
    {
        _rewardTextures.Add(Rewards.Tower, Globals.Content.Load<Texture2D>("tower"));
        _rewardTextures.Add(Rewards.Wall, Globals.Content.Load<Texture2D>("wall"));
    }

    public RewardItem GetItem(Rewards rewardID)
    {
        return new(rewardID, _rewardTextures[rewardID]);
    }

    public RewardOption GetRewardOption(List<Rewards> rewards, Vector2 pos)
    {
        RewardOption result = new(pos);

        foreach (var reward in rewards)
        {
            RewardItem item = new(reward, _rewardTextures[reward]);
            result.AddRewardItem(item);
        }

        return result;
    }
}
