using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IterationTrigger : MonoBehaviour
{
    [SerializeField] private float _productionDelay;
    [SerializeField] private Timer _timer;

    private Product _productOnIteration;

    public float ProductionDelay 
    { 
        get { return _productionDelay; } 
        set 
        {
            if (value > 0)
            {
                _productionDelay = value;
                _timer.AnimationDuration = _productionDelay;
            }
        } 
    }

    private void Start()
    {
        _timer.AnimationDuration = _productionDelay;
    }

    private IEnumerator WaitforProductionDelay()
    {
        _productOnIteration.StopProductOnBelt();

        for (int i = 0; i < Timer.DURATION_SPLITING; i++)
        {
            yield return new WaitForSeconds(_productionDelay / Timer.DURATION_SPLITING);
        }

        
        _productOnIteration.MoveProductOnBelt();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.TryGetComponent(out Product product))
        { 
            _productOnIteration = product;
           StartCoroutine(WaitforProductionDelay());
           StartCoroutine(_timer.TimerAnimation());
        }
    }
}
