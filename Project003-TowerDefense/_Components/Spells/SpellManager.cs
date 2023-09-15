namespace Project003;

public class SpellManager
{
    private readonly SpellFactory _spellFactory = new();
    public readonly List<Spell> SpellBook = new();

    public SpellManager()
    {
    }

    public void AddSpell(Spells id)
    {
        var spell = _spellFactory.GetSpell(id);
        spell.Position = new(Map.TILE_SIZE * SpellBook.Count + Map.TILE_SIZE / 2, Map.SIZE_Y * Map.TILE_SIZE + Map.TILE_SIZE / 2);
        spell.OnCast += HandleCast;
        SpellBook.Add(spell);
    }

    public event EventHandler<Spells> OnCast;

    public void HandleCast(object sender, Spells id)
    {
        OnCast?.Invoke(this, id);
    }

    public void UpdateSpells()
    {
        SpellBook.ForEach(s => s.Update());
    }

    public void DrawSpells()
    {
        SpellBook.ForEach(s => s.Draw());
    }
}
