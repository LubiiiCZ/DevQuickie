namespace Quickie001;

public class GameManager
{
    private readonly UIManager _ui = new();

    public GameManager()
    {
        _ui.AddButton(new(100, 100)).OnClick += Action;
        _ui.AddButton(new(500, 100)).OnClick += ActionM1;
        _ui.AddButton(new(100, 500)).OnClick += Action10;
        _ui.AddButton(new(500, 500)).OnClick += ActionM10;
    }

    public void Action(object sender, EventArgs e)
    {
        _ui.Counter++;
    }

    public void Action10(object sender, EventArgs e)
    {
        _ui.Counter += 10;
    }

    public void ActionM1(object sender, EventArgs e)
    {
        _ui.Counter--;
    }

    public void ActionM10(object sender, EventArgs e)
    {
        _ui.Counter -= 10;
    }

    public void Update()
    {
        _ui.Update();
    }

    public void Draw()
    {
        _ui.Draw();
    }
}
