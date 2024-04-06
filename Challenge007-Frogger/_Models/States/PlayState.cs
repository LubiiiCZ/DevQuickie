namespace Challenge007;

public class PlayState(GameManager gm) : State(gm)
{
    public override void Update()
    {
        GM.Froggy.Update();
        GM.Things.Update();
        if (GM.Things.CheckCarCollision(GM.Froggy)) GM.Reset();
        GM.Froggy.OnLog = GM.Things.CheckLogCollision(GM.Froggy);
        if (GM.Background.InRiver(GM.Froggy) && !GM.Froggy.OnLog && !GM.Froggy.Moving) GM.Reset();

        if (GM.Background.InFinish(GM.Froggy)) StateManager.SwitchState(States.End);
    }

    public override void Draw()
    {
        GM.Background.Draw();
        GM.Things.Draw();
        GM.Froggy.Draw();
    }
}
