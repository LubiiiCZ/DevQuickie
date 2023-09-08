namespace Project003;

public class IdleState : GameState
{
    public IdleState(GameManager gm) : base(gm)
    {
    }

    public override void Update()
    {
        _gm.uiManager.Update();
    }

    public override void Draw()
    {
        _gm.map.Draw();
        _gm.uiManager.Draw();
        _gm.uiManager.DrawMonsterCounter(_gm.monstersInWave.Count);
    }
}
