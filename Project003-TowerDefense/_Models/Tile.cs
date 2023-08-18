namespace Project003;

public class Tile : Sprite
{
    public bool Blocked { get; set; }
    private readonly int _mapX;
    private readonly int _mapY;

    public Tile(Texture2D texture, Vector2 position, int mapX, int mapY) : base(texture, position)
    {
        _mapX = mapX;
        _mapY = mapY;
    }

    public void Update()
    {
        if (InputManager.WasTapped(Rectangle))
        {
            Blocked = !Blocked;
        }

        Color = Blocked ? Color.Red : Color.White;
    }
}
