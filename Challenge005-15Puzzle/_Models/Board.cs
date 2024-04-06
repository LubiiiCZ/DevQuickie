namespace Challenge005;

public class Board
{
    private const int SIZE = 4;
    private const int TILE_SIZE = 128;
    private Point emptyLocation = new(SIZE - 1, SIZE - 1);

    public Tile[,] Tiles = new Tile[SIZE, SIZE];

    public Board(Texture2D texture)
    {
        for (int y = 0; y < SIZE; y++)
        {
            for (int x = 0; x < SIZE; x++)
            {
                if (y == SIZE - 1 && x == SIZE - 1)
                {
                    continue;
                }

                Rectangle r = new(x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE);
                Tiles[x, y] = new(texture, y * SIZE + x, r, new(x, y));
            };
        }
    }

    public bool CheckWin()
    {
        for (int y = 0; y < SIZE; y++)
        {
            for (int x = 0; x < SIZE; x++)
            {
                if (y == emptyLocation.Y && x == emptyLocation.X) continue;
                if (y * SIZE + x != Tiles[x, y].Id) return false;
            };
        }

        return true;
    }

    public void Shuffle()
    {
        Random r = new();

        for (int i = 0; i < 1000; i++)
        {
            var x = r.Next(4);

            switch (x)
            {
                case 0: MoveEmptyDown();
                    break;

                case 1: MoveEmptyUp();
                    break;

                case 2: MoveEmptyLeft();
                    break;

                case 3: MoveEmptyRight();
                    break;

                default: continue;
            }
        }
    }

    public Tile CheckClick()
    {
        for (int y = 0; y < SIZE; y++)
        {
            for (int x = 0; x < SIZE; x++)
            {
                if (Tiles[x, y] is null) continue;

                if (Tiles[x, y].CheckClick(InputManager.MousePosition))
                {
                    return Tiles[x, y];
                }
            };
        }

        return null;
    }

    public void Update()
    {
        if (InputManager.Clicked)
        {
            var tile = CheckClick();
            if (tile is null) return;

            if (tile.Location.Y + 1 == emptyLocation.Y && tile.Location.X == emptyLocation.X) MoveEmptyUp();
            else if (tile.Location.Y - 1 == emptyLocation.Y && tile.Location.X == emptyLocation.X) MoveEmptyDown();
            else if (tile.Location.X + 1 == emptyLocation.X && tile.Location.Y == emptyLocation.Y) MoveEmptyLeft();
            else if (tile.Location.X - 1 == emptyLocation.X && tile.Location.Y == emptyLocation.Y) MoveEmptyRight();
        }
    }

    public void MoveEmptyUp()
    {
        if (emptyLocation.Y == 0) return;

        Tiles[emptyLocation.X, emptyLocation.Y] = Tiles[emptyLocation.X, emptyLocation.Y - 1];
        Tiles[emptyLocation.X, emptyLocation.Y].Location.Y++;

        Tiles[emptyLocation.X, emptyLocation.Y - 1] = null;
        emptyLocation.Y--;
    }

    public void MoveEmptyDown()
    {
        if (emptyLocation.Y == SIZE - 1) return;

        Tiles[emptyLocation.X, emptyLocation.Y] = Tiles[emptyLocation.X, emptyLocation.Y + 1];
        Tiles[emptyLocation.X, emptyLocation.Y].Location.Y--;

        Tiles[emptyLocation.X, emptyLocation.Y + 1] = null;
        emptyLocation.Y++;
    }

    public void MoveEmptyLeft()
    {
        if (emptyLocation.X == 0) return;

        Tiles[emptyLocation.X, emptyLocation.Y] = Tiles[emptyLocation.X - 1, emptyLocation.Y];
        Tiles[emptyLocation.X, emptyLocation.Y].Location.X++;

        Tiles[emptyLocation.X - 1, emptyLocation.Y] = null;
        emptyLocation.X--;
    }

    public void MoveEmptyRight()
    {
        if (emptyLocation.X == SIZE - 1) return;

        Tiles[emptyLocation.X, emptyLocation.Y] = Tiles[emptyLocation.X + 1, emptyLocation.Y];
        Tiles[emptyLocation.X, emptyLocation.Y].Location.X--;

        Tiles[emptyLocation.X + 1, emptyLocation.Y] = null;
        emptyLocation.X++;
    }

    public void Draw()
    {
        for (int y = 0; y < SIZE; y++)
        {
            for (int x = 0; x < SIZE; x++)
            {
                Tiles[x, y]?.Draw();
            };
        }
    }
}
