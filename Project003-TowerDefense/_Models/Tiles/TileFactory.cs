namespace Project003;

public class TileFactory
{
    private Dictionary<Tiles, Texture2D> _tileTextures;

    public TileFactory()
    {
        _tileTextures = new()
        {
            { Tiles.Grass, Globals.Content.Load<Texture2D>("tile") },
            { Tiles.Tower, Globals.Content.Load<Texture2D>("tower") }
        };
    }

    public Texture2D GetTileTexture(Tiles type)
    {
        return _tileTextures[type];
    }

    public Tile CreateTile(Tiles type, int mapX, int mapY)
    {
        if (type is Tiles.Grass) return new Tile(type, GetTileTexture(type), mapX, mapY);

        if (type is Tiles.Tower)
        {
            var tile = new TowerTile(type, GetTileTexture(type), mapX, mapY)
            {
                Blocked = true,
                Range = Map.TILE_SIZE * 4,
            };
            tile.SetCooldown(1f);

            return tile;
        }

        return null;
    }
}
