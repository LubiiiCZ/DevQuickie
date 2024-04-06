namespace Challenge007;

/* RULES
https://en.wikipedia.org/wiki/Frogger
*/

/* ANALYSIS
  * State machine
  * Frog
    * Controls, 4 directions
    * Tile movement
    - Keeping in boundaries
  * Car
    * Speed, Direction
    * Collision
  - Floating Log
    - Carry frog
  - Win condition - getting to the other side
  - Lose condition - hit by car, fall into river
*/

public class GameManager
{
    public Frog Froggy;
    public ThingManager Things;
    public BackgroundManager Background;

    public GameManager()
    {
        StateManager.Initialize(this);

        Globals.Texture = new(Globals.GraphicsDevice, 1, 1);
        Globals.Texture.SetData(new[] { Color.White });

        Things = new();
        Background = new();
        Things.GenerateCars();
        Things.GenerateLogs();

        Reset();
    }

    public void Reset()
    {
        StateManager.SwitchState(States.Play);
        Froggy = new(new(Globals.TileSize * 4, Globals.TileSize * 12, Globals.TileSize, Globals.TileSize));
        Things.Reset();
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
