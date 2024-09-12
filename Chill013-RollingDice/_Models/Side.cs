namespace Chill013;

public class Side(Texture2D texture, int value, Action action)
{
    public Texture2D Texture { get; set; } = texture;
    public int Value { get; set; } = value;
    public Vector2 Origin { get; set; } = new(texture.Width / 2, texture.Height / 2);
    public Action Action { get; set; } = action;
}
