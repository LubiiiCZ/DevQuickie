namespace Challenge006;

/* RULES
https://en.wikipedia.org/wiki/Minesweeper_(video_game)
*/

/* ANALYSIS
 * State machine
 * GameBoard
    * Random placement
    * Check surrounding tiles
 * Tiles
    * Reveal
    * Reveal others if empty
 * Victory condition
 * Defeat condition
*/

public class GameManager
{
    public readonly Board Board;

    public GameManager()
    {
        StateManager.Initialize(this);

        Globals.Texture = new(Globals.GraphicsDevice, 1, 1);
        Globals.Texture.SetData(new[] { Color.White });

        Board = new();

        Tile.OnReveal += HandleTileReveal;
        Tile.OnDoubleReveal += HandleTileDoubleReveal;
    }

    public void Reset()
    {
        Board.Reset();
        StateManager.SwitchState(States.Play);
    }

    public void HandleTileDoubleReveal(object sender, Tile tile)
    {
        Board.DoubleRevealTilesAround(tile.C.X, tile.C.Y);
    }

    public void HandleTileReveal(object sender, Tile tile)
    {
        if (tile.Mine)
        {
            Board.TurnRed();
            StateManager.SwitchState(States.End);
            return;
        }

        if (tile.MinesAround == 0 && !tile.Mine)
        {
            Board.RevealTilesAround(tile.C.X, tile.C.Y);
        }

        if (Board.CheckVictory())
        {
            Board.MarkMines();
            StateManager.SwitchState(States.End);
        }
    }

    public void Update()
    {
        StateManager.Update();
    }

    public void Draw()
    {
        Globals.SpriteBatch.Begin();
        StateManager.Draw();
        Globals.SpriteBatch.End();
    }
}
