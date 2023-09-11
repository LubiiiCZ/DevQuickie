namespace Project003;

public class ProcessRewardsState : GameState
{
    private readonly Dictionary<Rewards, Action> _rewardActions;

    public ProcessRewardsState(GameManager gm) : base(gm)
    {
        _rewardActions = new()
        {
            { Rewards.Wall, () => StateManager.SwitchState(States.Placement) },
            { Rewards.Tower, () => StateManager.SwitchState(States.Placement) },
            { Rewards.MonsterNinja, () => _gm.monstersInWave.Add(Monsters.Ninja) },
            { Rewards.MonsterRedNinja, () => _gm.monstersInWave.Add(Monsters.RedNinja) }
        };
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
        _rewardActions[reward.RewardID]();
    }

    public override void Draw()
    {
        _gm.map.Draw();
        _gm.uiManager.DrawMonsterCounter(_gm.monstersInWave.Count);
    }
}
