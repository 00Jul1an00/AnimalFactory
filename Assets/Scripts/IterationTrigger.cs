using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IterationTrigger : MonoBehaviour
{
    [SerializeField] private float _productionDelay;
    [SerializeField] private Timer _timer;
    public float ProductionDelay { get { return _productionDelay; } set { if (value > 0) _productionDelay = value; } }

    private Product _productOnIteration;

    private IEnumerator WaitforProductionDelay()
    {
        _productOnIteration.StopProductOnBelt();
        yield return new WaitForSeconds(_productionDelay);
        _productOnIteration.MoveProductOnBelt();
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.TryGetComponent(out Product product))
        { 
            _productOnIteration = product;  
            StartCoroutine(WaitforProductionDelay());
            StartCoroutine(_timer.TimerAnimation(_productionDelay));
        }
    }
}
