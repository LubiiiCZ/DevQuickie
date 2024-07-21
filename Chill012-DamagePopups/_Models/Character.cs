namespace Chill012;

public class Character(Texture2D texture, Vector2 position) : Sprite(texture, position), ITargetable
{
    private readonly int _speed = 300;

    public void Update()
    {
        var direction = Vector2.Zero;

        if (InputManager.KeyDown(Keys.W)) direction.Y--;
        if (InputManager.KeyDown(Keys.S)) direction.Y++;
        if (InputManager.KeyDown(Keys.A)) direction.X--;
        if (InputManager.KeyDown(Keys.D)) direction.X++;

        Position += direction * Globals.Time * _speed;
    }
}
