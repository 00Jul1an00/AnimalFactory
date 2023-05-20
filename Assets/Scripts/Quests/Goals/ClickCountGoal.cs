public class ClickCountGoal : QuestGoal
{
    private ClickTracker _clickTracker;

    private double _clickCount;
    public override double CurrentProgres { get => _clickCount; protected set => _clickCount = value; }
    public override QuestGoalType GoalType => QuestGoalType.ClickCount;

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
