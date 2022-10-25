namespace Project001;

public class Board
{
    private const int CARDS_DIM = 6;
    private const int CARD_SPACING = 10;
    public List<Card> Cards { get; } = new();
    public int CardsLeft { get; private set; }

    public Board()
    {
        var back = Globals.Content.Load<Texture2D>("back");

        var window = Globals.SpriteBatch.GraphicsDevice.PresentationParameters.Bounds;
        Point cardDistance = new(back.Width + CARD_SPACING, back.Height + CARD_SPACING);
        Point boardSize = new((cardDistance.X * CARDS_DIM) - CARD_SPACING, (cardDistance.Y * CARDS_DIM) - CARD_SPACING);
        Point boardSpacing = new((window.Width - boardSize.X + back.Width) / 2, (window.Height - boardSize.Y + back.Height) / 2);

        const int cardsCount = CARDS_DIM * CARDS_DIM;
        CardsLeft = cardsCount;
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
            var x = (cardDistance.X * (i % CARDS_DIM)) + boardSpacing.X;
            var y = (cardDistance.Y * (i / CARDS_DIM)) + boardSpacing.Y;
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
            if (card.Flipping) continue;

            if (card.CardRectangle.Intersects(InputManager.MouseRectangle))
            {
                return card;
            }
        }

        return null;
    }

    public void Collect(Card c1, Card c2)
    {
        c1.Visible = false;
        c2.Visible = false;
        CardsLeft -= 2;
    }

    public void Reset()
    {
        CardsLeft = CARDS_DIM * CARDS_DIM;

        foreach (Card card in Cards)
        {
            card.Reset();
        }

        Shuffle();
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

    public void Update()
    {
        foreach (Card card in Cards)
        {
            card.Update();
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
