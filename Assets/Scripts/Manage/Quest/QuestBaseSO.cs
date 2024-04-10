using System;
using System.Collections.Generic;
using System.ComponentModel;
using RMUTR.Quest;
using UnityEngine;

public class QuestBaseSO : ScriptableObject, IQuest
{
    public readonly string GUID = Guid.NewGuid().ToString();
    [SerializeField] private CharacterID _characterID = default;
    [SerializeField] private List<RewardItemSO> _rewardItem = default;
    [SerializeField] private QuestStatus _questStatus = QuestStatus.NotStart;
    [SerializeField] private QuestType _questType = default;
    [SerializeField] private QuestList _condition = default;
    [SerializeField] private QuestList _nextQuest = default;
    [SerializeField] private bool _firstQuest = default;

    public CharacterID CharacterID => _characterID;
    public List<RewardItemSO> RewardItem => _rewardItem;
    public QuestList Condition => _condition;
    public QuestList NextQuest => _nextQuest;
    public bool FirstQuest => _firstQuest;
    public QuestType QuestType { 
        get { return _questType; } 
        set { _questType = value; }
    }
    public QuestStatus QuestStatus {
        get { return _questStatus; }
        set { _questStatus = value; }
    }
}
