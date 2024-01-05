namespace Project009;

public class Board
{
    public static readonly Point SIZE = new(15, 15);
    public static readonly int MINES = 40;
    public readonly SpriteFont _font;
    public readonly Tile[,] Tiles = new Tile[SIZE.X, SIZE.Y];

    public Board()
    {
        _font = Globals.Content.Load<SpriteFont>("font");

        for (int i = 0; i < SIZE.X; i++)
        {
            for (int j = 0; j < SIZE.Y; j++)
            {
                Tiles[i, j] = new(Globals.Texture, _font, i, j);
            }
        }

        Reset();
    }

    public void TurnRed()
    {
        for (int i = 0; i < SIZE.X; i++)
        {
            for (int j = 0; j < SIZE.Y; j++)
            {
                Tiles[i, j].Revealed = false;
                Tiles[i, j].Marked = true;
            }
        }
    }

    public void MarkMines()
    {
        for (int i = 0; i < SIZE.X; i++)
        {
            for (int j = 0; j < SIZE.Y; j++)
            {
                if (Tiles[i, j].Mine) Tiles[i, j].Marked = true;
            }
        }
    }

    public void Reset()
    {
        for (int i = 0; i < SIZE.X; i++)
        {
            for (int j = 0; j < SIZE.Y; j++)
            {
                Tiles[i, j].Mine = false;
                Tiles[i, j].Revealed = false;
                Tiles[i, j].Marked = false;
                Tiles[i, j].MinesAround = 0;
            }
        }

        PlaceMines();
    }

    public void PlaceMines()
    {
        Random r = new();

        for (int i = 0; i < MINES;)
        {
            var x = r.Next(SIZE.X);
            var y = r.Next(SIZE.Y);

            if (Tiles[x, y].Mine) continue;

            Tiles[x, y].Mine = true;
            i++;
        }

        CalculateMinesAround();
    }

    public bool CheckVictory()
    {
        for (int i = 0; i < SIZE.X; i++)
        {
            for (int j = 0; j < SIZE.Y; j++)
            {
                if (!Tiles[i, j].Revealed && !Tiles[i, j].Mine) return false;
            }
        }

        return true;
    }

    private void CalculateMinesAround()
    {
        for (int i = 0; i < SIZE.X; i++)
        {
            for (int j = 0; j < SIZE.Y; j++)
            {
                if (Tiles[i, j].Mine) continue;
                CalculateMinesAroundForTile(i, j);
            }
        }
    }

    private void CalculateMinesAroundForTile(int x, int y)
    {
        for (int i = x - 1; i <= x + 1; i++)
        {
            if (i < 0 || i > SIZE.X - 1) continue;

            for (int j = y - 1; j <= y + 1; j++)
            {
                if (j < 0 || j > SIZE.Y - 1) continue;
                if (i == x && j == y) continue;
                if (Tiles[i, j].Mine) Tiles[x, y].IncreaseMinesAround();
            }
        }
    }

    public void RevealTilesAround(int x, int y)
    {
        for (int i = x - 1; i <= x + 1; i++)
        {
            if (i < 0 || i > SIZE.X - 1) continue;

            for (int j = y - 1; j <= y + 1; j++)
            {
                if (j < 0 || j > SIZE.Y - 1) continue;
                if (i == x && j == y) continue;
                Tiles[i, j].Reveal();
            }
        }
    }

    public void DoubleRevealTilesAround(int x, int y)
    {
        for (int i = x - 1; i <= x + 1; i++)
        {
            if (i < 0 || i > SIZE.X - 1) continue;

            for (int j = y - 1; j <= y + 1; j++)
            {
                if (j < 0 || j > SIZE.Y - 1) continue;
                if (i == x && j == y) continue;
                if (Tiles[i, j].Marked) continue;
                Tiles[i, j].Reveal();
                if (Tiles[i, j].Mine) return;
            }
        }
    }

    public void Update()
    {
        for (int i = 0; i < SIZE.X; i++)
        {
            for (int j = 0; j < SIZE.Y; j++)
            {
                Tiles[i, j].Update();
            }
        }
    }

    public void Draw()
    {
        for (int i = 0; i < SIZE.X; i++)
        {
            for (int j = 0; j < SIZE.Y; j++)
            {
                Tiles[i, j].Draw();
            }
        }
    }
}
