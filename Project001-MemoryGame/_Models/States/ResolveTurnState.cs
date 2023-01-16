namespace Project001;

public class ResolveTurnState : PlayState
{
    public override void Update(GameManager gm)
    {
        base.Update(gm);

        if (gm.FirstCard.Id == gm.SecondCard.Id && !gm.FirstCard.Flipping && !gm.SecondCard.Flipping)
        {
            gm.Board.Collect(gm.FirstCard, gm.SecondCard);
            ScoreManager.NextTurn();

            if (gm.Board.CardsLeft <= 0)
            {
                gm.ChangeState(GameStates.Win);
                ScoreManager.Stop();
                ScoreManager.SaveScores();
                SoundManager.PlayVictoryFX();
            }
            else
            {
                gm.ChangeState(GameStates.FlipFirstCard);
            }
        }

        if (InputManager.MouseClicked && gm.FirstCard.Id != gm.SecondCard.Id)
        {
            gm.FirstCard.Flip();
            gm.SecondCard.Flip();
            ScoreManager.Miss();
            gm.ChangeState(GameStates.FlipFirstCard);
        }
    }
}
