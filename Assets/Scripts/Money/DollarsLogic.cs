using UnityEngine;

public class DollarsLogic : CurrencyLogic, IReward
{
    [SerializeField] private float _playerMoneyMultiplayer;

    public float PlayerMoneyMultiplayer 
    { 
        get 
        { 
            SaveLoadSystem.Instance.SavePlayerMoneyCurrentMultiplyer(_playerMoneyMultiplayer);
            return _playerMoneyMultiplayer; 
        } 
        private set 
        {
            _playerMoneyMultiplayer = value;
        } 
    }

    public override double CurrencyCount { get => base.CurrencyCount; set => base.CurrencyCount = value * PlayerMoneyMultiplayer; }

    public override QuestReward Reward => QuestReward.Dollars;

    public void GiveQuestReward(int rewardValue) => CurrencyCount += rewardValue;

    protected override void SaveCurrency() => SaveLoadSystem.Instance.SaveDollars(_currencyCount);

    private void Start()
    {
        _currencyCount = SaveLoadSystem.Instance.LoadDollars();
        _playerMoneyMultiplayer = SaveLoadSystem.Instance.LoadPlayerMoneyCurrentMultiplyer();

        if(_playerMoneyMultiplayer < 1)
            _playerMoneyMultiplayer = 1;

        DrawMoney();
    }
}
