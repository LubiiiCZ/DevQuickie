namespace Quickie003;

public static class InputManager
{
    private static MouseState _lastMouseState;
    public static bool HasClicked { get; private set; }
    public static Vector2 MousePosition { get; private set; }

    public static void Update()
    {
        var mouseState = Mouse.GetState();

        HasClicked = mouseState.LeftButton == ButtonState.Pressed && _lastMouseState.LeftButton == ButtonState.Released;
        MousePosition = mouseState.Position.ToVector2();

        _lastMouseState = mouseState;
    }
}
