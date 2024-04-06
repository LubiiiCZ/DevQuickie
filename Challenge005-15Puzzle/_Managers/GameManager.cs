namespace Challenge005;

/* RULES
https://en.wikipedia.org/wiki/15_Puzzle
*/

/* ANALYSIS
 * Board
   * Tiles
   * Shuffling
   * Empty tile
 * Tile movement
 - Winning condition
*/

public class GameManager
{
    private readonly Board _board;

    public GameManager()
    {
        _board = new(Globals.Content.Load<Texture2D>("logo"));
        _board.Shuffle();
    }

    public void Update()
    {
        _board.Update();
        if (_board.CheckWin()) _board.Shuffle();
    }

    public void Draw()
    {
        Globals.SpriteBatch.Begin();
        _board.Draw();
        Globals.SpriteBatch.End();
    }
}
