namespace Project003;

public record SelectionData(int MapX, int MapY);

public class Tile : Sprite
{
    public bool Blocked { get; set; }
    private readonly int _mapX;
    private readonly int _mapY;
    public Tiles type;

    public Tile(Tiles tileType, Texture2D texture, Vector2 position, int mapX, int mapY) : base(texture, position)
    {
        type = tileType;
        _mapX = mapX;
        _mapY = mapY;
    }

    public static event EventHandler<SelectionData> OnSelect;

    public virtual void Update()
    {
        if (InputManager.WasTapped(Rectangle))
        {
            if (type == Tiles.Grass)
            {
                OnSelect?.Invoke(this, new SelectionData(_mapX, _mapY));
            }
        }

        //Color = Blocked ? Color.Red : Color.White;
    }
}
