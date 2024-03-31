using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New QuestData", menuName = "Quests/Create Quest")]
public class QuestSO : BaseScriptableObject
{
    public readonly string GUID = Guid.NewGuid().ToString();

    [SerializeField] private CharacterID _characterID;
    [SerializeField] private RewardItemSO _rewardItem;
    [SerializeField] private QuestStatus _questStatus;
    [SerializeField] private QuestType _questType;
    [SerializeField] private DialogueSO _dialogue;
    [SerializeField] private QuestSO _defaultDialogue;
    [SerializeField] private List<ItemSO> _item;
    [SerializeField] List<ChoiceDetail> _choiceDetail;
    [SerializeField] private QuestSO _condition;
    [SerializeField] private QuestSO _nextQuest;
    [SerializeField] private bool _firstQuest;

    public CharacterID CharacterID => _characterID;
    public RewardItemSO RewardItem => _rewardItem;
    public QuestType QuestType => _questType;
    public DialogueSO Dialogue => _dialogue;
    public QuestSO DefaultDialogue => _defaultDialogue;
    public List<ItemSO > Item => _item;
    public List<ChoiceDetail> Choices => _choiceDetail;
    public QuestSO Condition => _condition;
    public QuestSO NextQuest => _nextQuest;
    public bool FirstQuest => _firstQuest;
    public QuestStatus QuestStatus
    {
        get { return _questStatus; }
        set { _questStatus = value; }
    }
}
