namespace LiveProject001;

public class RewardOption
{
    public List<RewardItem> Rewards { get; } = new();
    public Vector2 Position;
    public Rectangle BoundingRectangle =>
        new((int)Position.X, (int)Position.Y, Map.TILE_SIZE, Rewards.Count * Map.TILE_SIZE);

    public RewardOption()
    {
    }

    public void SetPosition(Vector2 pos)
    {
        Position = pos;
        int counter = 0;

        foreach (var item in Rewards)
        {
            item.Position = new(Position.X + Map.TILE_SIZE / 2, Position.Y + counter * Map.TILE_SIZE + Map.TILE_SIZE / 2);
            counter++;
        }
    }

    public void AddRewardItem(RewardItem item)
    {
        Rewards.Add(item);
    }

    public static event RewardOptionHandler OnTap;

    public void Update()
    {
        if (InputManager.WasTapped(BoundingRectangle))
        {
            OnTap?.Invoke(Rewards);
        }
    }

    public void Draw()
    {
        Rewards.ForEach(r => r.Draw());
    }
}
