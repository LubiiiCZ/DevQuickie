using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended;

namespace Chill006_Tiled;

public class GameManager
{
    public Character Character { get; }
    private readonly TiledMap _tiledMap;
    private readonly TiledMapRenderer _tiledMapRenderer;
    private readonly OrthographicCamera _camera;
    private readonly float _maxX;
    private readonly float _maxY;

    public GameManager(Game game)
    {
        Character = new(game.Content.Load<Texture2D>("hero"), new(200, 200));
        _tiledMap = game.Content.Load<TiledMap>("map");
        _tiledMapRenderer = new(game.GraphicsDevice, _tiledMap);

        _camera = new OrthographicCamera(game.GraphicsDevice);

        _maxX = Math.Max(0, _tiledMap.WidthInPixels - Globals.WindowSize.X);
        _maxY = Math.Max(0, _tiledMap.HeightInPixels - Globals.WindowSize.Y);
    }

    public void Update()
    {
        _tiledMapRenderer.Update(Globals.GameTime);

        Character.Update();
        Character.Position = new Vector2(
            MathHelper.Clamp(Character.Position.X, Character.Origin.X, _tiledMap.WidthInPixels - Character.Origin.X),
            MathHelper.Clamp(Character.Position.Y, Character.Origin.Y, _tiledMap.HeightInPixels - Character.Origin.Y));

        _camera.LookAt(Character.Position);
        _camera.Position = new Vector2(
            MathHelper.Clamp(Character.Position.X - (Globals.WindowSize.X / 2), 0, _maxX),
            MathHelper.Clamp(Character.Position.Y - (Globals.WindowSize.Y / 2), 0, _maxY));
    }

    public void Draw()
    {
        Globals.SpriteBatch.Begin(transformMatrix: _camera.GetViewMatrix());
        _tiledMapRenderer.Draw(_camera.GetViewMatrix());
        Character.Draw();
        Globals.SpriteBatch.End();
    }
}
