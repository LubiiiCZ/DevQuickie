namespace Project003;

public class ProcessRewardsState : GameState
{
    public ProcessRewardsState(GameManager gm) : base(gm)
    {
    }

    public override void Update()
    {
        RewardItem reward;

        if (_gm.Rewards.Count > 0)
        {
            reward = _gm.Rewards.Dequeue();
        }
        else
        {
            StateManager.SwitchState(States.Idle);
            return;
        }

        _gm.CurrentReward = reward.RewardID;

        switch (reward.RewardID)
        {
            case Rewards.Wall:
            case Rewards.Tower:
                StateManager.SwitchState(States.Placement);
                break;

            default:
                break;
        }
    }

    public override void Draw()
    {
        _gm.map.Draw();
    }
}
