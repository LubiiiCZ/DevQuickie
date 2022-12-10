namespace Project002;

public class MovingSprite : Sprite
{
    public int Speed { get; set; }

    public MovingSprite(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
        Speed = 300;
    }
}
