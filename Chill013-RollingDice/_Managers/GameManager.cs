namespace Chill013;

public class GameManager
{
    public List<Die> MyDice { get; set; } = [];
    public SpriteFont Font { get; set; }
    public int Sum { get; set; }

    public GameManager()
    {
        Font = Globals.Content.Load<SpriteFont>("font");
        AddDie();
    }

    public void AddDie()
    {
        Die die = new(new(100 + MyDice.Count * 78, 300));

        for (int i = 1; i < 7; i++)
        {
            Action action = i == 6 ? () => { AddDie(); Sum += die.Value; } : () => { Sum += die.Value; };
            die.AddSide(new(Globals.Content.Load<Texture2D>($"W{i}"), i, action));
        }

        MyDice.Add(die);
    }

    public void Update()
    {
        if (InputManager.KeyPressed(Keys.Space))
        {
            Sum = 0;
            foreach (var item in MyDice.ToArray())
            {
                item.Roll();
            }
        }

        foreach (var item in MyDice.ToArray())
        {
            item.Update();
        }
    }

    public void Draw()
    {
        Globals.SpriteBatch.Begin();
        Globals.SpriteBatch.DrawString(Font, Sum.ToString(), Vector2.Zero, Color.White);

        foreach (var item in MyDice)
        {
            item.Draw();
        }

        Globals.SpriteBatch.End();
    }
}
