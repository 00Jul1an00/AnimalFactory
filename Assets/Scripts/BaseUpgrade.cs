using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class BaseUpgrade : MonoBehaviour
{
    [SerializeField] private int _upgradeCost;
    [SerializeField] private DollarsLogic _dollarsLogic;

    public event Action<BaseUpgrade> Upgraded;
    public int UpgradeCost { get; protected set; }
    
    protected abstract void UpgradeLogic();

    public virtual void Upgrade()
    {
        if (_dollarsLogic.CurrencyCount < _upgradeCost)
        {
            print("not enough money");
            return;
        }
        _dollarsLogic.CurrencyCount -= _upgradeCost;
        GameEvents.instance.MoneyChanged();
        UpgradeLogic();
        Upgraded?.Invoke(this);
    }

    //private void Start() => _dollarsLogic = FindObjectOfType<DollarsLogic>();
}
