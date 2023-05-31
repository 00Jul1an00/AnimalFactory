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
        Init();
        //_speedUpMultiply = _upgradeStats.SpecificMyltiply;
    }

    protected override void UpgradeLogic()
    {
        _conveyorBelt.SetSpeedMultiply(_speedUpMultiply);
        _upgradeStats.SpecificMyltiply = _speedUpMultiply;
    }
}
