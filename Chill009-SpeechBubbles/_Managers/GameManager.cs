namespace Chill009_SpeechBubbles;

public class GameManager
{
    //public Character Character { get; }
    private Bubble _bubble;

    public GameManager()
    {
        //Character = new(Globals.Content.Load<Texture2D>("hero"), new(200, 200));
        _bubble = new(Globals.Content.Load<Texture2D>("bubble"), 70, Globals.Content.Load<SpriteFont>("font"));
        _bubble.SetPosition(new(100, 350));
        _bubble.SetText("Hello Developers!" + Environment.NewLine + "How's it goin'?" + Environment.NewLine + "Play some Memory Quickie on Steam - NOW!");
        _bubble.TextColor = Color.Yellow;
    }

    public void Update()
    {
        //Character.Update();
    }

    public void Draw()
    {
        Globals.SpriteBatch.Begin();
        //Character.Draw();
        _bubble.Draw();
        Globals.SpriteBatch.End();
    }
}
