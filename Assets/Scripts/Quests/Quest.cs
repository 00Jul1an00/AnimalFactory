using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum QuestGoalType
{
    ClickCount,
    UpgradeLevel,
}

public enum QuestReward
{
    Money,
    Diamonds,
    Case,
}

public class Quest : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private string _description;

    [SerializeField] private QuestReward _rewardType;
    [SerializeField] private QuestGoalType _questGoal;
    public IReward RewardType { get; private set; }
    public QuestGoal QuestGoal { get; private set; }
    public int QuestId { get; protected set; }

    public event Action QuestComplete;

    private void OnValidate()
    {
        if (QuestGoal != null)
            return;

        switch (_questGoal)
        {
            case (QuestGoalType.ClickCount):
                gameObject.AddComponent<ClickCountGoal>();
                QuestGoal = GetComponent<ClickCountGoal>();
                return;
            case (QuestGoalType.UpgradeLevel):
                gameObject.AddComponent<UpgradeLevelGoal>();
                QuestGoal = GetComponent<UpgradeLevelGoal>();
                return;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

        }
    }
}
