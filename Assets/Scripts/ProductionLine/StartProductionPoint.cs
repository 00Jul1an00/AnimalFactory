using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartProductionPoint : MonoBehaviour
{
    [SerializeField] private Product _productPrefab;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Timer _timer;
    [SerializeField] private ProductPool _productPool;

    private StartProductionTrigger _startTrigger;
    private Product _currentSpawnProduct;
    private Product _previusSpawnProduct;

    private void Start()
    {
        _startTrigger = GetComponentInChildren<StartProductionTrigger>();      
        StartCoroutine(SpawnProduct());
    }

    private IEnumerator SpawnProduct()
    {
        while (true)
        {
            if (_startTrigger.CanSpawn)
            {
                _timer.AnimationDuration = _secondsBetweenSpawn;
                StartCoroutine(_timer.TimerAnimation());                
                _productPool.Pool.ActivateObject();
                LinkProducts();

                for (int i = 0; i < Timer.DURATION_SPLITING; i++)
                {
                    yield return new WaitForSeconds(_secondsBetweenSpawn / Timer.DURATION_SPLITING);
                }
            }

            yield return null;
        }
    }

    private void LinkProducts()
    {

        _previusSpawnProduct = _currentSpawnProduct;
        _currentSpawnProduct = _productPool.Pool.GetLastActivatedObject();
        
        if (_currentSpawnProduct == _previusSpawnProduct)
            return;

        _currentSpawnProduct.NextProductOnBelt = _previusSpawnProduct;    
    }
}
