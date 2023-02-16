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
                StartCoroutine(_timer.TimerAnimation(_secondsBetweenSpawn));
                _previusSpawnProduct = _currentSpawnProduct;
                int index = _productPool.Pool.LastActiveIndex;
                _productPool.Pool.ActivateObject();
                _currentSpawnProduct = _productPool.Pool.GetObjectFromPool(index);
                _currentSpawnProduct.PreviusProductOnBelt = _previusSpawnProduct;
                yield return new WaitForSeconds(_secondsBetweenSpawn);
            }

            yield return null;
        }
    }
}
