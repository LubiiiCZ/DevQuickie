namespace Challenge002;

public class Deck : Clickable
{
    private readonly Dictionary<Values, Texture2D> _textures = [];
    private readonly List<Card> _cards = [];
    public Values DiscardValue { get; private set; }
    private Vector2 _position { get; }
    private Vector2 _discardPosition { get; }

    public Deck()
    {
        _position = new(250, 150);

        _textures.Add(Values.Back, Globals.Content.Load<Texture2D>("0"));
        _textures.Add(Values.One, Globals.Content.Load<Texture2D>("1"));
        _textures.Add(Values.Two, Globals.Content.Load<Texture2D>("2"));
        _textures.Add(Values.Three, Globals.Content.Load<Texture2D>("3"));
        _textures.Add(Values.Four, Globals.Content.Load<Texture2D>("4"));
        _textures.Add(Values.Five, Globals.Content.Load<Texture2D>("5"));
        _textures.Add(Values.Six, Globals.Content.Load<Texture2D>("6"));
        _textures.Add(Values.Llama, Globals.Content.Load<Texture2D>("7"));

        _discardPosition = new(_position.X + 100, _position.Y);
        RectangleArea = new(_position.ToPoint(), new(_textures[Values.Back].Width, _textures[Values.Back].Height));
    }

    public void Reset()
    {
        _cards.Clear();

        for (int i = 0; i < 8; i++)
        {
            _cards.Add(new(Values.One, _textures[Values.One]));
            _cards.Add(new(Values.Two, _textures[Values.Two]));
            _cards.Add(new(Values.Three, _textures[Values.Three]));
            _cards.Add(new(Values.Four, _textures[Values.Four]));
            _cards.Add(new(Values.Five, _textures[Values.Five]));
            _cards.Add(new(Values.Six, _textures[Values.Six]));
            _cards.Add(new(Values.Llama, _textures[Values.Llama]));
        }

        Shuffle();
    }

    public bool AnyCardsLeft()
    {
        return _cards.Count > 0;
    }

    public void DiscardCard(Values value)
    {
        DiscardValue = value;
    }

    public void Shuffle()
    {
        Random rng = new();
        int n = _cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (_cards[k], _cards[n]) = (_cards[n], _cards[k]);
        }
    }

    public Card DrawCard()
    {
        if (_cards.Count < 1) return null;

        var card = _cards.First();
        _cards.Remove(card);
        return card;
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_textures[Values.Back], _position, Color.White);
        FontWriter.DrawText(_cards.Count.ToString(), new(_position.X + 15, _position.Y - 60), Color.Black);
        Globals.SpriteBatch.Draw(_textures[DiscardValue], _discardPosition, Color.White);
    }
}
