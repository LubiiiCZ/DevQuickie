namespace Quickie006;

public class OrbKeyboard : Sprite
{
    public OrbKeyboard(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
    }

    public void Update()
    {
        if (InputManager.Direction != Vector2.Zero)
        {
            var dir = Vector2.Normalize(InputManager.Direction);
            position += dir * speed * Globals.TotalSeconds;
        }
    }
}
