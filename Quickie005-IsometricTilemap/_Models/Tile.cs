namespace Quickie005;

public class Tile(Texture2D texture, Vector2 position)
{
    private readonly Texture2D _texture = texture;
    private readonly Vector2 _position = position;
    private bool _keyboardSelected;
    private bool _mouseSelected;

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
