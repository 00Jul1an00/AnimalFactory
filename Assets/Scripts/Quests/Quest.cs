using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum QuestReward
{
    Money,
    Diamonds,
    Case,
}

public class Quest : MonoBehaviour
{
    [SerializeField] private QuestReward _rewardType;
    //если передавать в rewardType кейсы или предметы, нужно передовать в rewardValue id предмета
    [SerializeField] private int _rewardValue;

    public QuestReward RewardType { get { return _rewardType; } protected set { _rewardType = value; } }
    public bool IsComplete { get; protected set; }
    public int QuestId { get; protected set; }

    public event Action QuestComplete;

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
            print(_rewardType);
            print(_rewardValue);
        }
    }
}
