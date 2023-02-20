using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ConveyorBelt))]
public class ConveyorUpgrade : BaseUpgrade
{
    private ConveyorBelt _ConveyorBelt;

    private void Start()
    {
        _ConveyorBelt = GetComponent<ConveyorBelt>();    
    }

    protected override void UpgradeLogic()
    {
        print("from CU");
    }
}
