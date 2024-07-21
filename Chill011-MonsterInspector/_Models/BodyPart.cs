namespace Chill011;

public class BodyPart : Sprite
{
    public int partId;

    public BodyPart(Texture2D texture) : base(texture)
    {
        Origin =  new(texture.Width / 2, 0);
    }
}
