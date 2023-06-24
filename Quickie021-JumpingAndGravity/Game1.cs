namespace Quickie021;

public class Game1 : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private GameManager _gameManager;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        Globals.WindowSize = new(Map.tiles.GetLength(1) * Map.TILE_SIZE, Map.tiles.GetLength(0) * Map.TILE_SIZE);
        _graphics.PreferredBackBufferWidth = Globals.WindowSize.X;
        _graphics.PreferredBackBufferHeight = Globals.WindowSize.Y;
        _graphics.ApplyChanges();

        Globals.Content = Content;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);
        Globals.GraphicsDevice = GraphicsDevice;

        _gameManager = new();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        Globals.Update(gameTime);
        _gameManager.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.SkyBlue);

        _gameManager.Draw();

        base.Draw(gameTime);
    }
}
