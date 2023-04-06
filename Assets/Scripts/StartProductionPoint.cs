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
                StartCoroutine(_timer.FixedTimerAnimation(_secondsBetweenSpawn));                
                LinkProducts();
                _productPool.Pool.ActivateObject();

                yield return new WaitForSeconds(_secondsBetweenSpawn);
            }

            yield return null;
        }
    }

    private void LinkProducts()
    {
        _previusSpawnProduct = _currentSpawnProduct;
        _currentSpawnProduct = _productPool.Pool.GetLastSpawnedObject();
        
        if (_currentSpawnProduct == _previusSpawnProduct)
            return;

        _currentSpawnProduct.PreviusProductOnBelt = _previusSpawnProduct;
        

        if (_previusSpawnProduct != null)
            _previusSpawnProduct.NextProductOnBelt = _currentSpawnProduct;
    }
}
