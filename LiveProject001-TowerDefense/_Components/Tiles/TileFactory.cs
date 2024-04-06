namespace LiveProject001;

public class TileFactory
{
    private Dictionary<Tiles, Texture2D> _tileTextures;

    public TileFactory()
    {
        _tileTextures = new()
        {
            { Tiles.Grass, Globals.Content.Load<Texture2D>("tile") },
            { Tiles.Invalid, Globals.Content.Load<Texture2D>("tile_invalid") },
            /*{ Tiles.Tower, Globals.Content.Load<Texture2D>("tower") },
            { Tiles.TowerAir, Globals.Content.Load<Texture2D>("tower_air") },
            { Tiles.Wall, Globals.Content.Load<Texture2D>("wall") },*/
        };
    }

    public Texture2D GetTileTexture(Tiles type)
    {
        return _tileTextures[type];
    }

    public Tile CreateTile(Tiles type, int mapX, int mapY)
    {
        if (type is Tiles.Grass)
        {
            return new Tile(type, GetTileTexture(type), mapX, mapY);
        }

        if (type is Tiles.Invalid) return new Tile(type, GetTileTexture(type), mapX, mapY)
        {
            BlockingBuild = true,
        };

        /*if (type is Tiles.Tower)
        {
            var tile = new TowerTile(type, GetTileTexture(type), mapX, mapY)
            {
                Blocked = true,
                Range = Map.TILE_SIZE * 4,
                Damage = 1,
            };
            tile.SetCooldown(1f);

            return tile;
        }

        if (type is Tiles.TowerAir)
        {
            var tile = new TowerTile(type, GetTileTexture(type), mapX, mapY)
            {
                Blocked = true,
                Range = Map.TILE_SIZE * 5,
                Damage = 2,
                OnlyAir = true,
            };
            tile.SetCooldown(1.5f);

            return tile;
        }

        if (type is Tiles.Wall)
        {
            var tile = new Tile(type, GetTileTexture(type), mapX, mapY)
            {
                Blocked = true,
            };

            return tile;
        }*/

        return null;
    }
}
