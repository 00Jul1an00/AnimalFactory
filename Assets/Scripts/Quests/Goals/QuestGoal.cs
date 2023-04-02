using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestGoal : MonoBehaviour
{
    [SerializeField] private int _currentProgres;
    [SerializeField] private int _requireProgres;

    public virtual int CurrentProgres { get { return _currentProgres; } protected set { _currentProgres = value; } }
    public virtual int RequireProgres { get { return _requireProgres; } protected set { _requireProgres = value; } }
    public virtual bool IsDone { get { return CurrentProgres >= RequireProgres; } protected set { IsDone = value; } }

    public abstract void Complete();
}
