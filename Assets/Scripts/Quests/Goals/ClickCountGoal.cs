using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCountGoal : QuestGoal
{
    private ClickTracker _clickTracker;
    public override bool IsDone { get { return _clickTracker.ClickCount >= RequireProgres; } protected set => base.IsDone = value; }
}
