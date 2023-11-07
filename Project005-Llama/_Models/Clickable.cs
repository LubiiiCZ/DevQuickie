namespace Project005;

public class Clickable
{
    public Rectangle RectangleArea { get; protected set; }
    public event EventHandler OnClick;

    public void CheckClick()
    {
        if (InputManager.LeftClicked)
        {
            if (RectangleArea.Contains(InputManager.MousePosition))
            {
                OnClick?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
