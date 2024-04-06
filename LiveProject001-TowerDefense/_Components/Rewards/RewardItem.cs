namespace LiveProject001;

public class RewardItem : Sprite
{
    public Rewards RewardID { get; }

    public RewardItem(Rewards reward, Texture2D texture) : base(texture, Vector2.Zero)
    {
        RewardID = reward;
    }
}
