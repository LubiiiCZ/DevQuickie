namespace Project003;

public class Map
{
    public static Point Size { get; } = new(8, 12);
    public Tile[,] Tiles { get; }
    public Point TileSize { get; }

    public Vector2 MapToScreen(int x, int y) =>  new(x * TileSize.X, y * TileSize.Y);
    public (int x, int y) ScreenToMap(Vector2 pos) => ((int)pos.X / TileSize.X, (int)pos.Y / TileSize.Y);

    public Map()
    {
        Tiles = new Tile[Size.X, Size.Y];
        var texture = Globals.Content.Load<Texture2D>("tile");
        TileSize = new(texture.Width, texture.Height);

        for (int y = 0; y < Size.Y; y++)
        {
            for (int x = 0; x < Size.X; x++)
            {
                Tiles[x, y] = new(texture, MapToScreen(x, y) + (TileSize.ToVector2() / 2), x, y);
            }
        }
    }

    public void Update()
    {
        for (int y = 0; y < Size.Y; y++)
        {
            for (int x = 0; x < Size.X; x++) Tiles[x, y].Update();
        }
    }

    public void Draw()
    {
        for (int y = 0; y < Size.Y; y++)
        {
            for (int x = 0; x < Size.X; x++) Tiles[x, y].Draw();
        }
    }
}
