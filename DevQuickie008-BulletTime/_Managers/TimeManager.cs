namespace Quickie008;

public static class TimeManager
{
    private const float MIN_TIME_DILATION = 0.05f;
    private const float MAX_TIME_DILATION = 1.00f;
    private const float TIME_DILATION_SPEED = 1.00f;
    private const float TIME_DILATION_PER_SECOND = (MAX_TIME_DILATION - MIN_TIME_DILATION) / TIME_DILATION_SPEED;
    private static float TimeDilation { get; set; } = 1.00f;
    public static float Time { get; private set; }
    public static float BulletTime { get; private set; }

    public static void Update(GameTime gt)
    {
        Time = (float)gt.ElapsedGameTime.TotalSeconds;

        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            TimeDilation -= TIME_DILATION_PER_SECOND * Time;
        }
        else
        {
            TimeDilation += TIME_DILATION_PER_SECOND * Time;
        }

        TimeDilation = Math.Clamp(TimeDilation, MIN_TIME_DILATION, MAX_TIME_DILATION);
        BulletTime = Time * TimeDilation;
    }
}
