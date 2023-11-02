namespace Project003;

public class RewardFactory
{
    public Dictionary<Rewards, Texture2D> RewardTextures = new();
    public Dictionary<Rewards, int> PositiveRewardValues = new();
    public Dictionary<Rewards, int> NegativeRewardValues = new();

    public RewardFactory()
    {
        //TEXTURES
        RewardTextures.Add(Rewards.Tower, Globals.Content.Load<Texture2D>("tower"));
        RewardTextures.Add(Rewards.TowerAir, Globals.Content.Load<Texture2D>("tower_air"));
        RewardTextures.Add(Rewards.TowerIce, Globals.Content.Load<Texture2D>("tower_ice"));
        RewardTextures.Add(Rewards.Wall, Globals.Content.Load<Texture2D>("wall"));
        RewardTextures.Add(Rewards.Fireball, Globals.Content.Load<Texture2D>("fireball"));
        RewardTextures.Add(Rewards.Freeze, Globals.Content.Load<Texture2D>("freeze"));
        RewardTextures.Add(Rewards.Mine, Globals.Content.Load<Texture2D>("mine"));
        RewardTextures.Add(Rewards.MonsterNinja, Globals.Content.Load<Texture2D>("hero"));
        RewardTextures.Add(Rewards.MonsterRedNinja, Globals.Content.Load<Texture2D>("hero_boss"));
        RewardTextures.Add(Rewards.MonsterFlyingNinja, Globals.Content.Load<Texture2D>("hero_fly"));

        //POSITIVE REWARDS
        PositiveRewardValues.Add(Rewards.Tower, 1);
        PositiveRewardValues.Add(Rewards.TowerAir, 2);
        PositiveRewardValues.Add(Rewards.TowerIce, 2);
        PositiveRewardValues.Add(Rewards.Wall, 1);
        PositiveRewardValues.Add(Rewards.Fireball, 2);
        PositiveRewardValues.Add(Rewards.Freeze, 2);
        PositiveRewardValues.Add(Rewards.Mine, 2);

        //NEGATIVE REWARDS
        NegativeRewardValues.Add(Rewards.MonsterNinja, 1);
        NegativeRewardValues.Add(Rewards.MonsterRedNinja, 2);
        NegativeRewardValues.Add(Rewards.MonsterFlyingNinja, 2);
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

    public List<Rewards> GetRandomRewardsList(int points)
    {
        Random r = new();
        List<Rewards> result = new();
        var PositivePoints = points;
        var NegativePoints = points;

        while (PositivePoints > 0)
        {
            var available = PositiveRewardValues.Where(r => r.Value <= PositivePoints).ToDictionary(p => p.Key, p => p.Value);
            var item = available.ElementAt(r.Next(0, available.Count));
            PositivePoints -= item.Value;
            result.Add(item.Key);
        }

        while (NegativePoints > 0)
        {
            var available = NegativeRewardValues.Where(r => r.Value <= NegativePoints).ToDictionary(p => p.Key, p => p.Value);
            var item = available.ElementAt(r.Next(0, available.Count));
            NegativePoints -= item.Value;
            result.Add(item.Key);
        }

        return result;
    }
}
