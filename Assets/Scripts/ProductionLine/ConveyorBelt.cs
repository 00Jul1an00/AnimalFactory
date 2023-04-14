using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private float _speedValue = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.TryGetComponent(out Product product))
            product.transform.position += new Vector3(product.SpeedOnBelt * Time.deltaTime * _speedValue, 0);
    }

    public void SetSpeedMultiply(float value)
    {
        if(value <= 1)
            return;

        _speedValue *= value;
    }
}
