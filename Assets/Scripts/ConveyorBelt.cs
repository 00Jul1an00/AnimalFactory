using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private float _speedMultiply = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.TryGetComponent(out Product product))
            product.transform.position += new Vector3(product.SpeedOnBelt * Time.deltaTime * _speedMultiply, 0);
    }
}
