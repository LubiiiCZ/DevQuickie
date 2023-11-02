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
            { Rewards.TowerAir, () => StateManager.SwitchState(States.Placement) },
            { Rewards.TowerIce, () => StateManager.SwitchState(States.Placement) },
            { Rewards.Mine, () => StateManager.SwitchState(States.Placement) },
            { Rewards.MonsterNinja, () => _gm.monstersInWave.Add(Monsters.Ninja) },
            { Rewards.MonsterRedNinja, () => _gm.monstersInWave.Add(Monsters.RedNinja) },
            { Rewards.MonsterFlyingNinja, () => _gm.monstersInWave.Add(Monsters.FlyingNinja) },
            { Rewards.Fireball, () => _gm.spellManager.AddSpell(Spells.Fireball) },
            { Rewards.Freeze, () => _gm.spellManager.AddSpell(Spells.Freeze) },
        };
    }

    public override void Update()
    {
        if (_gm.Rewards.Count > 0)
        {
            _gm.CurrentReward = _gm.Rewards.Dequeue().RewardID;
            _rewardActions[_gm.CurrentReward]();
        }
        else
        {
            _gm.RewardsLeft--;

            if (_gm.RewardsLeft > 0)
            {
                StateManager.SwitchState(States.Reward);
                _gm.rewardManager.GenerateRandomRewardOptions(4);
            }
            else
            {
                StateManager.SwitchState(States.Idle);
            }
        }
    }

    public override void Draw()
    {
        _gm.map.Draw();
        _gm.uiManager.DrawMonsterCounter(_gm.monstersInWave.Count);
        _gm.uiManager.DrawLiveCounter(_gm.PlayerLives);
    }
}
