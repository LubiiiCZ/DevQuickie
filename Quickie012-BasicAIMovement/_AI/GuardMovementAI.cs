namespace Quickie012;

public class GuardMovementAI : MovementAI
{
    public Player Target { get; set; }
    public Vector2 Guard { get; set; }
    public float Distance { get; set; }

    public override void Move(Sprite bot)
    {
        if (Target is null) return;

        var toTarget = (Guard - Target.Position).Length();
        Vector2 dir;

        if (toTarget < Distance)
        {
            dir = Target.Position - bot.Position;
        }
        else
        {
            dir = Guard - bot.Position;
        }

        if (dir.Length() > 4)
        {
            dir.Normalize();
            bot.Position += dir * bot.Speed * Globals.TotalSeconds;
        }
    }
}
