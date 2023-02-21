using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpManager : MonoBehaviour
{
    [SerializeField] private GameObject _trigger;

    private IterationTrigger _itTrigger;

    private void Start()
    {
        _itTrigger = _trigger.GetComponent<IterationTrigger>();
    }

    //public void SpeedUp()
    //{
    //    _itTrigger.ProductionDelay /= 2;
     //   print(_itTrigger.ProductionDelay);
    //}

    //private void OnMouseDown()
    //{
    //    SpeedUp();
    //}
}
