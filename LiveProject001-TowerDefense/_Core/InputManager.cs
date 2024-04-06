namespace LiveProject001;

public class InputManager
{
    private static TouchCollection _touchCollection;
    public static float Scale { get; set; } = 1f;
    public static Vector2 Shift { get; set; }
    public static bool IsDragging { get; set; }
    public static Vector2 StartPosition { get; set; }
    public static object DraggedItem { get; set; }

    public static void Update()
    {
        _touchCollection = TouchPanel.GetState();
    }

    public static bool WasTapped(Rectangle target)
    {
        foreach (var tap in _touchCollection)
        {
            if (tap.State != TouchLocationState.Pressed) continue;
            if (target.Contains((tap.Position - Shift) / Scale)) return true;
        }

        return false;
    }

    public static Vector2 DragPosition()
    {
        foreach (var tap in _touchCollection)
        {
            if (tap.State == TouchLocationState.Moved)
            {
                return (tap.Position - Shift) / Scale;
            }
        }

        return Vector2.Zero;
    }

    public static bool WasTapped()
    {
        foreach (var tap in _touchCollection)
        {
            if (tap.State == TouchLocationState.Pressed) return true;
        }

        return false;
    }
}
