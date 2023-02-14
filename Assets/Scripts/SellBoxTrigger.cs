using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBoxTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Product product = collision.attachedRigidbody.GetComponent<Product>();

        if (product != null)
        {
            print("++");
            Destroy(product.gameObject);
        }
    }
}
