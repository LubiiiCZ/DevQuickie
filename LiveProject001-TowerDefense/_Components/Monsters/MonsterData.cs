namespace LiveProject001;

public struct MonsterData
{
    public Texture2D Texture { get; set; }
    public float MaxHealth { get; set; }
    public float Health { get; set; }
    public int Speed { get; set; }
    public float CurrentSpeed { get; set; }
    public bool Flying { get; set; }
    public Dictionary<DamageTypes, int> Resistances { get; set; }

    public MonsterData()
    {
        Resistances = new();
    }
}
