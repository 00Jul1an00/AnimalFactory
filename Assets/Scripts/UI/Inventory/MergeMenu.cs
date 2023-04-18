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
    [SerializeField] private GameObject _mergeInventory;

    private InventoryItem _secondItem;

    private void OnEnable()
    {
        ItemButton.ItemForMergeSelected += OnSelectedSecondAnimal;
    }

    private void OnDisable()
    {
        ItemButton.ItemForMergeSelected -= OnSelectedSecondAnimal;
    }

    public void DrawFirstItem(InventoryItem item)
    {
        item.DrawItem(_firstBackground, _firstItemSprite, _firstItemCostStat, _firstItemSpeedStat, _firstItemName);
        _costSlider.value = item.Animal.Cost;
        _speedSlider.value = item.Animal.Speed;
    }

    private void DrawSecondItem(InventoryItem item)
    {
        if (_secondItem != null)
        {
            _costSlider.value -= _secondItem.Animal.BaseAnimal.BaseQuality.MergePower;
            _speedSlider.value -= _secondItem.Animal.BaseAnimal.BaseQuality.MergePower;
        }

        _secondItem = item;
        item.DrawItem(_secondBackground, _secondItemSprite, _secondItemCostStat, _secondtemSpeedStat, _secondItemName);

        _costSlider.value += item.Animal.BaseAnimal.BaseQuality.MergePower;
        _speedSlider.value += item.Animal.BaseAnimal.BaseQuality.MergePower;
    }

    private void OnSelectedSecondAnimal(InventoryItem item)
    {
        DrawSecondItem(item);
        _mergeInventory.SetActive(false);
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
}

