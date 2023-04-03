using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DollarsLogic : CurrencyLogic
{
    [SerializeField] private TextMeshProUGUI _dollarText;
    public override int CurrencyCount => 100;

    protected override void DrawMoney()
    {
        _dollarText.text = _dollarText.ToString();
    }

    
}
