namespace Project001;

public class Button : Sprite
{
    private readonly Rectangle _rectangle;

    public Button(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
        _rectangle = new((int)(pos.X - origin.X), (int)(pos.Y - origin.Y), tex.Width, tex.Height);
    }

    public event EventHandler OnClick;

    public void Update()
    {
        if (InputManager.MouseClicked && _rectangle.Contains(InputManager.MouseRectangle))
        {
            OnClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
