public interface IReward
{
    public QuestReward Reward { get; }
    public void GiveQuestReward(int rewardValue);
}

