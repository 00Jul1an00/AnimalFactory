using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private Image _itemSprite;
    [SerializeField] private TMP_Text _costStat;
    [SerializeField] private TMP_Text _speedStat;

    private void Init(AnimalLogic animal)
    {
        _itemSprite.sprite = animal.Sprite;
        _costStat.text = animal.Cost.ToString(); 
        _speedStat.text = animal.Speed.ToString(); 

        AnimalQuality quality = animal.BaseAnimal.Quility;

        switch (quality)
        {
            case (AnimalQuality.Common):
                _background.color = Color.grey;
                return;
            case (AnimalQuality.Rare):
                _background.color = Color.blue;
                return;
            case (AnimalQuality.Mythical):
                _background.color = new Color(0.7f, 0, 1);
                return;
            case (AnimalQuality.Legendary):
                _background.color = Color.yellow;
                return;
        }

    }

    public void AddItemToInventory(AnimalLogic animal)
    {
        Init(animal);
    }
}
