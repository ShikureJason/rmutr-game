using System;
using UnityEngine;

public class QuestBaseSO : ScriptableObject
{
    public readonly string GUID = Guid.NewGuid().ToString();

    [SerializeField] private CharacterID _characterID;
    [SerializeField] private RewardItemSO _rewardItem;
    [SerializeField] private QuestStatus _questStatus;
    [SerializeField] private QuestType _questType;
    [SerializeField] private QuestBaseSO _condition;
    [SerializeField] private QuestBaseSO _nextQuest;
    [SerializeField] private bool _firstQuest;

    public CharacterID CharacterID => _characterID;
    public RewardItemSO RewardItem => _rewardItem;
    public QuestType QuestType => _questType;
    public QuestBaseSO Condition => _condition;
    public QuestBaseSO NextQuest => _nextQuest;
    public bool FirstQuest => _firstQuest;
    public QuestStatus QuestStatus
    {
        get { return _questStatus; }
        set { _questStatus = value; }
    }
}
