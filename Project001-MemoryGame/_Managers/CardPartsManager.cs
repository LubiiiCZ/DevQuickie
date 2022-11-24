namespace Project001;

public static class CardPartsManager
{
    private static readonly List<CardPart> _parts = new();

    public static void AddParts(Card card)
    {
        foreach (var dir in Enum.GetValues<CardDirection>())
        {
            _parts.Add(new(card.Texture, dir, card.Position));
        }
    }

    public static void Update()
    {
        foreach (var part in _parts)
        {
            part.Update();
        }
        _parts.RemoveAll(p => p.Lifespan <= 0);
    }

    public static void Draw()
    {
        foreach (var part in _parts)
        {
            part.Draw();
        }
    }
}
