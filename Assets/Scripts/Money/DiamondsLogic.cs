using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiamondsLogic : CurrencyLogic
{
    [SerializeField] private TextMeshProUGUI _diamondText;

    private int _diamondValue = 10;
    public override int CurrencyCount { get { return _diamondValue; } set { if (_diamondValue >- 0) _diamondValue = value; } }
    
    protected override void DrawMoney()
    {                        
        _diamondText.text = _diamondValue.ToString();
        
    }

    private void Start()
    {
        GameEvents.instance.onMoneyChanged += DrawMoney;
        DrawMoney();
    }
}
