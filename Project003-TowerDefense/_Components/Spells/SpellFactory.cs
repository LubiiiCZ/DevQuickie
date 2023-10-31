namespace Project003;

public class SpellFactory
{
    public Dictionary<Spells, Texture2D> SpellTextures = new();

    public SpellFactory()
    {
        SpellTextures.Add(Spells.Fireball, Globals.Content.Load<Texture2D>("fireball"));
    }

    public Spell GetSpell(Spells spellID)
    {
        return new(spellID, Map.TILE_SIZE * 2, SpellTextures[spellID]);
    }
}
