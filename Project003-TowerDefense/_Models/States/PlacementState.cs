namespace Project003;

public class PlacementState : GameState
{
    public PlacementState(GameManager gm) : base(gm)
    {
        _gm.map.OnTileSelection += HandleSelection;
    }

    public override void Update()
    {
        _gm.map.Update();
    }

    public void HandleSelection(object sender, SelectionData data)
    {
        Tiles tile = _gm.CurrentReward switch
        {
            Rewards.Tower => Tiles.Tower,
            Rewards.Wall => Tiles.Wall,
            _ => Tiles.Grass,
        };

        _gm.map.ChangeTile(tile, data.MapX, data.MapY);
        _gm.RewardCount--;

        if (_gm.RewardCount <= 0)
        {
            StateManager.SwitchState(States.IdleState);
        }
    }

    public override void Draw()
    {
        _gm.map.Draw();
        //_gm.rewardsManager.Draw();
        //_gm.uiManager.DrawMonsterCounter(_gm.monsterManager.Monsters.Count);
    }
}
