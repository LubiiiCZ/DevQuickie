namespace Project001;

public class FlipFirstCardState : PlayState
{
    public override void Update(GameManager gm)
    {
        var card = gm.Board.GetClickedCard();

        if (card is not null)
        {
            card.Flip();
            gm.FirstCard = card;
            gm.ChangeState(GameStates.FlipSecondCard);
            ScoreManager.Start();
        }
    }
}
