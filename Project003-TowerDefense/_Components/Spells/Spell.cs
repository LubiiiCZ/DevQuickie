namespace Project003;

public class Spell : Sprite
{
    public Spells SpellID { get; }
    public SpellData Data { get; set; }
    public int Charges { get; set; } = 1;
    public int MaxCharges { get; set; } = 1;

    public Spell(Spells id, SpellData data) : base(data.Texture, Vector2.Zero)
    {
        SpellID = id;
        Data = data;
    }

    public void Update()
    {
        if (Charges < 1) return;
        if (InputManager.WasTapped(Rectangle) && !InputManager.IsDragging)
        {
            InputManager.IsDragging = true;
            InputManager.StartPosition = Position;
            InputManager.DraggedItem = this;
        }
        else if (InputManager.IsDragging && InputManager.DraggedItem == this)
        {
            var newPos = InputManager.DragPosition();
            if (newPos != Vector2.Zero)
            {
                Position = newPos;
            }
            else
            {
                InputManager.IsDragging = false;
                Cast();
            }
        }
    }

    public event EventHandler<Spell> OnCast;

    private void Cast()
    {
        OnCast?.Invoke(this, this);
    }
}
