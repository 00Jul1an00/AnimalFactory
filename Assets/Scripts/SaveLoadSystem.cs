using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgressData
{
    public float PlayerMoneyCurrentMultiplyer;
    public double DollarsCount;
    public double DiamonsCount;
    public int CurrentQuestID;
    public int ClicksCount;
    public Dictionary<QuestGoal, double> QuestsProgress;
    public List<InventoryItem> PlayerInventory;
    public Dictionary<CaseLogic, int> KeysForCasesCount;
    public Dictionary<BaseUpgrade, UpgradeStats> UpgradesStats;
    public Dictionary<Iteration, AnimalLogic> IterationsAnimals;
}

public struct UpgradeStats
{
    public int CurrentUpgradeCost;
    public float UpgradeCostMyltiply;
    public float SpecificMyltiply;
}

public class SaveLoadSystem : MonoBehaviour
{
    public static SaveLoadSystem Instance { get; private set; }
    [SerializeField] private ProgressData _progressData;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        # region until json connect
        _progressData = new();
        _progressData.QuestsProgress = new();
        _progressData.PlayerInventory = new();
        _progressData.IterationsAnimals = new();
        _progressData.KeysForCasesCount = new();
        _progressData.UpgradesStats = new();
        #endregion
    }

    public void SavePlayerMoneyCurrentMultiplyer(float multiply)
    {
        _progressData.PlayerMoneyCurrentMultiplyer = multiply;
    }

    public float LoadPlayerMoneyCurrentMultiplyer()
    {
        return _progressData.PlayerMoneyCurrentMultiplyer;
    }

    public void SaveDollars(double dollars)
    {
        _progressData.DollarsCount = dollars;
    }

    public double LoadDollars()
    {
        return _progressData.DollarsCount;
    }

    public void SaveDiamonds(double diamonds)
    {
        _progressData.DollarsCount = diamonds;
    }
    
    public double LoadDiamonds()
    {
        return _progressData.DollarsCount;
    }

    public void SaveCurrentQuestID(int questId)
    {
        _progressData.CurrentQuestID = questId;
    }

    public int LoadCurrentQuestID()
    {
        return _progressData.CurrentQuestID;
    }

    public void SaveClicksCount(int clicksCount)
    {
        _progressData.ClicksCount = clicksCount;
    }

    public int LoadClicksCount()
    {
        return _progressData.ClicksCount;
    }

    public void SaveQuestProgress(QuestGoal quest)
    {
        if(quest.IsDone)
        {
            _progressData.QuestsProgress.Remove(quest);
            return;
        }
        else if(!_progressData.QuestsProgress.TryAdd(quest, quest.CurrentProgres))
        {
            _progressData.QuestsProgress[quest] = quest.CurrentProgres;
        }
    }

    public double LoadQuestProgress(QuestGoal quest)
    {
        if (!_progressData.QuestsProgress.ContainsKey(quest))
            return 0;
        
        return _progressData.QuestsProgress[quest];
    }

    public void SavePlayerInventory(List<InventoryItem> items)
    {
        _progressData.PlayerInventory = items;
    }

    public List<InventoryItem> LoadPlayerInventory()
    {
        return _progressData.PlayerInventory;
    }

    public void SaveKeysCountForCase(CaseLogic caseLogic, int keys)
    {
        if (!_progressData.KeysForCasesCount.TryAdd(caseLogic, keys))
        {
            _progressData.KeysForCasesCount[caseLogic] = keys;
        } 
    }

    public int LoadKeysCountForCase(CaseLogic caseLogic)
    {
        if (!_progressData.KeysForCasesCount.ContainsKey(caseLogic))
            return 0;
        
        return _progressData.KeysForCasesCount[caseLogic];
    }

    public void SaveUpgradeStats(BaseUpgrade upgrade, UpgradeStats upgradeStats)
    {
        if (!_progressData.UpgradesStats.TryAdd(upgrade, upgradeStats))
        {
            _progressData.UpgradesStats[upgrade] = upgradeStats;
        }
    }

    public UpgradeStats LoadUpgradeStats(BaseUpgrade upgrade)
    {
        if(!_progressData.UpgradesStats.ContainsKey(upgrade))
            return new UpgradeStats();

        return _progressData.UpgradesStats[upgrade];
    }

    public void SaveIterationCurrentAnimal(Iteration iteration)
    {
        if (!_progressData.IterationsAnimals.TryAdd(iteration, iteration.CurrentAnimal))
        {
            _progressData.IterationsAnimals[iteration] = iteration.CurrentAnimal;
        }
    }

    public AnimalLogic LoadIterationCurrentAnimal(Iteration iteration)
    {
        if (!_progressData.IterationsAnimals.ContainsKey(iteration))
            return new AnimalLogic(AnimalsData.Instance.GetAnimalByID(-1));

        return _progressData.IterationsAnimals[iteration];
    }
}
