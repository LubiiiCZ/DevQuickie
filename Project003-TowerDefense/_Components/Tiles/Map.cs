namespace Project003;

public class Map
{
    public const int TILE_SIZE = 64;
    public const int SIZE_X = 8;
    public const int SIZE_Y = 12;
    private readonly TileFactory _tileFactory;
    public Tile[,] MapTiles { get; }
    public List<Tower> Towers { get; private set; } = new();
    public List<Mine> Mines { get; private set; } = new();
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
                if (y == 0 || y == SIZE_Y - 1)
                {
                    ChangeTile(Tiles.Invalid, x, y);
                }
                else
                {
                    ChangeTile(Tiles.Grass, x, y);
                }
            }
        }

        Tile.OnSelect += HandleSelection;
        Tile.OnSpellSelect += HandleSpellSelection;
    }

    public void Reset()
    {
        Towers.Clear();
        Mines.Clear();

        for (int y = 0; y < SIZE_Y; y++)
        {
            for (int x = 0; x < SIZE_X; x++)
            {
                MapTiles[x, y].TileObject = null;
            }
        }
    }

    public void ChangeTile(Tiles type, int mapX, int mapY)
    {
        MapTiles[mapX, mapY] = _tileFactory.CreateTile(type, mapX, mapY);
    }

    public void PlaceObject(TileObject tileObject, int mapX, int mapY)
    {
        MapTiles[mapX, mapY].PlaceObject(tileObject);
        if (tileObject is Tower tower) Towers.Add(tower);
        if (tileObject is Mine mine) Mines.Add(mine);
    }

    public event EventHandler<SelectionData> OnTileSelection;
    public event EventHandler<SelectionData> OnSpellTileSelection;

    public void HandleSelection(object sender, SelectionData data)
    {
        OnTileSelection?.Invoke(this, data);
    }

    public void HandleSpellSelection(object sender, SelectionData data)
    {
        OnSpellTileSelection?.Invoke(this, data);
    }

    public void Update()
    {
        for (int y = 0; y < SIZE_Y; y++)
        {
            for (int x = 0; x < SIZE_X; x++) MapTiles[x, y].Update();
        }
    }

    public void CheckSpellTileSelection()
    {
        for (int y = 0; y < SIZE_Y; y++)
        {
            for (int x = 0; x < SIZE_X; x++) MapTiles[x, y].CheckSpellSelection();
        }
    }

    public void DrawProjectiles()
    {
        Towers.ForEach(t => t.Projectiles.ForEach(p => p.Draw()));
    }

    public void UpdateTowers()
    {
        Towers.ForEach(t => t.Update());
    }

    public void UpdateMines()
    {
        foreach (var mine in Mines)
        {
            if (mine.Dead)
            {
                mine.Owner.RemoveObject();
            }
        }

        Mines.RemoveAll(m => m.Dead);
    }

    public void UpdateTowersSelection()
    {
        Towers.ForEach(t => t.UpdateSelection());
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
