using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartProductionTrigger : MonoBehaviour
{
    public bool CanSpawn { get; private set; } = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.TryGetComponent(out Product product))
            CanSpawn = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CanSpawn = true;
    }
}
