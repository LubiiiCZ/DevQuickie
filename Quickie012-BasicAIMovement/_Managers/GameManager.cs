namespace Quickie012;

public class GameManager
{
    private readonly Player _player;
    private readonly List<Bot> _bots = [];

    public GameManager()
    {
        _player = new(Globals.Content.Load<Texture2D>("orb-red"), new(600, 600));
        var botTexture = Globals.Content.Load<Texture2D>("orb-blue");

        var ai = new PatrolMovementAI();
        ai.AddWaypoint(new(100, 100));
        ai.AddWaypoint(new(400, 100));
        ai.AddWaypoint(new(400, 400));
        ai.AddWaypoint(new(100, 400));

        _bots.Add(new(botTexture, new(50, 50))
        {
            MoveAI = ai
        });

        _bots.Add(new(botTexture, new(50, 350))
        {
            MoveAI = new FollowMovementAI
            {
                Target = _player
            }
        });

        _bots.Add(new(botTexture, new(150, 350))
        {
            MoveAI = new DistanceMovementAI
            {
                Target = _player,
                Distance = 250
            }
        });

        _bots.Add(new(botTexture, new(350, 350))
        {
            MoveAI = new GuardMovementAI
            {
                Target = _player,
                Guard = new(350, 350),
                Distance = 250
            }
        });
    }

    public void Update()
    {
        InputManager.Update();
        _player.Update();
        foreach (var bot in _bots)
        {
            bot.Update();
        }
    }

    public void Draw()
    {
        _player.Draw();
        foreach (var bot in _bots)
        {
            bot.Draw();
        }
    }
}
