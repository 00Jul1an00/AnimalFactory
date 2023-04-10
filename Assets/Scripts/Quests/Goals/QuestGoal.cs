using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Quest))]
public abstract class QuestGoal : MonoBehaviour
{
    [SerializeField] private int _requireProgres;
    
    private int _currentProgres;

    public virtual int CurrentProgres { get { return _currentProgres; } protected set { _currentProgres = value; } }
    public virtual int RequireProgres { get { return _requireProgres; } protected set { _requireProgres = value; } }
    public bool IsDone { get { return CurrentProgres >= RequireProgres; } protected set { IsDone = value; } }
}
