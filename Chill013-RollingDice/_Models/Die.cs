namespace Chill013;

public class Die(Vector2 position)
{
    public readonly List<Side> Sides = [];
    public int ActiveSide { get; set; }
    public Vector2 Position { get; set; } = position;
    public float Rotation { get; set; }
    public float RotationTimeLeft { get; set; }
    public bool Rolling { get; set; }
    private readonly Random _r = new();
    public int Value => Sides[ActiveSide].Value;

    public void AddSide(Side side)
    {
        Sides.Add(side);
    }

    public void Roll()
    {
        Rolling = true;
        RotationTimeLeft = 1f + (float)_r.NextDouble();
    }

    public void Update()
    {
        if (!Rolling) return;

        if (RotationTimeLeft > 0f)
        {
            RotationTimeLeft -= Globals.Time;
            Rotation += Globals.Time * 10f;
        }
        else
        {
            Rolling = false;
            Rotation = 0f;
            ActiveSide = _r.Next(0, Sides.Count);
            Sides[ActiveSide].Action.Invoke();
        }
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(Sides[ActiveSide].Texture, Position, null, Color.White, Rotation, Sides[ActiveSide].Origin, 1f, SpriteEffects.None, 1f);
    }
}
