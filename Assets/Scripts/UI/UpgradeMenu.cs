using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] private Button _closeButton;

    [Space]
    [Header("Workers Upgrade")]
    [SerializeField] private Button _workerIButton;
    [SerializeField] private Button _workerIIButton;
    [SerializeField] private Button _workerIIIButton;
    [SerializeField] private Button _conveyorButton;
    [SerializeField] private Button _productButton;
    [Space]
    [Header("Upgrades")]
    [SerializeField] private WorkerUpgrade _workerIUpgrade;
    [SerializeField] private WorkerUpgrade _workerIIUpgrade;
    [SerializeField] private WorkerUpgrade _workerIIIUpgrade;
    [SerializeField] private ConveyorUpgrade _conveyorUpgrade;
    [SerializeField] private ProductUpgrade _productUpgrade;
    [Space]
    [Header("Prices")]
    [SerializeField] private TMP_Text _workerIUpgradePrice;
    [SerializeField] private TMP_Text _workerIIUpgradePrice;
    [SerializeField] private TMP_Text _workerIIIUpgradePrice;
    [SerializeField] private TMP_Text _conveyorUpgradePrice;
    [SerializeField] private TMP_Text _productUpgradePrice;

    private List<Button> _allUpgradesButtons;
    private List<BaseUpgrade> _allUpgrades;
    private List<TMP_Text> _pricesText;

    private void Start()
    {
        _allUpgradesButtons = new List<Button>() { _workerIButton, _workerIIButton, _workerIIIButton, _conveyorButton, _productButton };
        _allUpgrades = new List<BaseUpgrade>() { _workerIUpgrade, _workerIIUpgrade, _workerIIIUpgrade, _conveyorUpgrade, _productUpgrade };
        _pricesText = new List<TMP_Text>() { _workerIUpgradePrice, _workerIIUpgradePrice, _workerIIIUpgradePrice, _conveyorUpgradePrice, _productUpgradePrice };
        _closeButton.onClick.AddListener(CloseMenu);
        UpgradesInit();
    }

    public void CloseMenu() => this.gameObject.SetActive(false);

    private void UpgradesInit()
    {
        for (int i = 0; i < _allUpgradesButtons.Count; i++)
        {
            _allUpgradesButtons[i].onClick.AddListener(_allUpgrades[i].Upgrade);
            _allUpgrades[i].Upgraded += OnUpgraded;
            _pricesText[i].text = _allUpgrades[i].UpgradeCost.ToString();
        }
    }

    private void PriceTextUpdate()
    {

    }

    private void OnUpgraded(BaseUpgrade upgrade)
    {
        int index = _allUpgrades.IndexOf(upgrade);
        
    }
}
