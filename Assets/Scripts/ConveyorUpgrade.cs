using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ConveyorBelt))]
public class ConveyorUpgrade : BaseUpgrade
{
    [Min(1)]
    [SerializeField] private float _speedUpMultiply;
    private ConveyorBelt _conveyorBelt;

    private void Start()
    {
        _conveyorBelt = GetComponent<ConveyorBelt>();    
    }

    protected override void UpgradeLogic()
    {
        _conveyorBelt.SetSpeedMultiply(_speedUpMultiply);
    }
}
