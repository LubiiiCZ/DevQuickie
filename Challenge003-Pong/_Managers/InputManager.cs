namespace Challenge003;

public static class InputManager
{
    private static KeyboardState _lastKB;
    public static bool SpacePressed { get; private set; }
    public static bool EnterPressed { get; private set; }

    public static bool IsKeyDown(Keys key)
    {
        return Keyboard.GetState().IsKeyDown(key);
    }

    public static void Update()
    {
        var kb = Keyboard.GetState();
        SpacePressed = kb.IsKeyDown(Keys.Space) && _lastKB.IsKeyUp(Keys.Space);
        EnterPressed = kb.IsKeyDown(Keys.Enter) && _lastKB.IsKeyUp(Keys.Enter);
        _lastKB = kb;
    }
}
