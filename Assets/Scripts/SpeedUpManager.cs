using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedUpManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _triggers = new GameObject[3];
    [SerializeField] private IterationTrigger[] _itTriggers = new IterationTrigger[3];

    [SerializeField] private int _speedMultiplier;
    


    
    private void Start()
    {       
        _triggers = GameObject.FindGameObjectsWithTag("IterationTrigger");
        for (int i = 0; i < _triggers.Length; i++) 
        {
            _itTriggers[i] = _triggers[i].GetComponent<IterationTrigger>();
        }
        
    }


    private IEnumerator SpeedUpCoroutine()
    {
        for (int i = 0; i < _itTriggers.Length; i++)
        {
            _itTriggers[i].ProductionDelay /= _speedMultiplier;
        }

        yield return new WaitForSeconds(10);

        for (int i = 0; i < _itTriggers.Length; i++)
        {
            _itTriggers[i].ProductionDelay *= _speedMultiplier;
        }
        StopCoroutine(SpeedUpCoroutine());
    }

    

    private void OnMouseDown()
    {            
        StartCoroutine(SpeedUpCoroutine());                      
    }

    
}
