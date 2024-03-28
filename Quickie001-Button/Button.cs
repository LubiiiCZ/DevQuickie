namespace Quickie001;

public class Button(Texture2D t, Vector2 p)
{
    private readonly Texture2D _texture = t;
    private Vector2 _position = p;
    private readonly Rectangle _rect = new((int)p.X, (int)p.Y, t.Width, t.Height);
    private Color _shade = Color.White;

    public void Update()
    {
        if (Globals.MouseCursor.Intersects(_rect))
        {
            _shade = Color.DarkGray;
            if (Globals.Clicked)
            {
                Click();
            }
        }
        else
        {
            _shade = Color.White;
        }
    }

    public event EventHandler OnClick;

    private void Click()
    {
        OnClick?.Invoke(this, EventArgs.Empty);
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, _position, _shade);
    }
}
