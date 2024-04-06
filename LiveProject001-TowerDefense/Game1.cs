namespace LiveProject001;

public class Game1 : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private GameManager _gameManager;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        _graphics.ApplyChanges();

        Globals.Content = Content;
        _gameManager = new(_graphics);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Globals.SpriteBatch = _spriteBatch;
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        InputManager.Update();
        Globals.Update(gameTime);
        _gameManager.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        _gameManager.Draw();
        base.Draw(gameTime);
    }
}
