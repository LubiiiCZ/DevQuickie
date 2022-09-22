namespace Project001;

public class PlayState : GameState
{
    public override void Update(GameManager gm)
    {
    }

    public override void Draw(GameManager gm)
    {
        gm.Board.Draw();
        ScoreManager.Draw();
    }
}
