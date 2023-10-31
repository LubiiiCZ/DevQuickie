namespace Project003;

public class Spell : Sprite
{
    public Spells SpellID { get; }
    public bool Used { get; set; }
    public int Range { get; set; }

    public Spell(Spells id, int range, Texture2D texture) : base(texture, Vector2.Zero)
    {
        SpellID = id;
        Range = range;
    }

    public void Update()
    {
        if (Used) return;
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
