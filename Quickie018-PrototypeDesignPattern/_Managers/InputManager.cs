namespace Quickie018;

public static class InputManager
{
    private static MouseState _oldMouse;
    public static bool Clicked { get; private set; }
    public static bool RightClicked { get; private set; }
    public static Rectangle MouseRectangle { get; private set; }

    public static void Update()
    {
        var mouseState = Mouse.GetState();

        Clicked = mouseState.LeftButton == ButtonState.Pressed && _oldMouse.LeftButton == ButtonState.Released;
        RightClicked = mouseState.RightButton == ButtonState.Pressed && _oldMouse.RightButton == ButtonState.Released;
        MouseRectangle = new(mouseState.Position.X, mouseState.Position.Y, 1, 1);

        _oldMouse = mouseState;
    }
}
