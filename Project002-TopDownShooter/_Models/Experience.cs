namespace Project002;

public class Experience : Sprite
{
    public float Lifespan { get; private set; }
    private const float LIFE = 5f;

    public Experience(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
        Lifespan = LIFE;
    }

    public void Update()
    {
        Lifespan -= Globals.TotalSeconds;
        Scale = 0.33f + (Lifespan / LIFE * 0.66f);
    }

    public void Collect()
    {
        Lifespan = 0;
    }
}
