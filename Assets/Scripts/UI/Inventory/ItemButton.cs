using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private InventoryItem _item;
    
    private InventoryItemMenu _itemMenu;
    private OpenCasePanel _addChancePanel;

    public static event Action<InventoryItem> ItemForMergeSelected;
    public static event Action<InventoryItem> ItemMenuOpened;
    public static event Action<InventoryItem> ItemForChanceImproveSelected;

    private void Start()
    {
        _itemMenu = FindObjectOfType<InventoryItemMenu>(true);
        _addChancePanel = FindObjectOfType<OpenCasePanel>(true);
    }

    private void OnEnable() => _button.onClick.AddListener(OpenItemMenu);

    private void OnDisable() => _button.onClick.RemoveListener(OpenItemMenu);

    private void OpenItemMenu()
    {
        if(_addChancePanel.isActiveAndEnabled)
        {
            ItemForChanceImproveSelected?.Invoke(_item);
        }
        else if (!_itemMenu.isActiveAndEnabled)
        {
            _itemMenu.gameObject.SetActive(true);
            ItemMenuOpened?.Invoke(_item);
        }
        else
        {
            ItemForMergeSelected?.Invoke(_item);
        }
    }
}
