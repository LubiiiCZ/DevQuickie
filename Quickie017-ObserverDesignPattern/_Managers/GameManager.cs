namespace Quickie017;

public class GameManager
{
    private Hero _hero;
    private UI _ui;
    private SoundManager _soundManager;
    private readonly List<Sprite> _gems = new();
    private readonly List<Gate> _gates = new();
    private readonly Texture2D _gate;
    private readonly Texture2D _openGate;

    public GameManager()
    {
        _gate = Globals.Content.Load<Texture2D>("gate");
        _openGate = Globals.Content.Load<Texture2D>("opengate");
        Reset();
    }

    public void Reset()
    {
        _gems.Clear();
        _gates.Clear();
        _hero = new(Globals.Content.Load<Texture2D>("hero"), new(100, 100));
        _ui = new(Globals.Content.Load<SpriteFont>("font"), new(20, 20), _hero);
        _soundManager = new(_hero);
        var gem = Globals.Content.Load<Texture2D>("gem");
        for (int i = 1; i <= 10; i++) _gems.Add(new(gem, new(i * 64, 250)));
        for (int i = 1; i <= 5; i++) _gates.Add(new(_gate, _openGate, new(i * 100, 400), i * 2, _hero));
    }

    private void CheckGemPickups()
    {
        foreach (var gem in _gems.ToArray())
        {
            if (_hero.Rectangle.Intersects(gem.Rectangle))
            {
                _gems.Remove(gem);
                _hero.CollectGem();
            }
        }
    }

    public void Update()
    {
        InputManager.Update();
        if (InputManager.Reset) Reset();
        _hero.Update();
        CheckGemPickups();
    }

    public void Draw()
    {
        Globals.SpriteBatch.Begin();
        foreach (var gem in _gems) gem.Draw();
        foreach (var gate in _gates) gate.Draw();
        _hero.Draw();
        _ui.Draw();
        Globals.SpriteBatch.End();
    }
}
