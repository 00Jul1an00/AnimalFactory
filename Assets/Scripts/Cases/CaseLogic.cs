using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using TMPro;

public class CaseLogic : MonoBehaviour, IReward
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private CaseSO _caseSO;
    [SerializeField] AddDropChanceLogic _addDropChanceLogic;
    [SerializeField] private Button _caseMenuOpenButton;
    [SerializeField] private TMP_Text _keysQuantityText;
    [SerializeField] private OpenCasePanel _openCasePanel;

    private int _keysQuantity;
    private List<InventoryItem> _itemsToDelete = new();

    public QuestReward Reward => QuestReward.Case;

    public static event Action<CaseLogic> CaseMenuOpened;

    public CaseSO CaseSO => _caseSO;

    private void OnEnable()
    {
        _caseMenuOpenButton.onClick.AddListener(OnCaseMenuOpenButtonClick);
        _keysQuantityText.text = _keysQuantity.ToString();
    }

    private void OnDisable()
    {
        _caseMenuOpenButton.onClick.RemoveListener(OnCaseMenuOpenButtonClick);
    }

    private void Start()
    {
        _keysQuantity = SaveLoadSystem.Instance.LoadKeysCountForCase(this);
    }

    public void OpenCase()
    {
        if (_keysQuantity == 0)
            return;

        _keysQuantity--;
        _keysQuantityText.text = _keysQuantity.ToString();
        GiveRandReward();
        _itemsToDelete = _addDropChanceLogic.GetSelectedItemsListCopy();

        foreach (var item in _itemsToDelete)
            _inventory.RemoveItemFromInventory(item);

        _itemsToDelete.Clear();
        _addDropChanceLogic.ResetChanceImprove();
    }

    private void GiveRandReward()
    {
        AnimalQuality rewardQuality = CalcRewardQuality(UnityEngine.Random.Range(0, 100) + _addDropChanceLogic.ChanceImprove);
        AnimalSO reward = AnimalsData.Instance.GetRandAnimalByQuality(rewardQuality);
        print(rewardQuality);
        _inventory.AddAnimalToInventory(reward);
    }

    private AnimalQuality CalcRewardQuality(int value)
    {
        print(value);

        if (value <= _caseSO.CommonDropChance)
        {
            return AnimalQuality.Common;
        }
        else if (value - _caseSO.CommonDropChance <= _caseSO.RareDropChance)
        {
            return AnimalQuality.Rare;
        }
        else if (value - _caseSO.CommonDropChance - _caseSO.RareDropChance <= _caseSO.MythicalDropChance)
        {
            return AnimalQuality.Mythical;
        }
        else
        {
            return AnimalQuality.Legendary;
        }
    }

    private void OnCaseMenuOpenButtonClick()
    {
        if (_keysQuantity == 0)
            return;

        _openCasePanel.gameObject.SetActive(true);
        CaseMenuOpened?.Invoke(this);
    }

    public void GiveQuestReward(int rewardValue)
    {
        if (rewardValue == _caseSO.ID)
        {
            _keysQuantity++;
            SaveLoadSystem.Instance.SaveKeysCountForCase(this, _keysQuantity);
            _keysQuantityText.text = _keysQuantity.ToString();
        }
    }
}
