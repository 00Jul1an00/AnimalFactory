using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MergeMenu : MonoBehaviour
{
    #region 1st item
    [SerializeField] private Image _firstBackground;
    [SerializeField] private Image _firstItemSprite;
    [SerializeField] private TMP_Text _firstItemCostStat;
    [SerializeField] private TMP_Text _firstItemSpeedStat;
    [SerializeField] private TMP_Text _firstItemName;
    #endregion

    #region 2nd item
    [SerializeField] private Image _secondBackground;
    [SerializeField] private Image _secondItemSprite;
    [SerializeField] private TMP_Text _secondItemCostStat;
    [SerializeField] private TMP_Text _secondtemSpeedStat;
    [SerializeField] private TMP_Text _secondItemName;
    #endregion

    [SerializeField] private Slider _costSlider;
    [SerializeField] private Slider _speedSlider;
    [SerializeField] private Slider _speedUpgradeSlider;
    [SerializeField] private Slider _costUpgradeSlider;
    [SerializeField] private Button _secondAnimalButton;
    [SerializeField] private Button _closeMergeInventoryButton;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Canvas _inventoryCanvas;

    private int _startCanvasSorting;
    private InventoryItem _firstItem;
    private InventoryItem _secondItem;

    private void OnEnable()
    {
        ItemButton.ItemForMergeSelected += OnSelectedSecondAnimal;
        _secondAnimalButton.onClick.AddListener(ActivateMergeMenu);
        _closeMergeInventoryButton.onClick.AddListener(OnMergeMenuClose);

        _startCanvasSorting = _inventoryCanvas.sortingOrder;
    }

    private void OnDisable()
    {
        ItemButton.ItemForMergeSelected -= OnSelectedSecondAnimal;
        _secondAnimalButton.onClick.RemoveListener(ActivateMergeMenu);
        _closeMergeInventoryButton.onClick.RemoveListener(OnMergeMenuClose);
    }

    public void DrawFirstItem(InventoryItem item)
    {
        _firstItem = item;
        DrawSliders();
        _firstItem.DrawItem(_firstBackground, _firstItemSprite, _firstItemCostStat, _firstItemSpeedStat, _firstItemName);
    }

    private void DrawSliders()
    {
        _costSlider.maxValue = _firstItem.Animal.BaseAnimal.BaseQuality.MaxCost;
        _speedSlider.maxValue = _firstItem.Animal.BaseAnimal.BaseQuality.MaxSpeed;

        _costUpgradeSlider.maxValue = _costSlider.maxValue;
        _speedUpgradeSlider.maxValue = _speedSlider.maxValue;

        _costUpgradeSlider.value = _firstItem.Animal.Cost;
        _speedUpgradeSlider.value = _firstItem.Animal.Speed;
        _costSlider.value = _firstItem.Animal.Cost;
        _speedSlider.value = _firstItem.Animal.Speed;
    }

    private void DrawSecondItem(InventoryItem item)
    {
        if (_secondItem != null)
        {
            _costSlider.value -= _secondItem.Animal.BaseAnimal.BaseQuality.MergePower;
            _speedSlider.value -= _secondItem.Animal.BaseAnimal.BaseQuality.MergePower;
        }

        _secondItem = item;
        _secondItem.DrawItem(_secondBackground, _secondItemSprite, _secondItemCostStat, _secondtemSpeedStat, _secondItemName);

        _costUpgradeSlider.value += _secondItem.Animal.BaseAnimal.BaseQuality.MergePower;
        _speedUpgradeSlider.value += _secondItem.Animal.BaseAnimal.BaseQuality.MergePower;
        
    }

    private void OnSelectedSecondAnimal(InventoryItem item)
    {
        DrawSecondItem(item);
        _inventoryCanvas.sortingOrder = _startCanvasSorting;
    }

    private void OnMergeMenuClose()
    {
        _inventory.OnMergeMenuClose(_firstItem);
    }

    private void ActivateMergeMenu()
    {
        _inventoryCanvas.sortingOrder = 200;
        _inventory.DrawItemsInMergeMenu(_firstItem);
    }

    public void ResetSecondItem()
    {
        _secondItem = null;
        _secondBackground.sprite = null;
        _secondItemSprite.sprite = null;
        _secondItemCostStat.text = null;
        _secondtemSpeedStat.text = null;
        _secondItemName.text = null;
    }

    public void OnApproveButtonClick()
    {
        _costSlider.value += _secondItem.Animal.BaseAnimal.BaseQuality.MergePower;
        _speedSlider.value += _secondItem.Animal.BaseAnimal.BaseQuality.MergePower;

        _costUpgradeSlider.value = 0;
        _speedUpgradeSlider.value = 0;
    }
}

