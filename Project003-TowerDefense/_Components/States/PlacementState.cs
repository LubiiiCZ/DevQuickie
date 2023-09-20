namespace Project003;

public class PlacementState : GameState
{
    private readonly Vector2 _rewardLabelPos;
    private readonly string _rewardLabel = "Place your reward:";
    private Texture2D _rewardTexture;
    private readonly Vector2 _rewardTexturePos;

    public PlacementState(GameManager gm) : base(gm)
    {
        _gm.map.OnTileSelection += HandleSelection;
        _rewardLabelPos = new(Map.TILE_SIZE / 2, Map.SIZE_Y * Map.TILE_SIZE);
        _rewardTexturePos = new((Map.SIZE_X - 1) * Map.TILE_SIZE, Map.SIZE_Y * Map.TILE_SIZE);
    }

    public override void Update()
    {
        _gm.map.Update();
        _rewardTexture = _gm.rewardManager.GetRewardTexture(_gm.CurrentReward); //TODO
    }

    public void HandleSelection(object sender, SelectionData data)
    {
        if (_gm.CurrentReward != Rewards.Mine)
        if (!_gm.monsterManager.CheckPlacementValidity(data.MapX, data.MapY)) return;

        TileObjects objectID = _gm.CurrentReward switch
        {
            Rewards.Tower => TileObjects.Tower,
            Rewards.TowerAir => TileObjects.TowerAir,
            Rewards.Wall => TileObjects.Wall,
            Rewards.Mine => TileObjects.Mine,
            _ => TileObjects.Wall,
        };

        _gm.map.PlaceObject(TileObjectFactory.CreateTileObject(objectID), data.MapX, data.MapY);

        StateManager.SwitchState(States.ProcessRewards);
    }

    public override void Draw()
    {
        _gm.map.Draw();
        _gm.uiManager.DrawCustomLabel(_rewardLabel, _rewardLabelPos);
        Globals.SpriteBatch.Draw(_rewardTexture, _rewardTexturePos, Color.White);
    }
}
