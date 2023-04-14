using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IterationTrigger : MonoBehaviour
{
    [SerializeField] private float _productionDelay;
    [SerializeField] private Timer _timer;

    public event Action ProductOnIteration;
    public Product CurrentProductOnIteration { get; private set; }
    public float ProductionDelay 
    { 
        get { return _productionDelay; } 
        set 
        {
            if (value > 0 && _productionDelay >= 0.1f)
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
        CurrentProductOnIteration.StopProductOnBelt();

        for (int i = 0; i < Timer.DURATION_SPLITING; i++)
        {
            yield return new WaitForSeconds(_productionDelay / Timer.DURATION_SPLITING);
        }

        CurrentProductOnIteration.MoveProductOnBelt();        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.TryGetComponent(out Product product))
        {
           CurrentProductOnIteration = product;
           ProductOnIteration?.Invoke();
           StartCoroutine(WaitforProductionDelay());
           StartCoroutine(_timer.TimerAnimation());
        }
    }
}
