namespace LiveProject001;

public class SpellManager
{
    private readonly SpellFactory _spellFactory = new();
    public readonly List<Spell> SpellBook = new();

    public SpellManager()
    {
    }

    public void Reset()
    {
        SpellBook.Clear();
    }

    public void AddSpell(Spells id)
    {
        var existingSpell = SpellBook.Find(s => s.SpellID == id);

        if (existingSpell is null)
        {
            var spell = _spellFactory.CreateSpell(id);
            spell.Position = new(Map.TILE_SIZE * (SpellBook.Count + 1) + Map.TILE_SIZE / 2, Map.SIZE_Y * Map.TILE_SIZE + Map.TILE_SIZE / 2);
            spell.OnCast += HandleCast;
            SpellBook.Add(spell);
        }
        else
        {
            existingSpell.Charges++;
            existingSpell.MaxCharges++;
        }
    }

    public event EventHandler<Spell> OnCast;

    public void HandleCast(object sender, Spell spell)
    {
        OnCast?.Invoke(this, sender as Spell);
    }

    public void ResetSpells()
    {
        foreach (var spell in SpellBook)
        {
            spell.Charges = spell.MaxCharges;
        }
    }

    public void UpdateSpells()
    {
        SpellBook.ForEach(s => s.Update());
    }

    public void DrawSpells()
    {
        foreach (var spell in SpellBook)
        {
            if (spell.Charges < 1) continue;
            spell.Draw();
        }
        //SpellBook.Where(s => !s.Used).ToList().ForEach(s => s.Draw()); //performance?
    }
}
