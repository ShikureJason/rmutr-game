using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private List<QuestList> _questList;
    [Header("Event Emitter")]
    [SerializeField] private DialogueEvent _sendDialogueEventEmitter;

    [Header("Event Listener")]
    [SerializeField] private CharacterEvent _interactQuestEventListener;
    [SerializeField] private StringEvent _questGUIDEventListener;
    [SerializeField] private VoidEvent _endDialogueEventListener;

    [Header("Data")]
    [SerializeField] private List<QuestSO> _currentQuest;
    private QuestSO runningQuest;

    private void OnEnable()
    {
        _questGUIDEventListener.OnEventRaised += questfindLocation;
        _interactQuestEventListener.OnEventRaised += characterGetQuest;
    }
    private void OnDisable()
    {
        _questGUIDEventListener.OnEventRaised -= questfindLocation;
        _interactQuestEventListener.OnEventRaised -= characterGetQuest;
    }

    private void Awake()
    {
        if(_currentQuest.Count == 0)
        {
            int indexQuestList = _questList.FindIndex(o => o.List.Find(o => o.FirstQuest == true));
            int indexList = _questList[indexQuestList].List.FindIndex(o => o.FirstQuest == true);

            QuestSO _quest = _questList[indexQuestList].List[indexList];
            _quest.QuestStatus = QuestStatus.Running;
            _currentQuest.Add(_quest);
        }
    }

    private void characterGetQuest(CharacterID id)
    {
        QuestSO npcTalk = _currentQuest.Find(o => o.CharacterID == id);
        if (npcTalk)
        {
            Debug.Log("NPCTALK");
        }
    }

    private void endDialogueQuest()
    {
        _currentQuest.Add(runningQuest.NextQuest);
        runningQuest = null;
    }

    private void questfindLocation(string guid)
    {
        QuestSO location = _currentQuest.Find(o => o.GUID == guid);
        if (location)
        {
            if (location.NextQuest)
            {
                runningQuest = location;
                _currentQuest.Remove(location);
                location.QuestStatus = QuestStatus.Complete;
                _currentQuest.Add(location.NextQuest);
                location.NextQuest.QuestStatus = QuestStatus.Running;
            }
        }
    }
}
