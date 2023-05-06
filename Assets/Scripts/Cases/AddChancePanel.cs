using UnityEngine;
using UnityEngine.UI;

public class AddChancePanel : MonoBehaviour
{
    [SerializeField] private Canvas _mainInventoryCanvas;
    [SerializeField] private GameObject _mainInventory;
    [SerializeField] private Button _closeInventoryButton;
    
    private Button _addChanceButton;
    private int _startInventoryCanvasSortingOrder;

    private void Start()
    {
        _addChanceButton = GetComponent<Button>();
        _startInventoryCanvasSortingOrder = _mainInventoryCanvas.sortingOrder;
    }

    private void OnEnable()
    {
        _addChanceButton.onClick.AddListener(OpenInventory);
        _closeInventoryButton.onClick.AddListener(CloseInventory);
    }

    private void OnDisable()
    {
        _addChanceButton.onClick.RemoveListener(OpenInventory);
        _closeInventoryButton.onClick.RemoveListener(CloseInventory);
    }

    private void OpenInventory()
    {
        _mainInventoryCanvas.sortingOrder = 200;
        _mainInventory.SetActive(true);
    }

    private void CloseInventory()
    {
        _mainInventoryCanvas.sortingOrder = _startInventoryCanvasSortingOrder;
        _mainInventory.SetActive(false);
    }
}
