using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCountGoal : QuestGoal
{
    private ClickTracker _clickTracker;

    private int _clickCount;
    public override int CurrentProgres { get => _clickCount; protected set => _clickCount = value; }
    public override bool IsDone { get { return _clickCount >= RequireProgres; } protected set => base.IsDone = value; }

    private void Start()
    {
        _clickTracker = FindObjectOfType<ClickTracker>();
        _clickTracker.Clicked += OnClicked;
    }

    private void OnClicked()
    {
        _clickCount++;
    }
}