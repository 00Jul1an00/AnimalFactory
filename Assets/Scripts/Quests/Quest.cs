using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum QuestType
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
    [SerializeField] private QuestReward _rewardType;
    [SerializeField] private QuestType _questType;
    //если передавать в rewardType кейсы или предметы, нужно передовать в rewardValue id предмета
    [SerializeField] private int _rewardValue;
    [SerializeField] private string _description;
    public QuestReward RewardType { get { return _rewardType; } protected set { _rewardType = value; } }
    public bool IsComplete { get; protected set; }
    public int QuestId { get; protected set; }

    public event Action QuestComplete;
    public delegate Func<bool> QuestPredicate();

    private void Init() 
    {

    }

    public virtual void Complete()
    {
        QuestComplete?.Invoke();
        IsComplete = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
        }
    }
}
