using UnityEngine;
using System;

[RequireComponent(typeof(Iteration))]
public class WorkerUpgrade : BaseUpgrade
{
    [Min(1)]
    [SerializeField] private float _upgradeSpeedMultiply;
    private Iteration _worker;
    public event Action WorkerUpgraded;

    private void Start()
    {
        _worker = GetComponent<Iteration>();
    }

    protected override void UpgradeLogic()
    {
        _worker.ProductionDelay /= _upgradeSpeedMultiply;
        WorkerUpgraded?.Invoke();
        _upgradeStats.SpecificMyltiply = _upgradeSpeedMultiply;
    }
}
