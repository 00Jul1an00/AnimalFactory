using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCountGoal : QuestGoal
{
    private DollarsLogic _dollarsLogic;
    public override int CurrentProgres { get => _dollarsLogic.CurrencyCount; protected set => base.CurrentProgres = value; }

    private void Start()
    {
        _dollarsLogic = FindObjectOfType<DollarsLogic>();
    }
}
