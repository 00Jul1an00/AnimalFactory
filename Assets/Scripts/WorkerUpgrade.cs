using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(IterationTrigger))]
public class WorkerUpgrade : BaseUpgrade
{
    [Min(1)]
    [SerializeField] private float _upgradeSpeedMultiply;
    private IterationTrigger _worker;
    public event Action WorkerUpgraded;

    private void Start()
    {
        _worker = GetComponent<IterationTrigger>();
    }

    protected override void UpgradeLogic()
    {
        _worker.ProductionDelay /= _upgradeSpeedMultiply;
        WorkerUpgraded?.Invoke();
    }
}
