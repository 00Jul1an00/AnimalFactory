using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsInInventoryObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private InventoryItem _itemPrefab;
    [SerializeField] private int _inventoryCapacity;

    private ObjectPool<InventoryItem> _pool;

    private void Start()
    {
        _pool = ActivateObjectPool();
    }

    public void ActivateItemInObjectPool(AnimalLogic animalLogic)
    {
        _pool.ActivateObject();
        var item = _pool.GetLastSpawnedObject();
        item.AddItemToInventory(animalLogic);
    }

    private ObjectPool<InventoryItem> ActivateObjectPool()
    {

        ObjectPool<InventoryItem> pool = new(_itemPrefab, _inventoryCapacity, true);
        pool.Init(Vector2.zero, Quaternion.identity, _container);
        return pool;
    }
}
