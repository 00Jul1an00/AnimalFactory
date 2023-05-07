using System;
using System.Collections.Generic;
using UnityEngine;

public class AddDropChanceLogic : MonoBehaviour
{
    private List<InventoryItem> _selectedItems = new();
    public int ChanceImprove { get; private set; }

    public event Action ChanceImproveReseted;

    public void IncreaseDropChance(InventoryItem item)
    {
        ChanceImprove += item.Animal.BaseAnimal.BaseQuality.Rarity;
        _selectedItems.Add(item);
    }

    public void DecreaseDropChance(InventoryItem item)
    {
        ChanceImprove -= item.Animal.BaseAnimal.BaseQuality.Rarity;
        _selectedItems.Remove(item);
    }

    public List<InventoryItem> GetSelectedItemsListCopy()
    {
        var list = new List<InventoryItem>();
        list = _selectedItems;
        return list;
    }

    public void ResetChanceImprove()
    {
        ChanceImprove = 0;
        _selectedItems.Clear();
        ChanceImproveReseted?.Invoke();
    }
}
