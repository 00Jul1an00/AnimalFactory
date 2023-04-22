using UnityEngine;
using UnityEngine.UI;

public class ApproveMergeButton : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Button _approveButton;
    [SerializeField] private MergeMenu _mergeMenu;

    private InventoryItem _firstItem;
    private InventoryItem _secondItem;

    private void OnEnable()
    {
        DeactivateButton();
        ItemButton.ItemMenuOpened += OnItemMenuOpened;
        ItemButton.ItemForMergeSelected += OnItemForMergeSelected;
        _approveButton.onClick.AddListener(OnApproveButtonClick);
    }

    private void OnDisable()
    {
        ItemButton.ItemMenuOpened -= OnItemMenuOpened;
        ItemButton.ItemForMergeSelected -= OnItemForMergeSelected;
        _approveButton.onClick.RemoveListener(OnApproveButtonClick);
    }

    private void OnItemMenuOpened(InventoryItem item)
    {
        _firstItem = item;
    }

    private void OnItemForMergeSelected(InventoryItem item)
    {
        _secondItem = item;
        ActivateButton();
    }

    private void OnApproveButtonClick()
    {
        _mergeMenu.OnApproveButtonClick();
        _inventory.RemoveItemFromInventory(_secondItem);
        _firstItem.Animal.MergeAnimals(_secondItem.Animal.BaseAnimal.BaseQuality);
        _mergeMenu.DrawFirstItem(_firstItem);
        _mergeMenu.ResetSecondItem();
        DeactivateButton();
    }

    private void ActivateButton()
    {
        _approveButton.interactable = true;
    }

    private void DeactivateButton()
    {
        _approveButton.interactable = false;
    }
}
