using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiamondsLogic : CurrencyLogic, IReward
{
    [SerializeField] private TextMeshProUGUI _diamondText;

    private int _diamondValue = 10;
    public override int CurrencyCount { get { return _diamondValue; } 
        set 
        { 
            if (_diamondValue >= 0)
            {
                _diamondValue = value; 
                GameEvents.Instance.MoneyChanged(); 
            }
        }
    }

    public QuestReward Reward { get { return QuestReward.Diamonds; } }

    public void GiveReward(int rewardValue)
    {
        CurrencyCount += rewardValue;
    }

    protected override void DrawMoney() => _diamondText.text = _diamondValue.ToString();

    //private void OnEnable() => GameEvents.Instance.OnMoneyChanged += DrawMoney;
    private void OnDisable() => GameEvents.Instance.OnMoneyChanged -= DrawMoney;
    private void Start()
    {
        GameEvents.Instance.OnMoneyChanged += DrawMoney;
        DrawMoney();
    }
}
