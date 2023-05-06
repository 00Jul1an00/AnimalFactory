using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private InventoryItem _item;
    private InventoryItemMenu _itemMenu;

    private static bool _isMenuOpened;

    public static event Action<InventoryItem> ItemForMergeSelected;
    public static event Action<InventoryItem> ItemMenuOpened;

    private void Start()
    {
        _itemMenu = FindObjectOfType<InventoryItemMenu>(true);
    }

    private void OnEnable() => _button.onClick.AddListener(OpenItemMenu);

    private void OnDisable() => _button.onClick.RemoveListener(OpenItemMenu);

    //potential bug
    private void OpenItemMenu()
    {
        if(!_isMenuOpened)
        {
            _itemMenu.gameObject.SetActive(true);
            _isMenuOpened = true;
            ItemMenuOpened?.Invoke(_item);
        }
        else if (!_itemMenu.isActiveAndEnabled)
        {
            _isMenuOpened = false;
        }
        else
        {
            ItemForMergeSelected?.Invoke(_item);
        }
    }
}
