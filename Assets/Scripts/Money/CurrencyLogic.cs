using TMPro;
using UnityEngine;

public abstract class CurrencyLogic : MonoBehaviour
{
    [SerializeField] protected TMP_Text _curencyText;

    protected double _curencyCount;
    public double CurrencyCount 
    { 
        get 
        { 
            return _curencyCount; 
        } 
        set 
        { 
            if(_curencyCount >= 0)
            {
                _curencyCount = value;
                DrawMoney();
            } 
        } 
    }

    public abstract QuestReward Reward { get; }

    protected virtual void DrawMoney()
    {
        _curencyText.text = NumsFormatHelper.FormatNum(CurrencyCount);
    }
}
