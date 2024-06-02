using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended;

namespace Chill006;

public class Map
{
    public static readonly int TILE_SIZE = 128;
    private readonly TiledMap _tiledMap;
    private readonly TiledMapRenderer _tiledMapRenderer;
    private static Rectangle[,] Colliders { get; } = new Rectangle[8, 10];

    public Map()
    {
        _tiledMap = Globals.Game.Content.Load<TiledMap>("map");
        _tiledMapRenderer = new(Globals.Game.GraphicsDevice, _tiledMap);

        var layer = _tiledMap.Layers.First();
    }

    /*public static List<Rectangle> GetNearestColliders(Rectangle bounds)
    {
        int leftTile = (int)Math.Floor((float)bounds.Left / TILE_SIZE);
        int rightTile = (int)Math.Ceiling((float)bounds.Right / TILE_SIZE) - 1;
        int topTile = (int)Math.Floor((float)bounds.Top / TILE_SIZE);
        int bottomTile = (int)Math.Ceiling((float)bounds.Bottom / TILE_SIZE) - 1;

        leftTile = MathHelper.Clamp(leftTile, 0, tiles.GetLength(1));
        rightTile = MathHelper.Clamp(rightTile, 0, tiles.GetLength(1));
        topTile = MathHelper.Clamp(topTile, 0, tiles.GetLength(0));
        bottomTile = MathHelper.Clamp(bottomTile, 0, tiles.GetLength(0));

        List<Rectangle> result = [];

        for (int x = topTile; x <= bottomTile; x++)
        {
            for (int y = leftTile; y <= rightTile; y++)
            {
                if (tiles[x, y] != 0) result.Add(Colliders[x, y]);
            }
        }

        return result;
    }*/

    public void Draw()
    {
        _tiledMapRenderer.Draw();
    }
}
