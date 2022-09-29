namespace Quickie012;

public class DistanceMovementAI : MovementAI
{
    public Player Target { get; set; }
    public float Distance { get; set; }

    public override void Move(Sprite bot)
    {
        if (Target is null) return;

        var dir = Target.Position - bot.Position;
        var length = dir.Length();

        if (length > Distance + 2)
        {
            dir.Normalize();
            bot.Position += dir * bot.Speed * Globals.TotalSeconds;
        }
        else if (length < Distance - 2)
        {
            dir.Normalize();
            bot.Position -= dir * bot.Speed * Globals.TotalSeconds;
        }
    }
}
