namespace Project003;

public class Map
{
    public const int TILE_SIZE = 64;
    public const int SIZE_X = 8;
    public const int SIZE_Y = 12;
    private readonly TileFactory _tileFactory;
    public Tile[,] MapTiles { get; }
    public List<TowerTile> Towers { get; private set; } = new();
    private Texture2D _rangeTexture;
    private Vector2 _rangeOrigin;

    public static Vector2 MapToScreen(int x, int y)
        => new(x * TILE_SIZE + TILE_SIZE / 2, y * TILE_SIZE  + TILE_SIZE / 2);
    public (int x, int y) ScreenToMap(Vector2 pos)
        => ((int)(pos.X - TILE_SIZE / 2) / TILE_SIZE, (int)(Math.Max(pos.Y, TILE_SIZE / 2) - TILE_SIZE / 2) / TILE_SIZE);

    public Map()
    {
        _tileFactory = new();
        MapTiles = new Tile[SIZE_X, SIZE_Y];
        var texture = Globals.Content.Load<Texture2D>("tile");

        _rangeTexture = Globals.Content.Load<Texture2D>("range");
        _rangeOrigin = new(_rangeTexture.Width / 2, _rangeTexture.Height / 2);

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

    public void DrawProjectiles()
    {
        Towers.ForEach(t => t.Projectiles.ForEach(p => p.Draw()));
    }

    public void Draw()
    {
        for (int y = 0; y < SIZE_Y; y++)
        {
            for (int x = 0; x < SIZE_X; x++) MapTiles[x, y].Draw();
        }

        foreach (var tower in Towers)
        {
            if (tower.Selected)
            {
                Globals.SpriteBatch.Draw(_rangeTexture, tower.Position, null, Color.White * 0.2f, 0f, _rangeOrigin, tower.Range / 160f, SpriteEffects.None, 0f);
            }
        }
    }
}
