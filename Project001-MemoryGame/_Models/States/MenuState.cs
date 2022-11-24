namespace Project001;

public class MenuState : GameState
{
    private readonly List<Button> _buttons = new();

    public MenuState(GameManager gm)
    {
        var y = Globals.Bounds.Y / 2;
        var x = Globals.Bounds.X / 2;

        AddButton(new(Globals.Content.Load<Texture2D>("easy"), new(x - 300, y))).OnClick += gm.StartEasy;
        AddButton(new(Globals.Content.Load<Texture2D>("medium"), new(x, y))).OnClick += gm.StartMedium;
        AddButton(new(Globals.Content.Load<Texture2D>("hard"), new(x + 300, y))).OnClick += gm.StartHard;
    }

    private Button AddButton(Button button)
    {
        _buttons.Add(button);
        return button;
    }

    public override void Update(GameManager gm)
    {
        foreach (var button in _buttons)
        {
            button.Update();
        }
    }

    public override void Draw(GameManager gm)
    {
        foreach (var button in _buttons)
        {
            button.Draw();
        }
    }
}
