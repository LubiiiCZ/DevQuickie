namespace Project003;

public class Monster : Sprite
{
    private readonly int _speed;
    public List<Vector2> Path { get; private set; }
    private int _current;
    public Vector2 DestinationPosition { get; protected set; }
    public int Health { get; private set; } = 3;
    public int MaxHealth { get; private set; } = 3;
    public bool Dead { get; private set; }
    private float _hitDurationLeft;

    public Monster(Texture2D texture, Vector2 position) : base(texture, position)
    {
        Random r = new();
        _speed = 150;
    }

    public void TakeDamage(int dmg)
    {
        _hitDurationLeft = 0.1f;
        Health -= dmg;
        if (Health <= 0) Die();
    }

    public void SetPath(List<Vector2> path)
    {
        if (path is null) return;
        if (path.Count < 1) return;

        Path = path;
        _current = 0;
        DestinationPosition = Path[_current];
    }

    private bool NearDestination()
    {
        if ((DestinationPosition - Position).Length() < 5)
        {
            Position = DestinationPosition;

            if (_current < Path.Count - 1)
            {
                _current++;
                DestinationPosition = Path[_current];
            }
            return true;
        }
        return false;
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

        Color = (_hitDurationLeft > 0) ? Color.Red : Color.White;

        if (_hitDurationLeft > 0)
        {
            _hitDurationLeft -= Globals.Time;
        }

        var direction = DestinationPosition - Position;
        if (direction != Vector2.Zero) direction.Normalize();
        Position += direction * Globals.Time * _speed;
        if (Position.Y > (Map.SIZE_Y - 1) * Map.TILE_SIZE) Die();

        if (NearDestination()) return;
    }
}
