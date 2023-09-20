namespace Project003;

public class Monster : Sprite
{
    public MonsterData Data;
    public List<Vector2> Path { get; private set; }
    private int _current;
    public Vector2 DestinationPosition { get; protected set; }
    public bool Dead { get; private set; }
    private float _hitDurationLeft;

    public Monster(MonsterData data, Vector2 position) : base(data.Texture, position)
    {
        Data = data;
    }

    public void TakeDamage(int dmg)
    {
        _hitDurationLeft = 0.1f;
        Data.Health -= dmg;
        if (Data.Health <= 0) Die();
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
    public static event EventHandler OnGoalReached;

    public void Die()
    {
        OnDeath?.Invoke(this, EventArgs.Empty);
        Dead = true;
    }

    public void ReachGoal()
    {
        OnGoalReached?.Invoke(this, EventArgs.Empty);
        Dead = true;
    }

    public void CheckGoalReached()
    {
        if (Position.Y > (Map.SIZE_Y - 1) * Map.TILE_SIZE) ReachGoal();
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
        Position += direction * Globals.Time * Data.Speed;

        CheckGoalReached();

        if (NearDestination()) return;
    }
}
