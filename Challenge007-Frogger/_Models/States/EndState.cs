namespace Challenge007;

public class EndState(GameManager gm) : State(gm)
{
    public override void Update()
    {
        if (InputManager.SpacePressed) GM.Reset();
    }

    public override void Draw()
    {
        GM.Background.Draw();
        GM.Things.Draw();
        GM.Froggy.Draw();
    }
}
