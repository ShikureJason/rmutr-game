using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private List<QuestList> _questList = default;
    [Header("Event Emitter")]
    [SerializeField] private SendDialogueEvent _sendDialogueEventEmitter = default;
    [SerializeField] private CharacterEvent _characterHasQuestEmitter = default;

    [Header("Event Listener")]
    [SerializeField] private CharacterEvent _interactQuestEventListener = default;
    [SerializeField] private StringEvent _questGUIDEventListener = default;
    [SerializeField] private VoidEvent _endDialogueEventListener = default;

    [Header("Data")]
    [SerializeField] private List<QuestSO> _currentQuest = default;
    [SerializeField] private List<QuestSO> _defaultDialogue = default;

    private QuestSO runningQuest;

    private void OnEnable()
    {
        _endDialogueEventListener.OnEventRaised += dialogueEnd;
        _questGUIDEventListener.OnEventRaised += questfindLocation;
        _interactQuestEventListener.OnEventRaised += characterGetQuest;
    }
    private void OnDisable()
    { 
        _endDialogueEventListener.OnEventRaised -= dialogueEnd;
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
        if (runningQuest)
            return;

        runningQuest = _currentQuest.Find(o => o.CharacterID == id);
        if (runningQuest)
        {
            switch (runningQuest.QuestType)
            {
                case QuestType.Talk:
                    _sendDialogueEventEmitter.RaiseEvent(runningQuest.Dialogue);
                    break;
            }
        }
        else
        {
            _sendDialogueEventEmitter.RaiseEvent(_defaultDialogue.Find(o => o.CharacterID == id).Dialogue);
        }
    }

    private void dialogueEnd()
    {
        if (!runningQuest)
            return;
        questFinish(runningQuest, runningQuest.NextQuest);
    }

    private void questfindLocation(string guid)
    {
          if (runningQuest)
            return;

        runningQuest = _currentQuest.Find(o => o.GUID == guid);
        if (runningQuest)
        {
            if (runningQuest.Dialogue)
            {
                _sendDialogueEventEmitter.RaiseEvent(runningQuest.Dialogue);
            }
            else if (runningQuest.NextQuest)
            {
                questFinish(runningQuest, runningQuest.NextQuest);
            }
        }
    }

    private void questFinish(QuestSO finishQuest, QuestSO nextQuest)
    {
        runningQuest = null;
        finishQuest.QuestStatus = QuestStatus.Complete;
        _currentQuest.Remove(finishQuest);
        _currentQuest.Add(nextQuest);
        if(nextQuest.DefaultDialogue)
        {
            _defaultDialogue.Add(nextQuest.DefaultDialogue);
            if (_defaultDialogue.Find(o => o.CharacterID == finishQuest.CharacterID))
            {
                _defaultDialogue.Remove(_defaultDialogue.Find(o => o.CharacterID == finishQuest.CharacterID));
            }
        }

        nextQuest.QuestStatus = QuestStatus.Running;

        if (nextQuest.CharacterID != CharacterID.None)
        {
            _characterHasQuestEmitter.RaiseEvent(nextQuest.CharacterID);
        }
    }
}
