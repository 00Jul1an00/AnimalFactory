using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBoxTrigger : MonoBehaviour
{
    [SerializeField] private ProductPool _productPool;
    private DollarsLogic _dollarsLogic;

    private int _moneyQuantityInBox = 0;

    private void Start() => _dollarsLogic = FindObjectOfType<DollarsLogic>();

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.attachedRigidbody.TryGetComponent<Product>(out var product))
        {
            _moneyQuantityInBox += product.Cost;
            _productPool.Pool.DeactivateObject(product);
        }
    }

    public void SellProducts()
    {
        _dollarsLogic.CurrencyCount += _moneyQuantityInBox;
        _moneyQuantityInBox = 0;
    }
}
