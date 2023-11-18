namespace Project007;

public static class InputManager
{
    //private static KeyboardState _lastKB;

    public static bool IsKeyDown(Keys key)
    {
        return Keyboard.GetState().IsKeyDown(key);
    }

    public static void Update()
    {
        /*var kb = Keyboard.GetState();
        _lastKB = kb;*/
    }
}
