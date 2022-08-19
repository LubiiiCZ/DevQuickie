namespace Quickie001;

public class UIManager
{
    private Texture2D ButtonTexture { get; }
    private SpriteFont Font { get; }
    private readonly List<Button> _buttons = new();
    public int Counter { get; set; }

    public UIManager()
    {
        ButtonTexture = Globals.Content.Load<Texture2D>("button");
        Font = Globals.Content.Load<SpriteFont>("font");
    }

    public Button AddButton(Vector2 pos)
    {
        Button b = new(ButtonTexture, pos);
        _buttons.Add(b);

        return b;
    }

    public void Update()
    {
        foreach (var item in _buttons)
        {
            item.Update();
        }
    }

    public void Draw()
    {
        foreach (var item in _buttons)
        {
            item.Draw();
        }

        Globals.SpriteBatch.DrawString(Font, Counter.ToString(), new(10, 10), Color.Black);
    }
}
