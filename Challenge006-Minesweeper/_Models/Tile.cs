namespace Challenge006;

public class Tile(Texture2D texture, SpriteFont font, int x, int y)
{
    private const int SIZE = 32;
    private const int PADDING = 2;
    private readonly Texture2D _texture = texture;
    private readonly SpriteFont _font = font;
    public Color FontColor = Color.Black;
    private readonly Vector2 _pos = new(x * (SIZE + PADDING) + PADDING + 10, y * (SIZE + PADDING) + PADDING);
    public readonly Point C = new(x, y);
    public readonly Rectangle R = new(x * (SIZE + PADDING) + PADDING, y * (SIZE + PADDING) + PADDING, SIZE, SIZE);
    public bool Revealed { get; set; }
    public bool Mine { get; set; }
    public bool Marked { get; set; }
    public int MinesAround { get; set; }

    public void IncreaseMinesAround()
    {
        MinesAround++;

        FontColor = MinesAround switch
        {
            1 => Color.Blue,
            2 => Color.LimeGreen,
            3 => Color.OrangeRed,
            4 => Color.Purple,
            5 => Color.Red,
            6 => Color.DarkRed,
            7 => Color.Orange,
            8 => Color.Brown,
            _ => Color.Black,
        };
    }

    public static event EventHandler<Tile> OnReveal;
    public static event EventHandler<Tile> OnDoubleReveal;

    public void Reveal()
    {
        if (Revealed) return;

        Revealed = true;
        OnReveal?.Invoke(this, this);
    }

    public void Update()
    {
        if (InputManager.Clicked)
        {
            if (R.Contains(InputManager.MousePosition))
            {
                if (Revealed)
                {
                    OnDoubleReveal?.Invoke(this, this);
                }
                else
                {
                    Reveal();
                }
            }
        }

        if (InputManager.RightClicked)
        {
            if (R.Contains(InputManager.MousePosition))
            {
                Marked = !Marked;
            }
        }
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, R,
            Revealed ? Color.White : Marked ? Color.Red : Color.Gray);

        if (!Revealed) return;
        if (Mine || MinesAround < 1) return;
        Globals.SpriteBatch.DrawString(_font, MinesAround.ToString(), _pos, FontColor);
    }
}
