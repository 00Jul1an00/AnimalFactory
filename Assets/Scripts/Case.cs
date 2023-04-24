using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum CaseQuality
{
    Common,
    Rare,
    Legendary
}


public class Case : MonoBehaviour
{
    [SerializeField] private CaseQuality _quality;
    [SerializeField] private Inventory _inventory;
    [Space(20)]
    [SerializeField] private int _commonDropChance;
    [SerializeField] private int _rareDropChance;
    [SerializeField] private int _mythicalDropChance;
    [SerializeField] private int _legendaryDropChance;

    private void OpenCase()
    {
        GiveRandReward();
    }

    private void GiveRandReward()
    {
        AnimalQuality rewardQuality = CalcRewardQuality(Random.Range(0, 100));
        AnimalSO reward = AnimalsData.Instance.GetRandAnimalByQuality(rewardQuality);
        print(rewardQuality);
        //_inventory.AddAnimalToInventory(reward);
    }

    private void ImproveDropChance(AnimalQualitySO quality)
    {
        int chanceImprove = quality.Rarity;
        _commonDropChance -= chanceImprove;
        _rareDropChance += (chanceImprove / 3);
        _mythicalDropChance += (chanceImprove / 3);
        _legendaryDropChance += (chanceImprove / 3);
    }

    private AnimalQuality CalcRewardQuality(int value)
    {
        if (value <= _commonDropChance)
        {
            return AnimalQuality.Common;
        }
        else if (value - _commonDropChance <= _rareDropChance)
        {
            return AnimalQuality.Rare;
        }
        else if (value - _commonDropChance - _rareDropChance <= _mythicalDropChance)
        {
            return AnimalQuality.Mythical;
        }
        else
        {
            return AnimalQuality.Legendary;
        }
    }

    //debug
    private bool _isClisked;
    private void Update()
    {
        if (Input.GetKey(KeyCode.P) && !_isClisked)
        {
            _isClisked = true;

            if (_quality == CaseQuality.Common)
            {
                for (int i = 0; i < 100; i++)
                    OpenCase();
            }
        }
    }
}
