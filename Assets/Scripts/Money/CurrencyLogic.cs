using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class CurrencyLogic : MonoBehaviour
{
    public abstract int CurrencyCount { get; set; }


    protected abstract void DrawMoney();

      
    


}
