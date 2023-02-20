using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class BaseUpgrade : MonoBehaviour
{
    [SerializeField] private int _upgradeCost;
    [SerializeField] private MoneyLogic _moneyLogic;

    public event Action<BaseUpgrade> Upgraded;
    public int UpgradeCost { get; protected set; }
    
    protected abstract void UpgradeLogic();

    public virtual void Upgrade()
    {
        if (_moneyLogic.Money <= _upgradeCost)
        {
            print("not enouth money");
            return;
        }

        UpgradeLogic();
        Upgraded?.Invoke(this);
    }



}
