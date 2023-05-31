using TMPro;
using UnityEngine;

public abstract class CurrencyLogic : MonoBehaviour
{
    [SerializeField] protected TMP_Text _curencyText;

    protected double _currencyCount;
    public virtual double CurrencyCount 
    { 
        get 
        { 
            return _currencyCount; 
        } 
        set 
        { 
            if(_currencyCount >= 0)
            {
                _currencyCount = value;               
                DrawMoney();
                SaveCurrency();
            } 
        } 
    }

    public abstract QuestReward Reward { get; }

    protected virtual void DrawMoney()
    {
        _curencyText.text = NumsFormatHelper.FormatNum(CurrencyCount);
    }

    protected abstract void SaveCurrency();
}
