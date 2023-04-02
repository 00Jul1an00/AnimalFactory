using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum QuestGoalType
{
    ClickCount,
    UpgradeLvl,
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

    [SerializeField] private IReward _rewardType;
    [SerializeField] private QuestGoal _questGoal;
    public IReward RewardType { get { return _rewardType; } private set { _rewardType = value; } }
    public QuestGoal QuestGoal { get { return _questGoal; } private set { _questGoal = value; } }
    public int QuestId { get; protected set; }

    public event Action QuestComplete;

    private void Init() 
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
        }
    }
}
