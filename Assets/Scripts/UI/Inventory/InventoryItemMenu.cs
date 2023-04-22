using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemMenu : MonoBehaviour
{
    [SerializeField] private Button _mergeButton;
    [SerializeField] private Button _changeWorkerButton;

    [SerializeField] private Image _background;
    [SerializeField] private Image _itemSprite;
    [SerializeField] private TMP_Text _costStat;
    [SerializeField] private TMP_Text _speedStat;
    [SerializeField] private TMP_Text _name;

    [SerializeField] private MergeMenu _mergeMenu;

    private InventoryItem _selectedItem;

    private void OnEnable()
    {
        ItemButton.ItemMenuOpened += OnItemMenuOpened;
        _mergeButton.onClick.AddListener(DrawMergeMenu);
    }

    private void OnDisable()
    {
        ItemButton.ItemMenuOpened -= OnItemMenuOpened;
        _mergeButton.onClick.RemoveListener(DrawMergeMenu);
    }

    private void OnItemMenuOpened(InventoryItem item)
    {
        _selectedItem = item;
        RedrawItemInMenu();
    }

    public void RedrawItemInMenu()
    {
        _selectedItem.DrawItem(_background, _itemSprite, _costStat, _speedStat, _name);
    }

    private void DrawMergeMenu() => _mergeMenu.DrawFirstItem(_selectedItem);
}
