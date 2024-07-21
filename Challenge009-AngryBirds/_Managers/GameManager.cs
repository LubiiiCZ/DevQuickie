using nkast.Aether.Physics2D.Dynamics;
using nkast.Aether.Physics2D.Dynamics.Contacts;

namespace Challenge009;

public class GameManager
{
    public World world;
    private List<Box> _boxes = [];
    private Alien _alien;
    private bool _dragging;
    private bool _loaded = true;
    //private Vector2 _startDragPos;
    private Texture2D _powerBar;
    private Vector2 _startPos;

    public GameManager()
    {
        _powerBar = Globals.Content.Load<Texture2D>("shadow");

        world = new()
        {
            Gravity = new(0, 9.81f),
        };

        _startPos = new(5f, Globals.WindowSize.Y * 0.9f / Globals.COEF - 2.5f);

        /*for (int i = 0; i < 6; i++)
        {
            Vector2 pos = new(i*2 + 2.5f, 21.5f);
            Sensor s = new(2f, world, pos);
            s.body.OnCollision += OnSensoring;
            s.value = i + 1;
        }*/

        Restart();
    }

    private void Restart()
    {
        _loaded = true;
        _dragging = false;

        _boxes.Clear();
        world.Clear();

        _boxes.Add(new(1f, world, new(15f, Globals.WindowSize.Y * 0.9f / Globals.COEF - 0.5f)));
        _boxes.Add(new(1f, world, new(16f, Globals.WindowSize.Y * 0.9f / Globals.COEF - 0.5f)));
        _boxes.Add(new(1f, world, new(17f, Globals.WindowSize.Y * 0.9f / Globals.COEF - 0.5f)));
        _boxes.Add(new(1f, world, new(15.5f, Globals.WindowSize.Y * 0.9f / Globals.COEF - 1.5f)));
        _boxes.Add(new(1f, world, new(16.5f, Globals.WindowSize.Y * 0.9f / Globals.COEF - 1.5f)));
        _boxes.Add(new(1f, world, new(16f, Globals.WindowSize.Y * 0.9f / Globals.COEF - 2.5f)));

        _alien = new(1f, world, _startPos);

        world.CreateEdge(new(0f, Globals.WindowSize.Y * 0.9f / Globals.COEF), new(Globals.WindowSize.X / Globals.COEF, Globals.WindowSize.Y * 0.9f / Globals.COEF));
    }

    /*private bool OnSensoring(Fixture fixtureA, Fixture fixtureB, Contact contact)
    {
        if (fixtureB.Body == _marble.body && !_marble.Activated)
        {
            _marble.Activated = true;
            var x = (Sensor)fixtureA.Body.Tag;
            _score += x.value;
        }

        return true;
    }*/

    private void Reload()
    {
        _alien.body.Position = _startPos;
        _alien.body.IgnoreGravity = true;
        _alien.body.LinearVelocity = Vector2.Zero;
        _alien.body.AngularVelocity = 0f;
        _alien.body.Rotation = 0f;
        _loaded = true;
    }

    public void Update()
    {
        /*if (_marble?.body.Position.Y > Globals.WindowSize.Y / Globals.COEF)
        {
            world.Remove(_marble.body);
            _marble = null;
        }*/

        if (InputManager.MousePressed && !_dragging && _loaded
        && (Vector2.Distance(_alien.body.Position, InputManager.MousePosition) < 0.5f))
        {
            _dragging = true;
        }

        if (InputManager.RightClicked)
        {
            Reload();
        }

        if (InputManager.Released && _dragging)
        {
            _dragging = false;
            _alien.body.IgnoreGravity = false;
            var direction = _alien.body.Position - InputManager.MousePosition;
            _alien.body.ApplyLinearImpulse(direction * 5f);
            _loaded = false;
        }

        if (InputManager.KeyPressed(Keys.Space))
        {
            Restart();
        }

        world.Step(Globals.Time);
    }

    public void Draw()
    {
        Matrix m = Matrix.CreateScale(Globals.COEF, Globals.COEF, 0);

        Globals.SpriteBatch.Begin(transformMatrix: m);

        foreach (var item in _boxes)
        {
            item.Draw();
        }

        _alien.Draw();

        if (_dragging)
        {
            Globals.SpriteBatch.Draw(_powerBar, (_alien.body.Position + InputManager.MousePosition) / 2, null, Color.Red,
                MathF.Atan2((_alien.body.Position - InputManager.MousePosition).Y, (_alien.body.Position - InputManager.MousePosition).X),
                _powerBar.Bounds.Size.ToVector2() / 2,
                new Vector2((_alien.body.Position - InputManager.MousePosition).Length() * (Globals.COEF / _powerBar.Width), 1) / Globals.COEF,
                SpriteEffects.None, 0f);
        }

        /*foreach (var item in _sensors)
        {
            item.Draw();
        }

        _marble?.Draw();*/

        Globals.SpriteBatch.End();
    }
}
