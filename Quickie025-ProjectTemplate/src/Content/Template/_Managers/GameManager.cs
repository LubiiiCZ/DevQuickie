namespace Template;

public class GameManager
{
    public Character Character { get; }

    public GameManager()
    {
        Character = new(Globals.Content.Load<Texture2D>("hero"), new(200, 200));
    }

    public void Update()
    {
        Character.Update();
    }

    public void Draw()
    {
        Globals.SpriteBatch.Begin();
        Character.Draw();
        Globals.SpriteBatch.End();
    }
}
