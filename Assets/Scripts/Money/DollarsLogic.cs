using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DollarsLogic : CurrencyLogic, IReward
{
    public override QuestReward Reward => QuestReward.Dollars;

    public void GiveQuestReward(int rewardValue) => CurrencyCount += rewardValue;

    private void Start()
    {
        DrawMoney();
    }
}
