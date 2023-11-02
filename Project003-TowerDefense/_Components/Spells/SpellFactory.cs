namespace Project003;

public class SpellFactory
{
    public Dictionary<Spells, SpellData> SpellProp = new()
    {
        { Spells.Fireball, new(){
            Texture = Globals.Content.Load<Texture2D>("fireball"),
            Range = Map.TILE_SIZE * 1,
            Damage = 3,
        }},
        { Spells.Freeze, new(){
            Texture = Globals.Content.Load<Texture2D>("freeze"),
            Range = Map.TILE_SIZE * 2,
            Damage = 0,
        }},
    };

    public Spell CreateSpell(Spells spellID)
    {
        return new(spellID, SpellProp[spellID]);
    }
}
