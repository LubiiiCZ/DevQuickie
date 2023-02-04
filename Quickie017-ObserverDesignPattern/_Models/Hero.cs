namespace Quickie017;

public class Hero : Sprite
{
    protected float speed;
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

    public Hero(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
        speed = 400;
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
