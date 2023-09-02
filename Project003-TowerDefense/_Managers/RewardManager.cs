namespace Project003;

public class RewardManager
{
    public readonly Button buttonReward1;
    private readonly Texture2D _buttonTex;

    public RewardManager()
    {
        _buttonTex = Globals.Content.Load<Texture2D>("tower");
        buttonReward1 = new(_buttonTex, new Vector2(Map.SIZE_X * Map.TILE_SIZE / 2, Map.SIZE_Y * Map.TILE_SIZE / 2));
    }

    public void Update()
    {
        buttonReward1.Update();
    }

    public void Draw()
    {
        buttonReward1.Draw();
    }
}
