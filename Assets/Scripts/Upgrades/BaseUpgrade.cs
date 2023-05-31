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

    protected UpgradeStats _upgradeStats;

    protected void Init()
    {
        _upgradeStats = SaveLoadSystem.Instance.LoadUpgradeStats(this);

        if(_upgradeStats.CurrentUpgradeCost != 0)
        {
            _upgradeCost = _upgradeStats.CurrentUpgradeCost;
            _upgradeCostMiltiply = _upgradeStats.UpgradeCostMyltiply;
            UpgradesCount = _upgradeStats.UpgradesCount;
        }
        
        for (int i = 0; i < UpgradesCount; i++)
        {
            UpgradeLogic();
            ChangeUpgradeCost();
        }
    }
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
        _upgradeStats.UpgradesCount = UpgradesCount;
        SaveLoadSystem.Instance.SaveUpgradeStats(this, _upgradeStats);
        Upgraded?.Invoke(this);
    }

    protected abstract void UpgradeLogic();

    protected virtual void ChangeUpgradeCost()
    {
        float upgradeCost = _upgradeCost;
        upgradeCost *= _upgradeCostMiltiply;
        _upgradeCost = Mathf.CeilToInt(upgradeCost);
        _upgradeStats.CurrentUpgradeCost = _upgradeCost;
        _upgradeStats.UpgradeCostMyltiply = _upgradeCostMiltiply;
    }
}
