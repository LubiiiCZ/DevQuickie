namespace Quickie021;

public class Hero(Texture2D texture, Vector2 position) : Sprite(texture, position)
{
    private const float SPEED = 750f;
    private const float GRAVITY = 5000f;
    private const float JUMP = 1500f;
    private const int OFFSET = 10;
    private Vector2 _velocity;
    private bool _onGround;

    private Rectangle CalculateBounds(Vector2 pos)
    {
        return new((int)pos.X + OFFSET, (int)pos.Y, Texture.Width - (2 * OFFSET), Texture.Height);
    }

    private void UpdateVelocity()
    {
        var keyboardState = Keyboard.GetState();

        if (keyboardState.IsKeyDown(Keys.A)) _velocity.X = -SPEED;
        else if (keyboardState.IsKeyDown(Keys.D)) _velocity.X = SPEED;
        else _velocity.X = 0;

        _velocity.Y += GRAVITY * Globals.Time;

        if (keyboardState.IsKeyDown(Keys.Space) && _onGround)
        {
            _velocity.Y = -JUMP;
        }
    }

    private void UpdatePosition()
    {
        _onGround = false;
        var newPos = position + (_velocity * Globals.Time);
        Rectangle newRect = CalculateBounds(newPos);

        foreach (var collider in Map.GetNearestColliders(newRect))
        {
            if (newPos.X != position.X)
            {
                newRect = CalculateBounds(new(newPos.X, position.Y));
                if (newRect.Intersects(collider))
                {
                    if (newPos.X > position.X) newPos.X = collider.Left - Texture.Width + OFFSET;
                                          else newPos.X = collider.Right - OFFSET;
                    continue;
                }
            }

            newRect = CalculateBounds(new(position.X, newPos.Y));
            if (newRect.Intersects(collider))
            {
                if (_velocity.Y > 0)
                {
                    newPos.Y = collider.Top - Texture.Height;
                    _onGround = true;
                    _velocity.Y = 0;
                }
                else
                {
                    newPos.Y = collider.Bottom;
                    _velocity.Y = 0;
                }
            }
        }

        position = newPos;
    }

    public void Update()
    {
        UpdateVelocity();
        UpdatePosition();
    }
}
