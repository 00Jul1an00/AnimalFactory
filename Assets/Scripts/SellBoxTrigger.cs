using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBoxTrigger : MonoBehaviour
{
    [SerializeField] private ProductPool _productPool;
    private DollarsLogic _dollarsLogic;

    public int _moneyQuantityInBox = 0;

    private void Start() => _dollarsLogic = FindObjectOfType<DollarsLogic>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Product product = collision.attachedRigidbody.GetComponent<Product>();

        if (product != null)
        {
            _moneyQuantityInBox += (int)product.Cost;
            _productPool.Pool.DeactivateObject(product);
        }
    }

    public void SellProducts()
    {
        _dollarsLogic.CurrencyCount += _moneyQuantityInBox;
        _moneyQuantityInBox = 0;
    }
}
