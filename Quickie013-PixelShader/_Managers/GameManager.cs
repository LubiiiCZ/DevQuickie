namespace Quickie013;

public class GameManager
{
    private readonly Sprite _sprite;
    private readonly Vector2 _pos00, _pos01, _pos02, _pos03, _pos04;
    private readonly Effect _effect01, _effect02, _effect03, _effect04;
    private float _amount = 1;
    private float _dir = -1;

    public GameManager()
    {
        _sprite = new(Globals.Content.Load<Texture2D>("orb-red"));
        _pos00 = new(100, 100);
        _pos01 = new(200, 100);
        _pos02 = new(300, 100);
        _pos03 = new(400, 100);
        _pos04 = new(500, 100);
        _effect01 = Globals.Content.Load<Effect>("effect01");
        _effect02 = Globals.Content.Load<Effect>("effect02");
        _effect03 = Globals.Content.Load<Effect>("effect03");
        _effect04 = Globals.Content.Load<Effect>("effect04");
    }

    public void Update()
    {
        _amount += Globals.TotalSeconds * _dir;
        if (_amount < 0 || _amount > 1) _dir *= -1;
        _effect04.Parameters["amount"].SetValue(_amount);
    }

    public void Draw()
    {
        Globals.SpriteBatch.Begin();
        _sprite.Draw(_pos00);
        Globals.SpriteBatch.End();
        Globals.SpriteBatch.Begin(effect: _effect01);
        _sprite.Draw(_pos01);
        Globals.SpriteBatch.End();
        Globals.SpriteBatch.Begin(effect: _effect02);
        _sprite.Draw(_pos02);
        Globals.SpriteBatch.End();
        Globals.SpriteBatch.Begin(effect: _effect03);
        _sprite.Draw(_pos03);
        Globals.SpriteBatch.End();
        Globals.SpriteBatch.Begin(effect: _effect04);
        _sprite.Draw(_pos04);
        Globals.SpriteBatch.End();
    }
}
