namespace Project003;

public class Spell : Sprite
{
    public Spells SpellID { get; }

    public Spell(Spells id, Texture2D texture) : base(texture, Vector2.Zero)
    {
        SpellID = id;
    }

    public void Update()
    {
        if (InputManager.WasTapped(Rectangle))
        {
            Click();
        }
    }

    public event EventHandler<Spells> OnCast;

    private void Click()
    {
        OnCast?.Invoke(this, SpellID);
    }
}
