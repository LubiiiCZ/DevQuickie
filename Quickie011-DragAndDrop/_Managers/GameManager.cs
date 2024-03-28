namespace Quickie011;

public class GameManager
{
    private readonly List<Gem> _gems = [];
    private readonly List<Socket> _sockets = [];

    public GameManager()
    {
        var gemTexture = Globals.Content.Load<Texture2D>("gem");
        var socketTexture = Globals.Content.Load<Texture2D>("socket");

        for (int i = 0; i < 10; i++)
        {
            _gems.Add(new(gemTexture, new(100 + (i * 75), 100)));
            _sockets.Add(new(socketTexture, new(100 + (i * 75), 300)));
        }
    }

    public void Update()
    {
        InputManager.Update();
        DragDropManager.Update();
    }

    public void Draw()
    {
        foreach (var item in _sockets)
        {
            item.Draw();
        }

        foreach (var item in _gems)
        {
            item.Draw();
        }
    }
}
