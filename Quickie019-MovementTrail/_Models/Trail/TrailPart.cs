namespace Quickie019;

public class TrailPart : Sprite
{
    public float Lifespan { get; private set; }
    private readonly float _lifespanMax;

    public TrailPart(Texture2D texture, Vector2 position, float rotation, float lifespan) : base(texture, position)
    {
        _lifespanMax = lifespan;
        Lifespan = lifespan;
        this.rotation = rotation;
    }

    public void Update()
    {
        Lifespan -= Globals.Time;
        color = Color.White * (Lifespan / _lifespanMax);
    }
}
