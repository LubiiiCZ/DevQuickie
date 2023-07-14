namespace Special002;

public class TrailPart : Sprite
{
    public float Lifespan { get; private set; }
    private readonly float _lifespanMax;

    public TrailPart(Texture2D texture, Vector2 position, float lifespan) : base(texture, position)
    {
        _lifespanMax = lifespan;
        Lifespan = lifespan;
    }

    public void Update()
    {
        Lifespan -= Globals.Time;
        color = Color.Yellow * (Lifespan / _lifespanMax);
    }
}
