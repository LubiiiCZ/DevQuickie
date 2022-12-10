namespace Project002;

public class Background
{
    private readonly Point _mapTileSize = new(6, 4);
    private readonly Sprite[,] _tiles;

    public Background()
    {
        _tiles = new Sprite[_mapTileSize.X, _mapTileSize.Y];

        List<Texture2D> textures = new(5);
        for (int i = 1; i < 6; i++) textures.Add(Globals.Content.Load<Texture2D>($"tile{i}"));

        Point TileSize = new(textures[0].Width, textures[0].Height);
        Random random = new();
        for (int y = 0; y < _mapTileSize.Y; y++)
        {
            for (int x = 0; x < _mapTileSize.X; x++)
            {
                int r = random.Next(0, textures.Count);
                _tiles[x, y] = new(textures[r], new((x + 0.5f) * TileSize.X, (y + 0.5f) * TileSize.Y));
            }
        }
    }

    public void Draw()
    {
        for (int y = 0; y < _mapTileSize.Y; y++)
        {
            for (int x = 0; x < _mapTileSize.X; x++) _tiles[x, y].Draw();
        }
    }
}
