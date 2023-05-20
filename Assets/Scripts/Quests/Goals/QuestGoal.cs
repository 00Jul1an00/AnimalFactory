using UnityEngine;

[RequireComponent(typeof(Quest))]
public abstract class QuestGoal : MonoBehaviour
{
    [SerializeField] private double _requireProgres;
    
    private double _currentProgres;

    public abstract QuestGoalType GoalType { get; }

    public virtual double CurrentProgres { get { return _currentProgres; } protected set { _currentProgres = value; } }
    public virtual double RequireProgres { get { return _requireProgres; } protected set { _requireProgres = value; } }
    public bool IsDone { get { return CurrentProgres >= RequireProgres; } protected set { IsDone = value; } }

    private void Start()
    {
        double progress = SaveLoadSystem.Instance.LoadQuestProgress(this);

        if (progress != 0)
            CurrentProgres = progress;
    }
}
