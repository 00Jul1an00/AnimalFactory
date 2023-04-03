using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBoxTrigger : MonoBehaviour
{
    [SerializeField] private ProductPool _productPool;
    [SerializeField] private GameObject _moneyManager;

    public int MoneyQuantityInBox = 0;
    //private MoneyLogic _moneyLogic;

    private void Start()
    {
        //_moneyLogic = _moneyManager.GetComponent<MoneyLogic>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Product product = collision.attachedRigidbody.GetComponent<Product>();

        if (product != null)
        {
            print("++");
            MoneyQuantityInBox++;
            _productPool.Pool.DeactivateObject(product);
        }
    }

    public void SellProducts()
    {
        //_moneyLogic.Money += MoneyQuantityInBox;
        MoneyQuantityInBox = 0;
        //_moneyLogic.DrawMoney();
    }
}
