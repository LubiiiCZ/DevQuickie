namespace Quickie005;

public class Tile
{
    private readonly Texture2D _texture;
    private readonly Vector2 _position;
    private bool _keyboardSelected;
    private bool _mouseSelected;

    public Tile(Texture2D texture, Vector2 position)
    {
        _texture = texture;
        _position = position;
    }

    public void KeyboardSelect()
    {
        _keyboardSelected = true;
    }

    public void KeyboardDeselect()
    {
        _keyboardSelected = false;
    }

    public void MouseSelect()
    {
        _mouseSelected = true;
    }

    public void MouseDeselect()
    {
        _mouseSelected = false;
    }

    public void Draw()
    {
        var color = Color.White;
        if (_keyboardSelected) color = Color.Red;
        if (_mouseSelected) color = Color.Green;
        Globals.SpriteBatch.Draw(_texture, _position, color);
    }
}
