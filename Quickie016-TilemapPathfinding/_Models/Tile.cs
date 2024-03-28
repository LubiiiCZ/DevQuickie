namespace Quickie016;

public class Tile(Texture2D texture, Vector2 position, int mapX, int mapY) : Sprite(texture, position)
{
    public bool Blocked { get; set; }
    public bool Path { get; set; }
    private readonly int _mapX = mapX;
    private readonly int _mapY = mapY;

    public void Update()
    {
        if (Pathfinder.Ready() && Rectangle.Contains(InputManager.MouseRectangle))
        {
            if (InputManager.MouseClicked)
            {
                Blocked = !Blocked;
            }

            if (InputManager.MouseRightClicked)
            {
                Pathfinder.BFSearch(_mapX, _mapY);
            }
        }

        Color = Path ? Color.Green : Color.White;
        Color = Blocked ? Color.Red : Color;
    }
}
