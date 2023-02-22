using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _triggers = new GameObject[3];
    [SerializeField] private IterationTrigger[] _itTriggers = new IterationTrigger[3];

    [SerializeField] private int _speedMultiplier;
    [SerializeField] private float _speedUpDurationInSec = 10;

    private void Start()
    {
        _speedUpDurationInSec *= 1000f;
        _triggers = GameObject.FindGameObjectsWithTag("IterationTrigger");
        for (int i = 0; i < _triggers.Length; i++) 
        {
            _itTriggers[i] = _triggers[i].GetComponent<IterationTrigger>();
        }
        
    }

    private void Update()
    {
        
    }

    public void SpeedUp()
    {
        for (int i = 0; i < _itTriggers.Length; i++)
        {
            _itTriggers[i].ProductionDelay /= _speedMultiplier;
        }

        
    }

    //private void OnMouseDown()
    //{
     //   SpeedUp();
    //}

    
}
