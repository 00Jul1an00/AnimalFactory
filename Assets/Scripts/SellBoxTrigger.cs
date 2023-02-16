using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBoxTrigger : MonoBehaviour
{
    [SerializeField] private ProductPool _productPool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Product product = collision.attachedRigidbody.GetComponent<Product>();

        if (product != null)
        {
            print("++");
            _productPool.Pool.DeactivateObject();
        }
    }
}
