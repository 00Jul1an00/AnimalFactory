public interface IReward
{
    public QuestReward Reward { get; }
    public void GiveReward(int rewardValue);
}

