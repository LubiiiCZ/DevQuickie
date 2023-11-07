namespace Project005;

public class Player
{
    public Dictionary<Values, HandCard> Hand { get; } = new();

    public Player()
    {
        Hand.Add(Values.One, new(Values.One, Globals.Content.Load<Texture2D>("1"), new(50, 400)));
        Hand.Add(Values.Two, new(Values.Two, Globals.Content.Load<Texture2D>("2"), new(150, 400)));
        Hand.Add(Values.Three, new(Values.Three, Globals.Content.Load<Texture2D>("3"), new(250, 400)));
        Hand.Add(Values.Four, new(Values.Four, Globals.Content.Load<Texture2D>("4"), new(350, 400)));
        Hand.Add(Values.Five, new(Values.Five, Globals.Content.Load<Texture2D>("5"), new(450, 400)));
        Hand.Add(Values.Six, new(Values.Six, Globals.Content.Load<Texture2D>("6"), new(550, 400)));
        Hand.Add(Values.Llama, new(Values.Llama, Globals.Content.Load<Texture2D>("7"), new(650, 400)));

        foreach (Values value in Enum.GetValues(typeof(Values)))
        {
            if (value == Values.Back) continue;
            Hand[value].OnClick += HandCardClickHandler;
        }
    }

    public void AddCard(Card card)
    {
        Hand[card.Value].Count++;
    }

    public int CardsInHand()
    {
        int sum = 0;
        foreach (Values value in Enum.GetValues(typeof(Values)))
        {
            if (value == Values.Back) continue;
            sum += Hand[value].Count;
        }

        return sum;
    }

    public event EventHandler<HandCard> OnPlayCard;

    public void HandCardClickHandler(object sender, EventArgs e)
    {
        var handCard = sender as HandCard;
        if (handCard.Count < 1) return;

        OnPlayCard?.Invoke(this, handCard);
    }

    public void CheckHandClick()
    {
        foreach (Values value in Enum.GetValues(typeof(Values)))
        {
            if (value == Values.Back) continue;
            Hand[value].CheckClick();
        }
    }

    public void Reset()
    {
        foreach (Values value in Enum.GetValues(typeof(Values)))
        {
            if (value == Values.Back) continue;
            Hand[value].Count = 0;
        }
    }

    public void DrawHand()
    {
        foreach (Values value in Enum.GetValues(typeof(Values)))
        {
            if (value == Values.Back) continue;
            Hand[value].Draw();
        }
    }
}
