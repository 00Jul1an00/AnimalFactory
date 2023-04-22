using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeWorker : MonoBehaviour
{
    [SerializeField] private Iteration[] _iterations;
    [SerializeField] private Button[] _iterationButtons;

    private Dictionary<Button, Iteration> _iterationsDict = new();

    private InventoryItem _selectedItem;

    private void Start()
    {
        ItemButton.ItemMenuOpened += OnItemMenuOpened;

        for (int i = 0; i < _iterations.Length; i++)
            _iterationsDict.Add(_iterationButtons[i], _iterations[i]);

        gameObject.SetActive(false);
    }

    public void IterationButtonClick(Button button)
    {
        _iterationsDict.TryGetValue(button, out var iteration);

        if (iteration.CurrentAnimal == _selectedItem.Animal)
            return;
        else
            iteration.ChangeAnimal(_selectedItem.Animal);

        gameObject.SetActive(false);
    }

    private void OnItemMenuOpened(InventoryItem item)
    {
        _selectedItem = item;
    }
}
