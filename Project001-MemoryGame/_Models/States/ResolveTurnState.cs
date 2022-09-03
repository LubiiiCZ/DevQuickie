namespace Project001;

public class ResolveTurnState : GameState
{
    public override void Update(GameManager gm)
    {
        if (InputManager.MouseClicked)
        {
            if (gm.FirstCard.Id == gm.SecondCard.Id)
            {
                gm.FirstCard.Visible = false;
                gm.SecondCard.Visible = false;
            }
            else
            {
                gm.FirstCard.Flip();
                gm.SecondCard.Flip();
            }

            gm.ChangeState(new FlipFirstCardState());
        }
    }
}
