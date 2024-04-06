namespace LiveProject001;

public static class TileObjectFactory
{
    private static Dictionary<TileObjects, Texture2D> _tileObjectTextures;

    public static void Initialize()
    {
        _tileObjectTextures = new()
        {
            { TileObjects.Tower, Globals.Content.Load<Texture2D>("tower") },
            { TileObjects.TowerAir, Globals.Content.Load<Texture2D>("tower_air") },
            { TileObjects.TowerIce, Globals.Content.Load<Texture2D>("tower_ice") },
            { TileObjects.TowerCannon, Globals.Content.Load<Texture2D>("cannon") },
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
                Damage = 2,
                TargetingType = TargetingTypes.All,
                DamageType = DamageTypes.Normal,
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
                TargetingType = TargetingTypes.Air,
                DamageType = DamageTypes.Electricity,
            };
            tileObject.SetCooldown(1.5f);

            return tileObject;
        }

        if (type is TileObjects.TowerIce)
        {
            var tileObject = new Tower(type, GetTileObjectTexture(type))
            {
                Range = Map.TILE_SIZE * 3,
                Damage = 1,
                DamageType = DamageTypes.Ice,
                TargetingType = TargetingTypes.All,
            };
            tileObject.SetCooldown(1.5f);
            tileObject.AddEffect(Effects.Freeze);

            return tileObject;
        }

        if (type is TileObjects.TowerCannon)
        {
            var tileObject = new Tower(type, GetTileObjectTexture(type))
            {
                Range = Map.TILE_SIZE * 3,
                Damage = 4,
                DamageType = DamageTypes.Normal,
                SplashRadius = Map.TILE_SIZE * 2,
                AttackType = AttackTypes.Splash,
                TargetingType = TargetingTypes.Ground,
            };
            tileObject.SetCooldown(2.5f);

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
