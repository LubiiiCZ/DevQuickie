namespace Challenge006;

public class PlayState(GameManager gm) : State(gm)
{
    public override void Update()
    {
        GM.Board.Update();
    }

    public override void Draw()
    {
        GM.Board.Draw();
    }
}
