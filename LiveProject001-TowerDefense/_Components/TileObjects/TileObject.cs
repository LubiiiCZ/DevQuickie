namespace LiveProject001;

public class TileObject : Sprite
{
    public TileObjects ObjectID { get; set; }
    public Tile Owner { get; set; }
    public bool BlockingPath { get; set; }
    public bool BlockingBuild { get; set; }
    public bool Dead { get; set; }

    public TileObject(TileObjects objectID, Texture2D texture) : base(texture, Vector2.Zero)
    {
        ObjectID = objectID;
    }

    public virtual void Update()
    {
    }
}
