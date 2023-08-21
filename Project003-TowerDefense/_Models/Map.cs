namespace Project003;

public class Map
{
    private readonly TileFactory _tileFactory;
    public static Point Size { get; } = new(8, 12);
    public Tile[,] MapTiles { get; }
    public static Point TileSize { get; private set; }

    public static Vector2 MapToScreen(int x, int y) =>  new(x * TileSize.X, y * TileSize.Y);
    public (int x, int y) ScreenToMap(Vector2 pos)
        => ((int)(pos.X - TileSize.X / 2) / TileSize.X, (int)(pos.Y - TileSize.Y / 2) / TileSize.Y);

    public Map()
    {
        _tileFactory = new();
        MapTiles = new Tile[Size.X, Size.Y];
        var texture = Globals.Content.Load<Texture2D>("tile");
        TileSize = new(texture.Width, texture.Height);

        for (int y = 0; y < Size.Y; y++)
        {
            for (int x = 0; x < Size.X; x++)
            {
                ChangeTile(Tiles.Grass, x, y);
            }
        }

        Tile.OnSelect += (s, e) => HandleSelection(e);
    }

    public void ChangeTile(Tiles type, int mapX, int mapY)
    {
        MapTiles[mapX, mapY] = _tileFactory.CreateTile(type, mapX, mapY);
    }

    public void HandleSelection(SelectionData data)
    {
        ChangeTile(Tiles.Tower, data.MapX, data.MapY);
    }

    public void Update()
    {
        for (int y = 0; y < Size.Y; y++)
        {
            for (int x = 0; x < Size.X; x++) MapTiles[x, y].Update();
        }
    }

    public void Draw()
    {
        for (int y = 0; y < Size.Y; y++)
        {
            for (int x = 0; x < Size.X; x++) MapTiles[x, y].Draw();
        }
    }
}
