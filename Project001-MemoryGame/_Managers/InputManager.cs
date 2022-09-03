namespace Project001;

public static class InputManager
{
    private static MouseState _lastMouseState;
    public static bool MouseClicked { get; private set; }
    public static Rectangle MouseRectangle { get; private set; }

    public static void Update()
    {
        MouseClicked = (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        && (_lastMouseState.LeftButton == ButtonState.Released);
        _lastMouseState = Mouse.GetState();

        MouseRectangle = new(_lastMouseState.X, _lastMouseState.Y, 1, 1);
    }
}
