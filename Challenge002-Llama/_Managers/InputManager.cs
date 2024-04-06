namespace Challenge002;

public static class InputManager
{
    private static MouseState _lastMS;
    public static bool LeftClicked { get; private set; }
    public static Point MousePosition { get; private set; }

    public static void Update()
    {
        var ms = Mouse.GetState();

        LeftClicked = ms.LeftButton == ButtonState.Pressed && _lastMS.LeftButton == ButtonState.Released;
        MousePosition = ms.Position;

        _lastMS = ms;
    }
}
