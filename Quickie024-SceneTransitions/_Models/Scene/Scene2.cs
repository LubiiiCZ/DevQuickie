namespace Quickie024;

public class Scene2(GameManager gameManager) : Scene(gameManager)
{
    private Texture2D _screen;
    private Sprite _object;
    private readonly float _speed = 300f;
    private int _direction = 1;

    protected override void Load()
    {
        _screen = Globals.Content.Load<Texture2D>("screen2");
        _object = new(Globals.Content.Load<Texture2D>("object"), new(200, 170));
    }

    public override void Activate()
    {
        game.Character.Position = new(500, 400);
    }

    public override void Update()
    {
        _object.Position.X += _direction * _speed * Globals.Time;
        if (_direction > 0 && _object.Position.X > 400 || _direction < 0 && _object.Position.X < 100) _direction *= -1;
        game.Character.Update();
    }

    protected override void Draw()
    {
        Globals.SpriteBatch.Draw(_screen, Vector2.Zero, Color.White);
        _object.Draw();
        game.Character.Draw();
    }
}
