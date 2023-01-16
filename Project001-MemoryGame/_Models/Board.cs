namespace Project001;

public class Board
{
    private const int MAX_CARDS = 18;
    private Point _dimensions;
    private const int CARD_SPACING = 10;
    private readonly Point _cardDistance;
    public List<Card> Cards { get; } = new();
    public int CardsLeft { get; private set; }
    private readonly Texture2D _textureBack;
    public static readonly Texture2D[] CardTextures = new Texture2D[MAX_CARDS];

    public Board()
    {
        _textureBack = Globals.Content.Load<Texture2D>("Cards/back");
        _cardDistance = new(_textureBack.Width + CARD_SPACING, _textureBack.Height + CARD_SPACING);

        for (int i = 0; i < MAX_CARDS; i++)
        {
            CardTextures[i] = Globals.Content.Load<Texture2D>($"Cards/{i+1}");
        }
    }

    public void SetDifficulty(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                _dimensions = new(4, 4);
                break;
            case Difficulty.Medium:
                _dimensions = new(6, 4);
                break;
            case Difficulty.Hard:
                _dimensions = new(6, 6);
                break;
        }

        Point boardSize = new((_cardDistance.X * _dimensions.X) - CARD_SPACING, (_cardDistance.Y * _dimensions.Y) - CARD_SPACING);
        Point boardSpacing = new((Globals.Bounds.X - boardSize.X + _textureBack.Width) / 2, (Globals.Bounds.Y - boardSize.Y + _textureBack.Height) / 2);

        var cardsCount = _dimensions.X * _dimensions.Y;
        CardsLeft = cardsCount;
        Cards.Clear();

        for (int i = 0; i < cardsCount; i++)
        {
            var id = i / 2;
            var front = CardTextures[id];
            var x = (_cardDistance.X * (i % _dimensions.X)) + boardSpacing.X;
            var y = (_cardDistance.Y * (i / _dimensions.X)) + boardSpacing.Y;
            Cards.Add(new(id, _textureBack, front, new(x, y)));
        }
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
        CardPartsManager.AddParts(c1);
        CardPartsManager.AddParts(c2);
        SoundManager.PlayTearFX();
    }

    public void Reset()
    {
        CardsLeft = _dimensions.X * _dimensions.Y;

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
