namespace Quickie020;

public class GameManager
{
    private readonly Game _game;
    private readonly GraphicsDeviceManager _graphics;
    private readonly Sprite _sprite;
    private readonly Canvas _canvas;

    public GameManager(Game game, GraphicsDeviceManager graphics)
    {
        _game = game;
        _graphics = graphics;
        _canvas = new(_graphics.GraphicsDevice, 400, 300);
        _sprite = new(_game.Content.Load<Texture2D>("screen"), new(0, 0));
        SetResolution(400, 300);
    }

    private void SetResolution(int height, int width)
    {
        _graphics.PreferredBackBufferWidth = height;
        _graphics.PreferredBackBufferHeight = width;
        _game.Window.IsBorderless = false;
        _graphics.ApplyChanges();
        _canvas.SetDestinationRectangle();
    }

    private void SetFullScreen()
    {
        _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        _game.Window.IsBorderless = true;
        _graphics.ApplyChanges();
        _canvas.SetDestinationRectangle();
    }

    public void Update()
    {
        InputManager.Update();
        if (InputManager.IsKeyPressed(Keys.F1)) SetResolution(400, 300);
        if (InputManager.IsKeyPressed(Keys.F2)) SetResolution(1920, 1080);
        if (InputManager.IsKeyPressed(Keys.F3)) SetResolution(640, 1080);
        if (InputManager.IsKeyPressed(Keys.F4)) SetFullScreen();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _canvas.Activate();

        spriteBatch.Begin();
        _sprite.Draw(spriteBatch);
        spriteBatch.End();

        _canvas.Draw(spriteBatch);
    }
}
