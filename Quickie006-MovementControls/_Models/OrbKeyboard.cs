namespace Quickie006;

public class OrbKeyboard(Texture2D tex, Vector2 pos) : Sprite(tex, pos)
{
    public void Update()
    {
        if (InputManager.Direction != Vector2.Zero)
        {
            var dir = Vector2.Normalize(InputManager.Direction);
            position += dir * speed * Globals.TotalSeconds;
        }
    }
}
