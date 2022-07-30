namespace Quickie006;

public static class InputManager
{
    private static MouseState _lastMouseState;
    private static Vector2 _direction;
    public static Vector2 Direction => _direction;
    private static Vector2 _directionArrows;
    public static Vector2 DirectionArrows => _directionArrows;
    public static Vector2 MousePosition => Mouse.GetState().Position.ToVector2();
    public static bool MouseClicked { get; private set; }

    public static void Update()
    {
        var keyboardState = Keyboard.GetState();

        _direction = Vector2.Zero;
        if (keyboardState.IsKeyDown(Keys.W)) _direction.Y--;
        if (keyboardState.IsKeyDown(Keys.S)) _direction.Y++;
        if (keyboardState.IsKeyDown(Keys.A)) _direction.X--;
        if (keyboardState.IsKeyDown(Keys.D)) _direction.X++;

        _directionArrows = Vector2.Zero;
        if (keyboardState.IsKeyDown(Keys.Up)) _directionArrows.Y++;
        if (keyboardState.IsKeyDown(Keys.Down)) _directionArrows.Y--;
        if (keyboardState.IsKeyDown(Keys.Left)) _directionArrows.X--;
        if (keyboardState.IsKeyDown(Keys.Right)) _directionArrows.X++;

        MouseClicked = (Mouse.GetState().LeftButton == ButtonState.Pressed) && (_lastMouseState.LeftButton == ButtonState.Released);
        _lastMouseState = Mouse.GetState();
    }
}
