namespace Project003;

public class Map
{
    public const int TILE_SIZE = 64;
    public const int SIZE_X = 8;
    public const int SIZE_Y = 12;
    private readonly TileFactory _tileFactory;
    public Tile[,] MapTiles { get; }
    public List<TowerTile> Towers { get; private set; } = new();

    public static Vector2 MapToScreen(int x, int y)
        => new(x * TILE_SIZE + TILE_SIZE / 2, y * TILE_SIZE  + TILE_SIZE / 2);
    public (int x, int y) ScreenToMap(Vector2 pos)
        => ((int)(pos.X - TILE_SIZE / 2) / TILE_SIZE, (int)(pos.Y - TILE_SIZE / 2) / TILE_SIZE);

    public Map()
    {
        _tileFactory = new();
        MapTiles = new Tile[SIZE_X, SIZE_Y];
        var texture = Globals.Content.Load<Texture2D>("tile");

        for (int y = 0; y < SIZE_Y; y++)
        {
            for (int x = 0; x < SIZE_X; x++)
            {
                ChangeTile(Tiles.Grass, x, y);
            }
        }

        Tile.OnSelect += HandleSelection;
    }

    public void ChangeTile(Tiles type, int mapX, int mapY)
    {
        MapTiles[mapX, mapY] = _tileFactory.CreateTile(type, mapX, mapY);
        if (type is Tiles.Tower) Towers.Add((TowerTile)MapTiles[mapX, mapY]);
    }

    public void HandleSelection(object sender, SelectionData data)
    {
        ChangeTile(Tiles.Tower, data.MapX, data.MapY);
    }

    public void Update()
    {
        for (int y = 0; y < SIZE_Y; y++)
        {
            for (int x = 0; x < SIZE_X; x++) MapTiles[x, y].Update();
        }
    }

    public void Draw()
    {
        for (int y = 0; y < SIZE_Y; y++)
        {
            for (int x = 0; x < SIZE_X; x++) MapTiles[x, y].Draw();
        }

        Towers.ForEach(t => t.Projectiles.ForEach(p => p.Draw()));
    }
}
