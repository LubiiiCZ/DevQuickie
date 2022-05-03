namespace Quickie002;

public class InputManager
{
    private readonly float _speed = 200f;
    public float Movement { get; set; }

    public void Update()
    {
        KeyboardState ks = Keyboard.GetState();
        Movement = 0;

        if (ks.IsKeyDown(Keys.D))
        {
            Movement = -_speed;
        }
        else if (ks.IsKeyDown(Keys.A))
        {
            Movement = _speed;
        }
    }
}
