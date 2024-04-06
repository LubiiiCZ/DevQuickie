namespace LiveProject001;

public class Tile : Sprite
{
    public bool BlockingPath { get; set; }
    public bool BlockingBuild { get; set; }
    public readonly int MapX;
    public readonly int MapY;
    public Tiles type;
    public TileObject TileObject { get; set; }

    public Tile(Tiles tileType, Texture2D texture, int mapX, int mapY) : base(texture, Map.MapToScreen(mapX, mapY))
    {
        type = tileType;
        MapX = mapX;
        MapY = mapY;
    }

    public void PlaceObject(TileObject tileObject)
    {
        TileObject = tileObject;
        TileObject.Owner = this;
        TileObject.Position = Position;
    }

    public void RemoveObject()
    {
        if (TileObject is null) return;
        TileObject = null;
    }

    public bool IsPathBlocked()
    {
        if (TileObject is not null)
        {
            return BlockingPath || TileObject.BlockingPath;
        }
        else
        {
            return BlockingPath;
        }
    }

    public bool IsBuildBlocked()
    {
        if (TileObject is not null)
        {
            return BlockingBuild || TileObject.BlockingBuild;
        }
        else
        {
            return BlockingBuild;
        }
    }

    public static event EventHandler<Tile> OnSelect;

    public virtual void UpdateTileSelection()
    {
        if (InputManager.WasTapped(Rectangle))
        {
            OnSelect?.Invoke(this, this);
        }
    }

    public override void Draw()
    {
        base.Draw();
        TileObject?.Draw();
    }
}
