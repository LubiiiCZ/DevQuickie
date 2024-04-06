namespace Challenge006;

public static class InputManager
{
    private static MouseState _oldMouse;
    public static bool Clicked { get; private set; }
    public static bool RightClicked { get; private set; }
    public static Point MousePosition { get; private set; }

    public static void Update()
    {
        var ms = Mouse.GetState();

        Clicked = _oldMouse.LeftButton == ButtonState.Released && ms.LeftButton == ButtonState.Pressed;
        RightClicked = _oldMouse.RightButton == ButtonState.Released && ms.RightButton == ButtonState.Pressed;
        MousePosition = ms.Position;

        _oldMouse = ms;
    }
}
