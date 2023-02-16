using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductPool : MonoBehaviour
{
    [SerializeField] private Product _productPrefab;
    [SerializeField] private int _poolCapacity;

    public ObjectPool<Product> Pool { get; private set; }

    private void Start()
    {
        Pool = new ObjectPool<Product>(_productPrefab, _poolCapacity);
        Pool.Init(transform.position, Quaternion.identity, transform);
    }
}
