namespace Project003;

public class RewardOption
{
    private readonly List<RewardItem> _rewards = new();
    public Vector2 Position;
    public Rectangle BoundingRectangle =>
        new((int)Position.X, (int)Position.Y, Map.TILE_SIZE, _rewards.Count * Map.TILE_SIZE);

    public RewardOption()
    {
    }

    public void SetPosition(Vector2 pos)
    {
        Position = pos;
        int counter = 0;

        foreach (var item in _rewards)
        {
            item.Position = new(Position.X + Map.TILE_SIZE / 2, Position.Y + counter * Map.TILE_SIZE + Map.TILE_SIZE / 2);
            counter++;
        }
    }

    public void AddRewardItem(RewardItem item)
    {
        _rewards.Add(item);
    }

    public static event RewardOptionHandler OnTap;

    public void Update()
    {
        if (InputManager.WasTapped(BoundingRectangle))
        {
            OnTap?.Invoke(_rewards);
        }
    }

    public void Draw()
    {
        _rewards.ForEach(r => r.Draw());
    }
}
