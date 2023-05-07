using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class OpenCasePanel : MonoBehaviour
{
    [SerializeField] private Canvas _inventoryCanvas;
    [SerializeField] private Button _addChanceButton;
    [SerializeField] private Button _closeInventoryButton;
    [SerializeField] private Button _approveSelectedItemsForChanceImproveButton;
    [SerializeField] private Button _openCaseButton;
    [SerializeField] private TMP_Text _addChanceButtonText;
    [SerializeField] private AddDropChanceLogic _addDropChanceLogic;

    private List<InventoryItem> _selectedItems = new();
    private int _startInventoryCanvasSortingOrder;
    private const int MAX_NUM_SELECTED_ITEMS = 5;
    private int _currentNumSelectedItems;
    private CaseLogic _currentCaseLogic;

    private void Start()
    {
        _startInventoryCanvasSortingOrder = _inventoryCanvas.sortingOrder;
        _approveSelectedItemsForChanceImproveButton.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _addChanceButton.onClick.AddListener(OpenInventory);
        _closeInventoryButton.onClick.AddListener(CloseInventoryByCrossPress);
        ItemButton.ItemForChanceImproveSelected += OnItemForImproveChanceSelected;
        _approveSelectedItemsForChanceImproveButton.onClick.AddListener(OnApproveButtonClick);
        _addDropChanceLogic.ChanceImproveReseted += OnChanceImproveReseted;
        CaseLogic.CaseMenuOpened += OnCaseMenuOpened;
        _openCaseButton.onClick.AddListener(OnOpenCaseButtonClick);
    }

    private void OnDisable()
    {
        _addChanceButton.onClick.RemoveListener(OpenInventory);
        _closeInventoryButton.onClick.RemoveListener(CloseInventoryByCrossPress);
        ItemButton.ItemForChanceImproveSelected -= OnItemForImproveChanceSelected;
        _approveSelectedItemsForChanceImproveButton.onClick.RemoveListener(OnApproveButtonClick);
        _addDropChanceLogic.ChanceImproveReseted -= OnChanceImproveReseted;
        CaseLogic.CaseMenuOpened -= OnCaseMenuOpened;
        _openCaseButton.onClick.RemoveListener(OnOpenCaseButtonClick);
    }

    private void OpenInventory()
    {
        _inventoryCanvas.gameObject.SetActive(true);
        _inventoryCanvas.sortingOrder = 200;
        _approveSelectedItemsForChanceImproveButton.gameObject.SetActive(true);
    }

    private void CloseInvntoryByApprovePress()
    {
        _inventoryCanvas.gameObject.SetActive(false);
        _inventoryCanvas.sortingOrder = _startInventoryCanvasSortingOrder;
        _approveSelectedItemsForChanceImproveButton.gameObject.SetActive(false);
    }

    private void CloseInventoryByCrossPress()
    {
        CloseInvntoryByApprovePress();
        _currentNumSelectedItems = 0;
        AddChanceButtonTextRewrite();
        ClearSelectedItemsList();
    }

    private void ClearSelectedItemsList()
    {
        foreach (var item in _selectedItems)
            item.DisableOutline();

        _selectedItems.Clear();
    }

    private void OnItemForImproveChanceSelected(InventoryItem item)
    {
        if (item.OutLineEnabled)
        {
            item.DisableOutline();
            _addDropChanceLogic.DecreaseDropChance(item);
            _selectedItems.Remove(item);
            _currentNumSelectedItems--;
        }
        else
        {
            if (_currentNumSelectedItems >= MAX_NUM_SELECTED_ITEMS)
            {
                _selectedItems[0].DisableOutline();
                _addDropChanceLogic.DecreaseDropChance(_selectedItems[0]);
                _selectedItems.Remove(_selectedItems[0]);
                _currentNumSelectedItems--;
            }

            item.EnableOutline();
            _addDropChanceLogic.IncreaseDropChance(item);
            _selectedItems.Add(item);
            _currentNumSelectedItems++;
        }  
    }

    private void OnApproveButtonClick()
    {
        CloseInvntoryByApprovePress();
        AddChanceButtonTextRewrite();
    }

    private void AddChanceButtonTextRewrite()
    {
        _addChanceButtonText.text = _currentNumSelectedItems.ToString();
    }

    private void OnChanceImproveReseted()
    {
        _currentNumSelectedItems = 0;
        AddChanceButtonTextRewrite();
        ClearSelectedItemsList();
    }

    private void OnCaseMenuOpened(CaseLogic invoker)
    {
        _currentCaseLogic = invoker;
    }

    private void OnOpenCaseButtonClick()
    {
        _currentCaseLogic.OpenCase();
    }
}
