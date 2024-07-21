namespace Chill011;

public class GameManager
{
    private Body _monster;

    public GameManager()
    {
        MonsterFactory.Load();
        _monster = MonsterFactory.GetRandomMonster();
    }

    public void Update()
    {
        if (InputManager.KeyPressed(Keys.Space))
        {
            _monster = MonsterFactory.GetRandomMonster();
        }
    }

    public void Draw()
    {
        Globals.SpriteBatch.Begin();

        _monster.Draw();

        Globals.SpriteBatch.End();
    }
}
