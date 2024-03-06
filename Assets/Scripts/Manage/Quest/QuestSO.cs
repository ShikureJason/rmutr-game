using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New QuestData", menuName = "Quests/Create Quest")]
public class QuestSO : ScriptableObject
{
    public readonly string GUID = Guid.NewGuid().ToString();

    [SerializeField] private DialogueSO _dialogue;
    [SerializeField] private RewardItemSO _rewardItem;
    [SerializeField] private QuestStatus _questStatus;
    [SerializeField] private QuestType _questType;
    [SerializeField] private QuestSO _condition;
    [SerializeField] private QuestSO _nextQuest;

    public DialogueSO Dialogue => _dialogue;
    public RewardItemSO RewardItem => _rewardItem;
    public QuestType QuestType => _questType;
    public QuestSO Condition => _condition;
    public QuestSO NextQuest => _nextQuest;
    public QuestStatus QuestStatus
    { 
        get { return _questStatus; }
        set { _questStatus = value; }
    }
}
