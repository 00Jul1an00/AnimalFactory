using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DollarsLogic : CurrencyLogic
{
    [SerializeField] private TextMeshProUGUI _dollarText;

    private int _dollarsValue = 100;
    public override int CurrencyCount { get { return _dollarsValue; } set { _dollarsValue += value; } }

    protected override void DrawMoney()
    {            
        _dollarText.text = _dollarsValue.ToString() + "$";                 
    }

    private void Update()
    {
        DrawMoney();
    }

}
