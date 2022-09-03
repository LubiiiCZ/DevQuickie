namespace Project001;

public class Board
{
    private const int CARDS_DIM = 6;
    private const int CARD_SPACING = 10;
    private const int BOARD_SPACING = 50;
    public List<Card> Cards { get; } = new();

    public Board()
    {
        var back = Globals.Content.Load<Texture2D>("back");
        var cardDistance = back.Width + CARD_SPACING;
        const int cardsCount = CARDS_DIM * CARDS_DIM;
        const int cardsCountHalf = cardsCount / 2;

        Texture2D[] fronts = new Texture2D[cardsCountHalf];
        for (int i = 0; i < cardsCountHalf; i++)
        {
            fronts[i] = Globals.Content.Load<Texture2D>($"{i+1}");
        }

        for (int i = 0; i < cardsCount; i++)
        {
            var id = i / 2;
            var front = fronts[id];
            var x = (cardDistance * (i % CARDS_DIM)) + BOARD_SPACING;
            var y = (cardDistance * (i / CARDS_DIM)) + BOARD_SPACING;
            Cards.Add(new(id, back, front, new(x, y)));
        }

        Shuffle();
    }

    public Card GetClickedCard()
    {
        if (!InputManager.MouseClicked) return null;

        foreach (Card card in Cards)
        {
            if (!card.Visible) continue;

            if (card.CardRectangle.Intersects(InputManager.MouseRectangle))
            {
                return card;
            }
        }

        return null;
    }

    public void Shuffle()
    {
        Random rand = new();

        for (int i = Cards.Count - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            (Cards[j].Position, Cards[i].Position) = (Cards[i].Position, Cards[j].Position);
        }
    }

    public void Draw()
    {
        foreach (Card card in Cards)
        {
            card.Draw();
        }
    }
}
