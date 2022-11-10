namespace Project002;

public static class InputManager
{
    private static MouseState _lastMouseState;
    private static Vector2 _direction;
    public static Vector2 Direction => _direction;
    public static Vector2 MousePosition => Mouse.GetState().Position.ToVector2();
    public static bool MouseClicked { get; private set; }
    public static bool MouseRightClicked { get; private set; }
    public static bool MouseLeftDown { get; private set; }

    public static void Update()
    {
        var keyboardState = Keyboard.GetState();

        _direction = Vector2.Zero;
        if (keyboardState.IsKeyDown(Keys.W)) _direction.Y--;
        if (keyboardState.IsKeyDown(Keys.S)) _direction.Y++;
        if (keyboardState.IsKeyDown(Keys.A)) _direction.X--;
        if (keyboardState.IsKeyDown(Keys.D)) _direction.X++;

        MouseLeftDown = Mouse.GetState().LeftButton == ButtonState.Pressed;
        MouseClicked = MouseLeftDown && (_lastMouseState.LeftButton == ButtonState.Released);
        MouseRightClicked = Mouse.GetState().RightButton == ButtonState.Pressed
                            && (_lastMouseState.RightButton == ButtonState.Released);

        _lastMouseState = Mouse.GetState();
    }
}
