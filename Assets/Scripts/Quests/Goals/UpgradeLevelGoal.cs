using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeLevelGoal : QuestGoal
{
    [SerializeField] private BaseUpgrade _upgradeToCheck;
    [SerializeField] private bool _checkingTotalUpgradeLevel;

    public override int CurrentProgres
    {
        get
        {
            if(_checkingTotalUpgradeLevel)
            {
                int upgradeLvl = 0;

                foreach(var upgrade in QuestSystem.Instance.UpgradesToCheck)
                {
                    upgradeLvl += upgrade.UpgradesCount;
                }
                
                return upgradeLvl;
            }
            else
            {
                return _upgradeToCheck.UpgradesCount;
            }
        }
    }
}
