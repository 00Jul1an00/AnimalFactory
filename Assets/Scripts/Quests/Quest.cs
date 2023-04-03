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
        QuestGoal = GetComponent<QuestGoal>();
        if (QuestGoal != null)
            return;

        switch (_questGoal)
        {
            case (QuestGoalType.ClickCount):             
                gameObject.AddComponent<ClickCountGoal>();
                return;
            case (QuestGoalType.UpgradeLevel):
                gameObject.AddComponent<UpgradeLevelGoal>();
                return;
        }
    }

    private void Start()
    {
        QuestGoal = GetComponent<QuestGoal>();
    }

    private void Update()
    {
        if (QuestGoal.IsDone)
        {
            print("Quest Complete");
            QuestComplete?.Invoke();
            gameObject.SetActive(false);
        }

    }
}
