namespace Quickie022;

public class Map
{
    private readonly Texture2D _texture;
    public Tile[,] Tiles { get; private set; }

    public Map(int width, int height)
    {
        _texture = Globals.Content.Load<Texture2D>("tile2");
        Tiles = new Tile[width, height];

        for (int x = 0; x < Tiles.GetLength(0); x++)
        {
            for (int y = 0; y < Tiles.GetLength(1); y++)
            {
                Tiles[x, y] = new Tile(_texture, x, y);
            }
        }
    }

    public void Update()
    {
        var MousePosition = Mouse.GetState().Position.ToVector2();
        float minD = float.MaxValue;
        Tile selected = null;

        for (int x = 0; x < Tiles.GetLength(0); x++)
        {
            for (int y = 0; y < Tiles.GetLength(1); y++)
            {
                Tiles[x, y].Color = Color.White;

                var d = Vector2.Distance(MousePosition, Tiles[x, y].Position);
                if (d < minD)
                {
                    minD = d;
                    selected = Tiles[x, y];
                }
            }
        }

        if (minD < Math.Max(selected.Origin.Y, selected.Origin.X)) selected.Color = Color.Gray;
    }

    public void Draw()
    {
        for (int x = 0; x < Tiles.GetLength(0); x++)
        {
            for (int y = 0; y < Tiles.GetLength(1); y++)
            {
                Tiles[x, y].Draw();
            }
        }
    }
}
