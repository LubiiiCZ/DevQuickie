namespace Challenge006;

public class EndState(GameManager gm) : State(gm)
{
    public override void Update()
    {
        if (InputManager.Clicked) GM.Reset();
    }

    public override void Draw()
    {
        GM.Board.Draw();
    }
}
