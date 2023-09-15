namespace Project003;

public class Button : Sprite
{
    public Button(Texture2D t, Vector2 p) : base(t, p)
    {
    }

    public void Update()
    {
        if (InputManager.WasTapped(Rectangle))
        {
            Click();
        }
    }

    public event EventHandler OnTap;

    private void Click()
    {
        OnTap?.Invoke(this, EventArgs.Empty);
    }
}
