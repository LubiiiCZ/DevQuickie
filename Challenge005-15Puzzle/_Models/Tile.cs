namespace Challenge005;

public class Tile(Texture2D texture, int id, Rectangle sourceRectangle, Point location)
{
    private readonly Texture2D _texture = texture;
    public Vector2 Position => new(Location.X * SourceRectangle.Width, Location.Y * SourceRectangle.Height);
    public Point Location = location;
    public readonly Rectangle SourceRectangle = sourceRectangle;
    public Rectangle TileRectangle => new(Position.ToPoint(), SourceRectangle.Size);
    public int Id = id;

    public bool CheckClick(Point pos)
    {
        return TileRectangle.Contains(pos);
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, Position, SourceRectangle, Color.White);
    }
}
