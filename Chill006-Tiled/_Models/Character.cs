namespace Chill006_Tiled;

public class Character(Texture2D texture, Vector2 position) : Sprite(texture, position)
{
    private readonly int _speed = 300;

    public void Update()
    {
        if (InputManager.KeyDown(Keys.W)) Position.Y -= Globals.Time * _speed;
        if (InputManager.KeyDown(Keys.S)) Position.Y += Globals.Time * _speed;
        if (InputManager.KeyDown(Keys.A)) Position.X -= Globals.Time * _speed;
        if (InputManager.KeyDown(Keys.D)) Position.X += Globals.Time * _speed;
    }
}
