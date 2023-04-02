using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _triggers = new GameObject[3];
    [SerializeField] private IterationTrigger[] _itTriggers = new IterationTrigger[3];

    [SerializeField] private int _speedMultiplier;
    [SerializeField] private TextMeshProUGUI _countText;
    private bool isManagerActive = false;
    private float _speedUpInSec = 10;
    


    
    private void Start()
    {
        _countText.text = _speedUpInSec.ToString();
        _triggers = GameObject.FindGameObjectsWithTag("IterationTrigger");
        for (int i = 0; i < _triggers.Length; i++) 
        {
            _itTriggers[i] = _triggers[i].GetComponent<IterationTrigger>();
        }
        
    }

    private void Update()
    {
        if (isManagerActive)
        {
            _speedUpInSec -= Time.deltaTime;
            _countText.text = _speedUpInSec.ToString("F0");
        }
    }


    private IEnumerator SpeedUpCoroutine()
    {
        for (int i = 0; i < _itTriggers.Length; i++)
        {
            _itTriggers[i].ProductionDelay /= _speedMultiplier;
        }    
        yield return new WaitForSeconds(_speedUpInSec);

        for (int i = 0; i < _itTriggers.Length; i++)
        {
            _itTriggers[i].ProductionDelay *= _speedMultiplier;
        }
        isManagerActive = false;
        StopCoroutine(SpeedUpCoroutine());
    }

    

    private void OnMouseDown()
    {
        if (isManagerActive == false)
        {
            isManagerActive = true;
            StartCoroutine(SpeedUpCoroutine());
        }
        
        
    }

    
}
