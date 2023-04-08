using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    [SerializeField] private List<Quest> _quests = new();
    
    private List<IReward> _possibleRewards = new();

    public ReadOnlyCollection<IReward> PossibleRewards;
    public static QuestSystem Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Init();
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Init()
    {
        _possibleRewards.Add(FindObjectOfType<DollarsLogic>());
        _possibleRewards.Add(FindObjectOfType<DiamondsLogic>());

        PossibleRewards = new(_possibleRewards);
    }
}
