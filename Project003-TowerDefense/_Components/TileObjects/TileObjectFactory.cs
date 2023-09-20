namespace Project003;

public static class TileObjectFactory
{
    private static Dictionary<TileObjects, Texture2D> _tileObjectTextures;

    public static void Initialize()
    {
        _tileObjectTextures = new()
        {
            { TileObjects.Tower, Globals.Content.Load<Texture2D>("tower") },
            { TileObjects.TowerAir, Globals.Content.Load<Texture2D>("tower_air") },
            { TileObjects.Wall, Globals.Content.Load<Texture2D>("wall") },
            { TileObjects.Mine, Globals.Content.Load<Texture2D>("mine") },
        };
    }

    public static Texture2D GetTileObjectTexture(TileObjects type)
    {
        return _tileObjectTextures[type];
    }

    public static TileObject CreateTileObject(TileObjects type)
    {
        if (type is TileObjects.Tower)
        {
            var tileObject = new Tower(type, GetTileObjectTexture(type))
            {
                Range = Map.TILE_SIZE * 4,
                Damage = 1,
            };
            tileObject.SetCooldown(1f);

            return tileObject;
        }

        if (type is TileObjects.TowerAir)
        {
            var tileObject = new Tower(type, GetTileObjectTexture(type))
            {
                Range = Map.TILE_SIZE * 5,
                Damage = 2,
                OnlyAir = true,
            };
            tileObject.SetCooldown(1.5f);

            return tileObject;
        }

        if (type is TileObjects.Wall)
        {
            var tileObject = new TileObject(type, GetTileObjectTexture(type))
            {
                BlockingBuild = true,
                BlockingPath = true,
            };

            return tileObject;
        }

        if (type is TileObjects.Mine)
        {
            var tileObject = new Mine(type, GetTileObjectTexture(type))
            {
                Damage = 5,
                Range = Map.TILE_SIZE * 0.5f,
                OnlyGround = true,
            };

            return tileObject;
        }

        return null;
    }
}
