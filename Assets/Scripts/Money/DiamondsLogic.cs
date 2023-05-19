using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiamondsLogic : CurrencyLogic, IReward
{
    public override QuestReward Reward => QuestReward.Diamonds;

    public void GiveQuestReward(int rewardValue)
    {
        CurrencyCount += rewardValue;
    }

    private void Start()
    {
        DrawMoney();
    }
}