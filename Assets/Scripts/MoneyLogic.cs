using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyLogic : MonoBehaviour
{
    [SerializeField] private GameObject _sellBox;
    [SerializeField] private TextMeshProUGUI _moneyText;

    public int Money; 

    private SellBoxTrigger _sellBoxTrigger;

    private void Start()
    {
        _sellBoxTrigger = _sellBox.GetComponent<SellBoxTrigger>();
    }

    public void DrawMoney()
    {
        _moneyText.text = Money.ToString();
    }


}
