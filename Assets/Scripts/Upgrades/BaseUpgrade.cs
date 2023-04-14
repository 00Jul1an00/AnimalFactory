using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class BaseUpgrade : MonoBehaviour
{

    [Min(1)] [SerializeField] protected int _upgradeCost;
    [Min(1)] [SerializeField] protected float _upgradeCostMiltiply;
    [SerializeField] private DollarsLogic _dollarsLogic;

    public event Action<BaseUpgrade> Upgraded;
    public float UpgradeCost { get { return _upgradeCost; } }
    public int UpgradesCount { get; private set; }

    protected abstract void UpgradeLogic();

    public virtual void Upgrade()
    {
        if (_dollarsLogic.CurrencyCount < _upgradeCost)
        {
            print("not enough money");
            return;
        }

        _dollarsLogic.CurrencyCount -= _upgradeCost;
        ChangeUpgradeCost();
        UpgradesCount++;
        UpgradeLogic();
        Upgraded?.Invoke(this);
    }

    protected virtual void ChangeUpgradeCost()
    {
        float upgradeCost = _upgradeCost;
        upgradeCost *= _upgradeCostMiltiply;
        _upgradeCost = Mathf.CeilToInt(upgradeCost);
    }
}
