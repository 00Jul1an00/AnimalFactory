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
    [SerializeField] private TMP_Text _name;

    private AnimalLogic _animal;

    public AnimalLogic Animal => _animal;

    private void Init()
    {
        ReDrawStats();

        AnimalQuality quality = _animal.BaseAnimal.Quility;

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

    public void ReDrawStats()
    {
        _itemSprite.sprite = _animal.Sprite;
        _costStat.text = _animal.Cost.ToString();
        _speedStat.text = _animal.Speed.ToString();
        _name.text = _animal.BaseAnimal.Name;
    }

    public void InitItem(AnimalLogic animalLogic)
    {
        _animal = animalLogic;
        Init();
    }

    public void DrawItem(Image background, Image itemSprite, TMP_Text costStat, TMP_Text speedStat, TMP_Text name)
    {
        ReDrawStats();
        background.sprite = _background.sprite;
        itemSprite.sprite = _itemSprite.sprite;
        costStat.text = _costStat.text;
        speedStat.text = _speedStat.text;
        name.text = _name.text;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override bool Equals(object other)
    {
        var otherItem = (InventoryItem)other;
        return this.Animal == otherItem.Animal;
    }

    public static bool operator ==(InventoryItem a, InventoryItem b)
    {
        if (System.Object.ReferenceEquals(a, b))
            return true;

        if ((a is null) || (b is null))
            return false;

        return a.Animal == b.Animal;
    }
    public static bool operator !=(InventoryItem a, InventoryItem b)
    {
        if (System.Object.ReferenceEquals(a, b))
            return false;

        if ((a is null) || (b is null))
            return true;

        if(a.Animal == b.Animal)
            return false;

        return a.Animal != b.Animal;
    }
}
