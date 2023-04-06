using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IterationTrigger))]
public class WorkerUpgrade : BaseUpgrade
{
    [Min(1)]
    [SerializeField] private float _upgradeSpeedMultiply;
    private IterationTrigger _worker;

    private void Start()
    {
        _worker = GetComponent<IterationTrigger>();
    }

    protected override void UpgradeLogic()
    {
        _worker.ProductionDelay /= _upgradeSpeedMultiply; 
    }
}
