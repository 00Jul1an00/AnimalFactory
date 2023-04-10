using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;
    public event Action OnMoneyChanged;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void MoneyChanged()
    {
        OnMoneyChanged?.Invoke();
    }
}
