using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private ItemsInInventoryObjectPool _inventoryObjectPool;
    [SerializeField] private List<Iteration> _iterations;

    private List<InventoryItem> _inventory = new();

    private void Start()
    {
        AddAnimalToInventory(AnimalsData.Instance.GetAnimalByID(0));
        AddAnimalToInventory(AnimalsData.Instance.GetAnimalByID(1));
        AddAnimalToInventory(AnimalsData.Instance.GetAnimalByID(2));
        AddAnimalToInventory(AnimalsData.Instance.GetAnimalByID(3));
        AddAnimalToInventory(AnimalsData.Instance.GetAnimalByID(0));
        AddAnimalToInventory(AnimalsData.Instance.GetAnimalByID(4));
    }

    public void AddAnimalToInventory(AnimalSO animal)
    {
        var animalLogic = new AnimalLogic(animal);
        var item = ActivateItem(animalLogic);
        _inventory.Add(item);
    }

    public void RemoveItemFromInventory(InventoryItem item)
    {
        SetDefaultAnimalForIteration(item);
        _inventoryObjectPool.DeactivateItemInObjectPool(item);
        _inventory.Remove(item);
    }

    private InventoryItem ActivateItem(AnimalLogic animalLogic)
    {
        return _inventoryObjectPool.ActivateItemInObjectPool(animalLogic);
    }

    public void DrawItemsInMergeMenu(InventoryItem selectedItem)
    {
        foreach (var item in _inventory)
        {
            item.ReDrawStats();

            if (item == selectedItem)
                _inventoryObjectPool.DeactivateItemInObjectPool(item);

        }
    }

    public void OnMergeMenuClose(InventoryItem selectedItem)
    {
        foreach (var item in _inventory)
        {
            item.ReDrawStats();

            if (item == selectedItem)
                _inventoryObjectPool.ActivateConcreateItem(item);
        }
    }

    private void SetDefaultAnimalForIteration(InventoryItem item)
    {
        foreach (var iteration in _iterations)
        {
            if (iteration.CurrentAnimal == item.Animal)
            {
                var defaultAnimal = new AnimalLogic(AnimalsData.Instance.GetAnimalByID(-1));
                iteration.ChangeAnimal(defaultAnimal);
            }
        }
    }

    private void LoadInventory()
    {
        foreach (var item in _inventory)
            ActivateItem(item.Animal);
    }

    private void SaveInventory() { }
}
