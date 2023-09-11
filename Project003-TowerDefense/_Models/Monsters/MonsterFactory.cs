namespace Project003;

public class MonsterFactory
{
    private Dictionary<Monsters, MonsterData> _monsterData = new()
    {
        { Monsters.Ninja, new(){
            Texture = Globals.Content.Load<Texture2D>("hero"),
            MaxHealth = 3,
            Health = 3,
            Speed = 150,
        }},
        { Monsters.RedNinja, new(){
            Texture = Globals.Content.Load<Texture2D>("hero_boss"),
            MaxHealth = 5,
            Health = 5,
            Speed = 200,
        }},
    };

    public Monster CreateMonster(Monsters type, Vector2 pos)
    {
        return new Monster(_monsterData[type], pos);
    }
}
