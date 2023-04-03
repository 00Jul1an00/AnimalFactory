using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiamondsLogic : CurrencyLogic
{
    [SerializeField] private TextMeshProUGUI _diamondText;

    public override int CurrencyCount => 10;

    protected override void DrawMoney()
    {
        _diamondText.text = _diamondText.ToString();
    }
}
