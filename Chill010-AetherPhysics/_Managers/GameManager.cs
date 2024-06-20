using nkast.Aether.Physics2D.Dynamics;
using nkast.Aether.Physics2D.Dynamics.Contacts;

namespace Chill010;

public class GameManager
{
    public World world;
    //private readonly Marble[] _marbles;
    //private readonly Box[] _boxes;
    private readonly List<Peg> _pegs = [];
    private readonly List<Sensor> _sensors = [];
    private Marble _marble;
    private readonly SpriteFont _font;
    private int _score = 0;
    private readonly Vector2 _scorePos;

    public GameManager()
    {
        _font = Globals.Content.Load<SpriteFont>("font");
        _scorePos = new(5, 5);

        world = new()
        {
            Gravity = new(0, 9.81f),
        };

        /*Random r = new();*/

        for (int r = 0; r < 10; r++)
        {
            for (int i = 0; i < 6 + r%2; i++)
            {
                _pegs.Add(new(0.15f, world, new(i*2 + (r%2 == 0 ? 2f : 1f) + 0.5f, r*2f + 2f)));
            }
        }

        for (int i = 0; i < 6; i++)
        {
            Vector2 pos = new(i*2 + 2.5f, 21.5f);
            Sensor s = new(2f, world, pos);
            s.body.OnCollision += OnSensoring;
            s.value = i + 1;
            _sensors.Add(s);
        }

        world.CreateEdge(new(1.25f, 0f), new(1.25f, 23f));
        world.CreateEdge(new(13.84f, 0f), new(13.84f, 23f));
    }

    private bool OnSensoring(Fixture fixtureA, Fixture fixtureB, Contact contact)
    {
        if (fixtureB.Body == _marble.body && !_marble.Activated)
        {
            _marble.Activated = true;
            var x = (Sensor)fixtureA.Body.Tag;
            _score += x.value;
        }

        return true;
    }

    public void Update()
    {
        if (InputManager.Clicked && _marble is null && InputManager.MousePosition.Y < 0.5f
            && InputManager.MousePosition.X > 1.25f && InputManager.MousePosition.X < 13.84f)
        {
            _marble = new(1f, world, InputManager.MousePosition);
        }

        if (_marble?.body.Position.Y > Globals.WindowSize.Y / Globals.COEF)
        {
            world.Remove(_marble.body);
            _marble = null;
        }

        world.Step(Globals.Time);
    }

    public void Draw()
    {
        Matrix m = Matrix.CreateScale(Globals.COEF, Globals.COEF, 0);

        Globals.SpriteBatch.Begin(transformMatrix: m);

        foreach (var item in _pegs)
        {
            item.Draw();
        }

        foreach (var item in _sensors)
        {
            item.Draw();
        }

        _marble?.Draw();

        Globals.SpriteBatch.End();

        Globals.SpriteBatch.Begin();
        Globals.SpriteBatch.DrawString(_font, _score.ToString(), _scorePos, Color.White);
        Globals.SpriteBatch.End();
    }
}
