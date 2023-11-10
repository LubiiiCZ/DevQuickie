namespace Project003;

public class SpellFactory
{
    public Dictionary<Spells, SpellData> SpellProp = new()
    {
        { Spells.Fireball, new(){
            Texture = Globals.Content.Load<Texture2D>("fireball"),
            Radius = Map.TILE_SIZE * 1,
            Damage = 3,
        }},
        { Spells.Freeze, new(){
            Texture = Globals.Content.Load<Texture2D>("freeze"),
            Radius = Map.TILE_SIZE * 2,
            Damage = 0,
        }},
        { Spells.Ligthing, new(){
            Texture = Globals.Content.Load<Texture2D>("lightning"),
            Radius = 1,
            Damage = 10,
        }},
    };

    public Spell CreateSpell(Spells spellID)
    {
        return new(spellID, SpellProp[spellID]);
    }
}
