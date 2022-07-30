namespace Quickie006;

public class GameManager
{
    private readonly OrbKeyboard _orbKeyboard;
    private readonly OrbMouseFollow _orbMouseFollow;
    private readonly OrbMouseClick _orbMouseClick;
    private readonly Ship _ship;

    public GameManager()
    {
        _orbKeyboard = new(Globals.Content.Load<Texture2D>("orb-red"), new(300, 300));
        _orbMouseFollow = new(Globals.Content.Load<Texture2D>("orb-blue"), new(400, 400));
        _orbMouseClick = new(Globals.Content.Load<Texture2D>("orb-brown"), new(500, 500));
        _ship = new(Globals.Content.Load<Texture2D>("ship"), new(200, 200));
    }

    public void Update()
    {
        InputManager.Update();
        _orbKeyboard.Update();
        _orbMouseFollow.Update();
        _orbMouseClick.Update();
        _ship.Update();
    }

    public void Draw()
    {
        _orbKeyboard.Draw();
        _orbMouseFollow.Draw();
        _orbMouseClick.Draw();
        _ship.Draw();
    }
}
