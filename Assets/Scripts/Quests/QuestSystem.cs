using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    [SerializeField] private List<Quest> _quests = new();

    private BaseUpgrade[] _upgradesToCheck;
    private List<IReward> _possibleRewards = new();
    private int _currentQuestID;

    public ReadOnlyCollection<IReward> PossibleRewards;
    public ReadOnlyCollection<BaseUpgrade> UpgradesToCheck;
    public static QuestSystem Instance { get; private set; }

    private const int QUEST_LIST_OFFSET = 2;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }
    }

    private void Init()
    {
        _possibleRewards.Add(FindObjectOfType<DollarsLogic>());
        _possibleRewards.Add(FindObjectOfType<DiamondsLogic>());
        _possibleRewards.AddRange(FindObjectsOfType<CaseLogic>(true));
        PossibleRewards = new(_possibleRewards);
        _upgradesToCheck = FindObjectsOfType<BaseUpgrade>();
        UpgradesToCheck = new(_upgradesToCheck);
        FillUpQuestsList();
        ActivateCurrentQuests();
    }

    private void FillUpQuestsList()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var quest = transform.GetChild(i).GetComponent<Quest>();
            quest.QuestId = i;
            quest.gameObject.SetActive(false);
            _quests.Add(quest);
        }
    }

    private void ActivateCurrentQuests()
    {
        _currentQuestID = SaveLoadSystem.Instance.LoadCurrentQuestID();

        for(int i = _currentQuestID; i < _quests.Count && i <= _currentQuestID + QUEST_LIST_OFFSET; i++)
        {
            _quests[i].gameObject.SetActive(true);
        }
    }

    public void ActivateNextQuest()
    {
        SaveLoadSystem.Instance.RemoveQuestFromSaveList(_quests[_currentQuestID].QuestGoal);
        _currentQuestID++;
        SaveLoadSystem.Instance.SaveCurrentQuestID(_currentQuestID);

        if(_currentQuestID + QUEST_LIST_OFFSET < _quests.Count)
            _quests[_currentQuestID + QUEST_LIST_OFFSET].gameObject.SetActive(true);
    }
}
