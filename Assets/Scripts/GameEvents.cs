using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;
    public event Action onMoneyChanged;

    private void Awake()
    {
        instance = this;
    }

    public void MoneyChanged()
    {
        onMoneyChanged?.Invoke();
    }
}
