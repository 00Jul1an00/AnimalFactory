using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartProductionPoint : MonoBehaviour
{
    [SerializeField] private Product _productPrefab;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private float _secondsBetweenSpawn;

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
                _previusSpawnProduct = _currentSpawnProduct;
                _currentSpawnProduct = Instantiate(_productPrefab, _startPoint.position, Quaternion.identity);
                _currentSpawnProduct.PreviusProductOnBelt = _previusSpawnProduct;
                yield return new WaitForSeconds(_secondsBetweenSpawn);
            }

            yield return null;
        }
    }
}
