namespace Challenge007;

public static class InputManager
{
    private static KeyboardState _oldKeyboard;
    public static bool SpacePressed { get; private set; }

    public static void Update()
    {
        var ks = Keyboard.GetState();

        SpacePressed = ks.IsKeyDown(Keys.Space) && _oldKeyboard.IsKeyUp(Keys.Space);

        _oldKeyboard = ks;
    }
}
