public class MoneyCountGoal : QuestGoal
{
    private DollarsLogic _dollarsLogic;
    public override double CurrentProgres { get => _dollarsLogic.CurrencyCount; protected set => base.CurrentProgres = value; }
    public override QuestGoalType GoalType => QuestGoalType.MoneyCount;

    private void Start()
    {
        _dollarsLogic = FindObjectOfType<DollarsLogic>();
    }
}
