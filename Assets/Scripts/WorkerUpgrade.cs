using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IterationTrigger))]
public class WorkerUpgrade : BaseUpgrade
{
    private IterationTrigger _worker;

    private void Start()
    {
        _worker = GetComponent<IterationTrigger>();
    }

    protected override void UpgradeLogic()
    {
        print("from WU");
    }
}
