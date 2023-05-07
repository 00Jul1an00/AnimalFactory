using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class CaseLogic : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private CaseSO _caseSO;
    [SerializeField] AddDropChanceLogic _addDropChanceLogic;
    [SerializeField] private Button _caseMenuOpenButton;

    private List<InventoryItem> _itemsToDelete = new();

    public static event Action<CaseLogic> CaseMenuOpened;

    private void OnEnable()
    {
        _caseMenuOpenButton.onClick.AddListener(OnCaseMenuOpenButtonClick);
    }

    private void OnDisable()
    {
        _caseMenuOpenButton.onClick.RemoveListener(OnCaseMenuOpenButtonClick);
    }

    public void OpenCase()
    {
        GiveRandReward();
        _itemsToDelete = _addDropChanceLogic.GetSelectedItemsListCopy();

        foreach (var item in _itemsToDelete)
            _inventory.RemoveItemFromInventory(item);

        _itemsToDelete.Clear();
        _addDropChanceLogic.ResetChanceImprove();
    }

    private void GiveRandReward()
    {
        AnimalQuality rewardQuality = CalcRewardQuality(UnityEngine.Random.Range(0, 100) + _addDropChanceLogic.ChanceImprove);
        AnimalSO reward = AnimalsData.Instance.GetRandAnimalByQuality(rewardQuality);
        print(rewardQuality);
        _inventory.AddAnimalToInventory(reward);
    }

    private AnimalQuality CalcRewardQuality(int value)
    {
        print(value);

        if (value <= _caseSO.CommonDropChance)
        {
            return AnimalQuality.Common;
        }
        else if (value - _caseSO.CommonDropChance <= _caseSO.RareDropChance)
        {
            return AnimalQuality.Rare;
        }
        else if (value - _caseSO.CommonDropChance - _caseSO.RareDropChance <= _caseSO.MythicalDropChance)
        {
            return AnimalQuality.Mythical;
        }
        else
        {
            return AnimalQuality.Legendary;
        }
    }

    private void OnCaseMenuOpenButtonClick()
    {
        CaseMenuOpened?.Invoke(this);
    }
}
