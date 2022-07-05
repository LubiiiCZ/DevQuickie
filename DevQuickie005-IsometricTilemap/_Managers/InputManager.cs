namespace Quickie005;

public static class InputManager
{
    private static KeyboardState _lastKeyboardState;
    private static Point _direction;
    public static Point Direction => _direction;
    public static Point MousePosition => Mouse.GetState().Position;

    public static void Update()
    {
        var keyboardState = Keyboard.GetState();

        _direction = Point.Zero;

        if (keyboardState.IsKeyDown(Keys.W) && _lastKeyboardState.IsKeyUp(Keys.W)) _direction.Y--;
        if (keyboardState.IsKeyDown(Keys.S) && _lastKeyboardState.IsKeyUp(Keys.S)) _direction.Y++;
        if (keyboardState.IsKeyDown(Keys.A) && _lastKeyboardState.IsKeyUp(Keys.A)) _direction.X--;
        if (keyboardState.IsKeyDown(Keys.D) && _lastKeyboardState.IsKeyUp(Keys.D)) _direction.X++;

        _lastKeyboardState = keyboardState;
    }
}
