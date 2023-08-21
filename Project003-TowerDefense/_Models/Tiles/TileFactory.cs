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
        Tile tile = new(type, GetTileTexture(type), Map.MapToScreen(mapX, mapY) + (Map.TileSize.ToVector2() / 2), mapX, mapY);

        if (type is Tiles.Tower)
        {
            tile.Blocked = true;
        }

        return tile;
    }
}
