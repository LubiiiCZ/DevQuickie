namespace Project003;

public readonly record struct SelectionData(int MapX, int MapY);

public class Tile : Sprite
{
    public bool BlockingPath { get; set; }
    public bool BlockingBuild { get; set; }
    private readonly int _mapX;
    private readonly int _mapY;
    public Tiles type;
    public TileObject TileObject { get; set; }

    public Tile(Tiles tileType, Texture2D texture, int mapX, int mapY) : base(texture, Map.MapToScreen(mapX, mapY))
    {
        type = tileType;
        _mapX = mapX;
        _mapY = mapY;
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

    public static event EventHandler<SelectionData> OnSelect;
    public static event EventHandler<SelectionData> OnSpellSelect;

    public void CheckSpellSelection()
    {
        if (InputManager.WasTapped(Rectangle))
        {
            OnSpellSelect?.Invoke(this, new SelectionData(_mapX, _mapY));
        }
    }

    public virtual void Update()
    {
        if (IsBuildBlocked()) return;

        if (InputManager.WasTapped(Rectangle))
        {
            if (type == Tiles.Grass)
            {
                OnSelect?.Invoke(this, new SelectionData(_mapX, _mapY));
            }
        }
    }

    public override void Draw()
    {
        base.Draw();
        TileObject?.Draw();
    }
}
