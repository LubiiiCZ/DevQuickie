namespace Chill010;

public static class InputManager
{
    private static KeyboardState _lastKeyboard;
    private static KeyboardState _currentKeyboard;
    private static MouseState _oldMouse;
    public static bool Clicked { get; private set; }
    public static bool RightClicked { get; private set; }
    public static Vector2 MousePosition => Mouse.GetState().Position.ToVector2() / Globals.COEF;

    public static bool KeyPressed(Keys key)
    {
        return _currentKeyboard.IsKeyDown(key) && _lastKeyboard.IsKeyUp(key);
    }

    public static bool KeyDown(Keys key)
    {
        return _currentKeyboard.IsKeyDown(key);
    }

    public static void Update()
    {
        _lastKeyboard = _currentKeyboard;
        _currentKeyboard = Keyboard.GetState();

        var mouseState = Mouse.GetState();
        Clicked = mouseState.LeftButton == ButtonState.Pressed && _oldMouse.LeftButton == ButtonState.Released;
        RightClicked = mouseState.RightButton == ButtonState.Pressed && _oldMouse.RightButton == ButtonState.Released;
        _oldMouse = mouseState;
    }
}
