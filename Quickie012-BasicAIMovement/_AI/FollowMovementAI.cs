namespace Quickie012;

public class FollowMovementAI : MovementAI
{
    public Player Target { get; set; }

    public override void Move(Sprite bot)
    {
        if (Target is null) return;

        var dir = Target.Position - bot.Position;

        if (dir.Length() > 4)
        {
            dir.Normalize();
            bot.Position += dir * bot.Speed * Globals.TotalSeconds;
        }
    }
}
