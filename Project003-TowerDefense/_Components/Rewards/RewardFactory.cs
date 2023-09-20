namespace Project003;

public class RewardFactory
{
    public Dictionary<Rewards, Texture2D> RewardTextures = new();

    public RewardFactory()
    {
        RewardTextures.Add(Rewards.Tower, Globals.Content.Load<Texture2D>("tower"));
        RewardTextures.Add(Rewards.TowerAir, Globals.Content.Load<Texture2D>("tower_air"));
        RewardTextures.Add(Rewards.Wall, Globals.Content.Load<Texture2D>("wall"));
        RewardTextures.Add(Rewards.MonsterNinja, Globals.Content.Load<Texture2D>("hero"));
        RewardTextures.Add(Rewards.MonsterRedNinja, Globals.Content.Load<Texture2D>("hero_boss"));
        RewardTextures.Add(Rewards.MonsterFlyingNinja, Globals.Content.Load<Texture2D>("hero_fly"));
        RewardTextures.Add(Rewards.Fireball, Globals.Content.Load<Texture2D>("fireball"));
        RewardTextures.Add(Rewards.Mine, Globals.Content.Load<Texture2D>("mine"));
    }

    private RewardItem GetItem(Rewards rewardID)
    {
        return new(rewardID, RewardTextures[rewardID]);
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
