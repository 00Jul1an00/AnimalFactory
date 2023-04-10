using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DollarsLogic : CurrencyLogic, IReward
{
    [SerializeField] private TextMeshProUGUI _dollarText;

    private int _dollarsValue = 100;
    public override int CurrencyCount { get { return _dollarsValue; } 
        set 
        { 
            if (_dollarsValue >= 0)
            {
                _dollarsValue = value;
                GameEvents.Instance.MoneyChanged();
            }
        } 
    }

    public QuestReward Reward { get { return QuestReward.Dollars; } }

    public void GiveReward(int rewardValue)
    {
        CurrencyCount += rewardValue;
    }

    protected override void DrawMoney() => _dollarText.text = _dollarsValue.ToString() + "$";

    private void OnEnable() => GameEvents.Instance.OnMoneyChanged += DrawMoney;
    private void OnDisable() => GameEvents.Instance.OnMoneyChanged -= DrawMoney;

    private void Start() => DrawMoney();
}
