using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DollarsLogic : CurrencyLogic
{
    [SerializeField] private TextMeshProUGUI _dollarText;

    private int _dollarsValue = 100;
    public override int CurrencyCount { get { return _dollarsValue; } set { if (_dollarsValue >= 0) _dollarsValue = value; } } 

    protected override void DrawMoney()
    {            
        _dollarText.text = _dollarsValue.ToString() + "$";
        print(CurrencyCount);
    }

    private void Start()
    {
        GameEvents.instance.onMoneyChanged += DrawMoney;
        DrawMoney();
    }

   
}
