namespace Project001;

public class PlayState : GameState
{
    public override void Update(GameManager gm)
    {
        gm.Board.Update();
    }

    public override void Draw(GameManager gm)
    {
        gm.Board.Draw();
        ScoreManager.Draw();
    }
}
