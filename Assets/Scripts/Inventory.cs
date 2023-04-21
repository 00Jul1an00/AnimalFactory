using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _inventoryCapacity;
    [SerializeField] private ItemsInInventoryObjectPool _mainInventoryObjectPool;
    [SerializeField] private ItemsInInventoryObjectPool _mergeInventoryObjectPool;
    
    private List<AnimalLogic> _inventory = new();

    private void Start()
    {
        AddAnimalToInventory(AnimalsData.Instance.GetAnimalByID(0));
        AddAnimalToInventory(AnimalsData.Instance.GetAnimalByID(1));
    }

    public void AddAnimalToInventory(AnimalSO animal)
    {
        var animalLogic = new AnimalLogic(animal);
        _inventory.Add(animalLogic);
        ActivateItem(animalLogic);
    }

    public void RemoveItemFromInventoru(AnimalLogic animal)
    {
        _inventory.Remove(animal);
    }

    private void ActivateItem(AnimalLogic animalLogic)
    {
        _mainInventoryObjectPool.ActivateItemInObjectPool(animalLogic);
        _mergeInventoryObjectPool.ActivateItemInObjectPool(animalLogic);
    } 
}
