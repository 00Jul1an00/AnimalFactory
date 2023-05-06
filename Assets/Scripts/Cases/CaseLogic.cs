using UnityEngine;
using System.Collections.Generic;

public class CaseLogic : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private CaseSO _caseSO;

    private List<InventoryItem> _itemsToDelete = new();
    private int _chanceImprove;

    private void OpenCase()
    {
        GiveRandReward();
    }

    private void GiveRandReward()
    {
        AnimalQuality rewardQuality = CalcRewardQuality(Random.Range(0, 100) + _chanceImprove);
        _chanceImprove = 0;
        AnimalSO reward = AnimalsData.Instance.GetRandAnimalByQuality(rewardQuality);
        print(rewardQuality);
        //_inventory.AddAnimalToInventory(reward);
    }

    private void ImproveDropChance(InventoryItem item)
    {
        _chanceImprove += item.Animal.BaseAnimal.BaseQuality.Rarity;
        _itemsToDelete.Add(item);
    }

    private AnimalQuality CalcRewardQuality(int value)
    {
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

    //debug
    private bool _isClisked;
    private void Update()
    {
        if (Input.GetKey(KeyCode.P) && !_isClisked)
        {
            _isClisked = true;

            for (int i = 0; i < 100; i++)
                OpenCase();
        }
    }
}
