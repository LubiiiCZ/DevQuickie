namespace Project003;

public class Spell : Sprite
{
    public Spells SpellID { get; }
    public bool Used { get; set; }

    public Spell(Spells id, Texture2D texture) : base(texture, Vector2.Zero)
    {
        SpellID = id;
    }

    public void Update()
    {
        if (Used) return;
        if (InputManager.WasTapped(Rectangle))
        {
            Click();
        }
    }

    public event EventHandler<Spell> OnCast;

    private void Click()
    {
        OnCast?.Invoke(this, this);
    }
}
