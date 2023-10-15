namespace Project003;

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
        var spell = _spellFactory.GetSpell(id);
        spell.Position = new(Map.TILE_SIZE * SpellBook.Count + Map.TILE_SIZE / 2, Map.SIZE_Y * Map.TILE_SIZE + Map.TILE_SIZE / 2);
        spell.OnCast += HandleCast;
        SpellBook.Add(spell);
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
            spell.Used = false;
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
            if (spell.Used) continue;
            spell.Draw();
        }
        //SpellBook.Where(s => !s.Used).ToList().ForEach(s => s.Draw()); //performance?
    }
}
