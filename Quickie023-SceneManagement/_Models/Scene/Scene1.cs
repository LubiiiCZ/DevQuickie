namespace Quickie023;

public class Scene1(GameManager gameManager) : Scene(gameManager)
{
    private Texture2D _screen;
    private Sprite _object;

    protected override void Load()
    {
        _screen = Globals.Content.Load<Texture2D>("screen");
        _object = new(Globals.Content.Load<Texture2D>("object"), new(350, 400));
    }

    public override void Activate()
    {
        game.Character.Position = new(350, 500);
    }

    public override void Update()
    {
        _object.Rotation += Globals.Time * 3f;
        game.Character.Update();
    }

    protected override void Draw()
    {
        Globals.SpriteBatch.Draw(_screen, Vector2.Zero, Color.White);
        _object.Draw();
        game.Character.Draw();
    }
}
