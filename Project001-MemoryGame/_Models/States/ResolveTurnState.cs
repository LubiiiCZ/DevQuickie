namespace Project001;

public class ResolveTurnState : PlayState
{
    public override void Update(GameManager gm)
    {
        if (InputManager.MouseClicked)
        {
            if (gm.FirstCard.Id == gm.SecondCard.Id)
            {
                gm.Board.Collect(gm.FirstCard, gm.SecondCard);
                ScoreManager.NextTurn();
            }
            else
            {
                gm.FirstCard.Flip();
                gm.SecondCard.Flip();
                ScoreManager.Miss();
            }

            if (gm.Board.CardsLeft <= 0)
            {
                gm.ChangeState(GameStates.Win);
                ScoreManager.Stop();
            }
            else
            {
                gm.ChangeState(GameStates.FlipFirstCard);
            }
        }
    }
}
