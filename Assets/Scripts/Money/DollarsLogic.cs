public class DollarsLogic : CurrencyLogic, IReward
{
    public override QuestReward Reward => QuestReward.Dollars;

    public void GiveQuestReward(int rewardValue) => CurrencyCount += rewardValue;

    protected override void SaveCurrency() => SaveLoadSystem.Instance.SaveDollars(_currencyCount);

    private void Start()
    {
        _currencyCount = SaveLoadSystem.Instance.LoadDollars();
        DrawMoney();
    }
}
