namespace Challenge007;

public class Thing(Rectangle r, int speed, Vector2 direction, Color color)
{
    public Rectangle R = r;
    public int Speed = speed;
    public Vector2 Direction = direction;
    private Color _color = color;

    public void UpdateMovement()
    {
        var travelDistance = Direction * Globals.Time * Speed;
        R.Location = new(R.Location.X + (int)travelDistance.X, R.Location.Y + (int)travelDistance.Y);

        if (Direction.X < 0 && R.Location.X + R.Width < 0)
        {
            R.Location = new(Globals.WindowSize.X, R.Location.Y);
        }

        if (Direction.X > 0 && R.Location.X > Globals.WindowSize.X)
        {
            R.Location = new(-R.Width, R.Location.Y);
        }
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(Globals.Texture, R, _color);
    }
}
