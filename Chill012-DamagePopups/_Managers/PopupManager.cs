namespace Chill012;

public static class PopupManager
{
    private static readonly List<Popup> _popups = [];

    public static void CreatePopup(ITargetable target, int damage)
    {
        Color c = damage switch
        {
            < 5 => Color.White,
            >= 5 and < 15 => Color.Yellow,
            >= 15 => Color.Red,
        };

        Popup p = new(target.Position, damage, c);
        _popups.Add(p);
    }

    public static void Update()
    {
        foreach (var item in _popups)
        {
            item.Update();
        }

        _popups.RemoveAll(p => p.Lifespan <= 0f);
    }

    public static void Draw()
    {
        foreach (var item in _popups)
        {
            item.Draw();
        }
    }
}
