namespace Project003;

public class Mine : TileObject
{
    public int Damage { get; set; }
    public float Range { get; set; }
    public bool OnlyGround { get; set; }
    public bool Used { get; set; }
    public DamageTypes DamageType { get; set; } = DamageTypes.Normal;

    public Mine(TileObjects objectType, Texture2D texture) : base(objectType, texture)
    {
        BlockingBuild = true;
    }

    public override void Draw()
    {
        if (Used) return;
        base.Draw();
    }
}
