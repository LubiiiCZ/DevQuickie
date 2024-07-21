namespace Chill012;

public class GameManager
{
    public Character Character { get; }

    public GameManager()
    {
        Character = new(Globals.Content.Load<Texture2D>("hero"), new(200, 200));
    }

    public void Update()
    {
        if (InputManager.Clicked)
        {
            PopupManager.CreatePopup(Character, Globals.R.Next(1, 21));
        }

        Character.Update();
        PopupManager.Update();
    }

    public void Draw()
    {
        Globals.SpriteBatch.Begin();
        Character.Draw();
        PopupManager.Draw();
        Globals.SpriteBatch.End();
    }
}
