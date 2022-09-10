namespace Quickie011;

public static class InputManager
{
    private static MouseState _lastMouseState;
    public static Vector2 MousePosition => Mouse.GetState().Position.ToVector2();
    public static bool MouseClicked { get; private set; }
    public static bool MouseReleased { get; private set; }

    public static void Update()
    {
        MouseClicked = (Mouse.GetState().LeftButton == ButtonState.Pressed)
                       && (_lastMouseState.LeftButton == ButtonState.Released);

        MouseReleased = (Mouse.GetState().LeftButton == ButtonState.Released)
                       && (_lastMouseState.LeftButton == ButtonState.Pressed);

        _lastMouseState = Mouse.GetState();
    }
}
