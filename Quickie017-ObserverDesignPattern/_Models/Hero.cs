namespace Quickie017;

public class Hero(Texture2D tex, Vector2 pos) : Sprite(tex, pos)
{
    protected float speed = 400;
    private int _gems;
    public int Gems
    {
        get => _gems;
        private set
        {
            _gems = value;
            OnCollect?.Invoke(_gems);
        }
    }

    public delegate void ObserveGems(int gemCount);
    public event ObserveGems OnCollect;

    public void CollectGem()
    {
        Gems++;
    }

    public void Update()
    {
        Position += InputManager.Direction * Globals.Time * speed;
    }
}
