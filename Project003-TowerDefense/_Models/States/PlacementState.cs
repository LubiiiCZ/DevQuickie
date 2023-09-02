namespace Project003;

public class PlacementState : GameState
{
    public PlacementState(GameManager gm) : base(gm)
    {
    }

    public override void Update()
    {
        _gm.map.Update();
    }

    public override void Draw()
    {
        _gm.map.Draw();
        //_gm.rewardsManager.Draw();
        //_gm.uiManager.DrawMonsterCounter(_gm.monsterManager.Monsters.Count);
    }
}
