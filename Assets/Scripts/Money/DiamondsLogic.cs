public class DiamondsLogic : CurrencyLogic, IReward
{
    public override QuestReward Reward => QuestReward.Diamonds;

    public void GiveQuestReward(int rewardValue) => _currencyCount += rewardValue;

    protected override void SaveCurrency() => SaveLoadSystem.Instance.SaveDiamonds(_currencyCount);

    private void Start()
    {
        _currencyCount = SaveLoadSystem.Instance.LoadDiamonds();
        DrawMoney();
    }
}