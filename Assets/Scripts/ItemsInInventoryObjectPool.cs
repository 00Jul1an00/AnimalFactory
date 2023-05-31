using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsInInventoryObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private InventoryItem _itemPrefab;
    [SerializeField] private int _inventoryCapacity;

    private ObjectPool<InventoryItem> _pool;
    public List<InventoryItem> ItemsInPool { get; private set; }

    private void Start()
    {
        _pool = ActivateObjectPool();
        ItemsInPool = _pool.SpawnedList;
    }

    public InventoryItem ActivateItemInObjectPool(AnimalLogic animalLogic)
    {
        _pool.ActivateObject();
        var item = _pool.GetLastActivatedObject();
        item.InitItem(animalLogic);
        return item;
    }

    public void ActivateConcreateItem(InventoryItem item)
    {
        _pool.ActivateConcreateObject(item);
    }

    private ObjectPool<InventoryItem> ActivateObjectPool()
    {

        ObjectPool<InventoryItem> pool = new(_itemPrefab, _inventoryCapacity, true);
        pool.Init(Vector2.zero, Quaternion.identity, _container);
        return pool;
    }

    public void DeactivateItemInObjectPool(InventoryItem item)
    {
        _pool.DeactivateObject(item);
    }
}
