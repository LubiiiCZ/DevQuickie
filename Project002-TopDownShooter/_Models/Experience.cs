namespace Project002;

public class Experience(Texture2D tex, Vector2 pos) : Sprite(tex, pos)
{
    public float Lifespan { get; private set; } = LIFE;
    private const float LIFE = 5f;

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
