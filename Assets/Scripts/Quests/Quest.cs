using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public enum QuestGoalType
{
    ClickCount,
    UpgradeLevel,
    MoneyCount,
}

public enum QuestReward
{
    Dollars,
    Diamonds,
    Case,
}

public class Quest : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private string _description;

    [SerializeField] private QuestReward _questRewardType;
    [SerializeField] private int _rewardValue;
    [SerializeField] private QuestGoalType _questGoal;

    public IReward QuestRewardType { get; private set; }
    public QuestGoal QuestGoal { get; private set; }
    public int QuestId { get; private set; }

    public event Action QuestComplete;

    private void OnValidate()
    {
        ValidateGoal();
    }

    private void ValidateGoal()
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
            case (QuestGoalType.MoneyCount):
                gameObject.AddComponent<MoneyCountGoal>();
                return;
        }
    }

    private void ValidateReward()
    {
        QuestRewardType = QuestSystem.Instance.PossibleRewards.Where(r => r.Reward == _questRewardType).First();
    }

    private void Start()
    {
        QuestGoal = GetComponent<QuestGoal>();
        ValidateReward();
    }

    private void Update()
    {
        if (QuestGoal.IsDone)
        {
            print("Quest Complete");
            QuestComplete?.Invoke();
            QuestRewardType.GiveReward(_rewardValue);
            gameObject.SetActive(false);
        }
    }
}
