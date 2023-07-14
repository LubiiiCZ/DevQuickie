namespace Special002;

public static class InputManager
{
    public static Vector2 MousePosition { get; private set; }
    public static bool MouseRightDown { get; private set; }
    public static bool MouseLeftClicked { get; private set; }
    public static float Scale { get; set; } = 1f;
    private static MouseState _lastMouseState;

    public static void Update()
    {
        var ms = Mouse.GetState();
        MousePosition = ms.Position.ToVector2() / Scale;
        MouseRightDown = ms.RightButton == ButtonState.Pressed;
        MouseLeftClicked = (ms.LeftButton == ButtonState.Pressed) && (_lastMouseState.LeftButton == ButtonState.Released);
        _lastMouseState = ms;
    }
}
