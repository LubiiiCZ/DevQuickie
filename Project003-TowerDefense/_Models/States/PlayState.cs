namespace Project003;

public class PlayState : GameState
{
    public PlayState(GameManager gm) : base(gm)
    {
    }

    public override void Update()
    {
        _gm.monsterManager.Update();
        _gm.AssignTargets();
        _gm.map.Update();
    }

    public override void Draw()
    {
        _gm.map.Draw();
        _gm.monsterManager.Draw();
        _gm.map.DrawProjectiles();
    }
}
