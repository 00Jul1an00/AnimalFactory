using UnityEngine;
using UnityEngine.UI;

public class AddChancePanel : MonoBehaviour
{
    [SerializeField] private Canvas _inventoryCanvas;
    [SerializeField] private Button _addChanceButton;
    [SerializeField] private Button _closeInventoryButton;

    private int _startInventoryCanvasSortingOrder;
    
    private void Start()
    {
        _startInventoryCanvasSortingOrder = _inventoryCanvas.sortingOrder;
    }

    private void OnEnable()
    {
        _addChanceButton.onClick.AddListener(OpenInventory);
        _closeInventoryButton.onClick.AddListener(CloseInventory);
        ItemButton.ItemForChanceImproveSelected += OnItemForImproveChanceSelected;
    }

    private void OnDisable()
    {
        _addChanceButton.onClick.RemoveListener(OpenInventory);
        _closeInventoryButton.onClick.RemoveListener(CloseInventory);
        ItemButton.ItemForChanceImproveSelected -= OnItemForImproveChanceSelected;
    }

    private void OpenInventory()
    {
        _inventoryCanvas.gameObject.SetActive(true);
        _inventoryCanvas.sortingOrder = 200;
    }

    private void CloseInventory()
    {
        _inventoryCanvas.gameObject.SetActive(false);
        _inventoryCanvas.sortingOrder = _startInventoryCanvasSortingOrder;  
    }

    private void OnItemForImproveChanceSelected(InventoryItem item)
    {
        item.EnableOutline();
        //Call Method From Logic Script
    }
}
