namespace Quickie003;

public struct ParticleData
{
    private static Texture2D _defaultTexture;
    public Texture2D texture = _defaultTexture ??= Globals.Content.Load<Texture2D>("particle");
    public float lifespan = 2f;
    public Color colorStart = Color.Yellow;
    public Color colorEnd = Color.Red;
    public float opacityStart = 1f;
    public float opacityEnd = 0f;
    public float sizeStart = 32f;
    public float sizeEnd = 4f;
    public float speed = 100f;
    public float angle = 0f;

    public ParticleData()
    {
    }
}
