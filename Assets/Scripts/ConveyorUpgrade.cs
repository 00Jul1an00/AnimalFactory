using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ConveyorBelt))]
public class ConveyorUpgrade : BaseUpgrade
{
    [SerializeField] private float _speedUpMul;

    private ConveyorBelt _conveyorBelt;
    private void Start()
    {
        _conveyorBelt = GetComponent<ConveyorBelt>();    
    }

    protected override void UpgradeLogic()
    {
        print("from CU");
        _conveyorBelt.SetSpeedMultiply(_speedUpMul);
    }
}
