namespace Challenge007;

public class BackgroundManager
{
    private Rectangle _startPath;
    private Rectangle _middlePath;
    private Rectangle _endPath;
    private Rectangle _road;
    private Rectangle _river;

    public BackgroundManager()
    {
        _startPath = new(0, Globals.TileSize * 12, Globals.WindowSize.X, Globals.TileSize);
        _middlePath = new(0, Globals.TileSize * 6, Globals.WindowSize.X, Globals.TileSize);
        _endPath = new(0, 0, Globals.WindowSize.X, Globals.TileSize);
        _road = new(0, Globals.TileSize * 7, Globals.WindowSize.X, Globals.TileSize * 5);
        _river = new(0, Globals.TileSize * 1, Globals.WindowSize.X, Globals.TileSize * 5);
    }

    public bool InRiver(Frog frog)
    {
        return _river.Contains(frog.R);
    }

    public bool InFinish(Frog frog)
    {
        return _endPath.Contains(frog.R);
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(Globals.Texture, _startPath, Color.LightGreen);
        Globals.SpriteBatch.Draw(Globals.Texture, _middlePath, Color.LightGreen);
        Globals.SpriteBatch.Draw(Globals.Texture, _endPath, Color.LightGreen);
        Globals.SpriteBatch.Draw(Globals.Texture, _road, Color.LightGray);
        Globals.SpriteBatch.Draw(Globals.Texture, _river, Color.LightBlue);
    }
}
