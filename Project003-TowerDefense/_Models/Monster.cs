namespace Project003;

public class Monster : Sprite
{
    private readonly int _speed;
    private Vector2 _direction;
    public bool Dead { get; private set; }

    public Monster(Texture2D texture, Vector2 position) : base(texture, position)
    {
        Random r = new();
        _speed = r.Next(100, 151);
        _direction = new Vector2(0, 1);
    }

    public static event EventHandler OnDeath;

    public void Die()
    {
        OnDeath?.Invoke(this, EventArgs.Empty);
        Dead = true;
    }

    public void Update()
    {
        if (Dead) return;
        Position += _speed * _direction * Globals.Time;

        if (Position.Y > 768) Die();
    }
}
