namespace Project003;

public class MonsterFactory
{
    private Dictionary<Monsters, Texture2D> _monsterTextures;

    public MonsterFactory()
    {
        _monsterTextures = new()
        {
            { Monsters.Ninja, Globals.Content.Load<Texture2D>("hero") },
            { Monsters.RedNinja, Globals.Content.Load<Texture2D>("hero_boss") },
        };
    }

    public Texture2D GetMonsterTexture(Monsters type)
    {
        return _monsterTextures[type];
    }

    public Monster CreateMonster(Monsters type, Vector2 pos)
    {
        Monster monster = null;

        if (type is Monsters.Ninja)
        {
            monster = new Monster(GetMonsterTexture(type), pos)
            {
                MaxHealth = 3,
                Health = 3,
                Speed = 150,
            };
        }

        if (type is Monsters.RedNinja)
        {
            monster = new Monster(GetMonsterTexture(type), pos)
            {
                MaxHealth = 5,
                Health = 5,
                Speed = 200,
            };
        }

        return monster;
    }
}
