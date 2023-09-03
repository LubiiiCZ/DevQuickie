namespace Project003;

public class RewardOption
{
    private readonly List<RewardItem> _rewards = new();
    private Vector2 _position;
    public Rectangle BoundingRectangle =>
        new((int)_position.X - Map.TILE_SIZE / 2, (int)_position.Y - Map.TILE_SIZE / 2, Map.TILE_SIZE, _rewards.Count * Map.TILE_SIZE);

    public RewardOption(Vector2 pos)
    {
        _position = pos;
    }

    public void AddRewardItem(RewardItem item)
    {
        _rewards.Add(item);
        item.Position = new(_position.X, _position.Y + (_rewards.Count - 1) * Map.TILE_SIZE);
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
