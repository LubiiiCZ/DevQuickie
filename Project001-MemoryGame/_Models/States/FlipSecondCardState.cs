namespace Project001;

public class FlipSecondCardState : PlayState
{
    public override void Update(GameManager gm)
    {
        var card = gm.Board.GetClickedCard();

        if (card is not null && card != gm.FirstCard)
        {
            card.Flip();
            gm.SecondCard = card;
            gm.ChangeState(GameStates.ResolveTurn);
        }
    }
}
