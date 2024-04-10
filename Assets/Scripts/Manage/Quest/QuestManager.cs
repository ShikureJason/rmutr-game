using System.Collections.Generic;
using RMUTR.Quest;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private List<QuestList> _questList = default;
    [Header("Event Emitter")]
    [SerializeField] private SendDialogueEvent _sendDialogueEventEmitter = default;
    [SerializeField] private CharacterEvent _characterHasQuestEmitter = default;

    [Header("Event Listener")]
    [SerializeField] private CharacterEvent _interactQuestEventListener = default;
    [SerializeField] private QuestEvent _questEventListener = default;
    [SerializeField] private VoidEvent _endDialogueEventListener = default;

    [Header("Data")]
    [SerializeField] private List<QuestBaseSO> _currentQuest = default;
    [SerializeField] private List<QuestDialogue> _defaultDialogue = default;

    private QuestBaseSO runningQuest;

    private void OnEnable()
    {
        _endDialogueEventListener.OnEventRaised += dialogueEnd;
        _questEventListener.OnEventRaised += getQuest;
        _interactQuestEventListener.OnEventRaised += characterGetQuest;
    }
    private void OnDisable()
    { 
        _endDialogueEventListener.OnEventRaised -= dialogueEnd;
        _questEventListener.OnEventRaised -= getQuest;
        _interactQuestEventListener.OnEventRaised -= characterGetQuest;
    }

    private void Start()
    {
        if(_currentQuest.Count == 0)
        {
            int indexQuestList = _questList.FindIndex(o => o.List.Find(o => o.FirstQuest == true));
            int indexList = _questList[indexQuestList].List.FindIndex(o => o.FirstQuest == true);

            QuestBaseSO _quest = _questList[indexQuestList].List[indexList];
            _quest.QuestStatus = QuestStatus.Running;
            _currentQuest.Add(_quest);
        }
    }

    private void getQuest(QuestBaseSO quest)
    {
        if (runningQuest is QuestFindLocation )
        {
            questfindLocation((QuestFindLocation)quest);
        }
    }

    private void characterGetQuest(CharacterID id)
    {
        if (runningQuest)
            return;

        runningQuest = _currentQuest.Find(o => o.CharacterID == id);
        if (runningQuest)
        {
            if (runningQuest is QuestDialogue)
            {
                var questDialogue = (QuestDialogue)runningQuest;
                _sendDialogueEventEmitter.RaiseEvent(questDialogue.Dialogue);
                return;
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

    private void questfindLocation(QuestFindLocation quest)
    {
          if (runningQuest)
            return;

        runningQuest = _currentQuest.Find(o => o.GUID == quest.GUID);
        if (runningQuest)
        {
            QuestDialogue hasDialogue = (QuestDialogue)quest.NextQuest.List.Find(o => o.QuestType == QuestType.Dialogue);
            if (hasDialogue)
            {
                _sendDialogueEventEmitter.RaiseEvent(hasDialogue.Dialogue);
            }
            else if (runningQuest.NextQuest)
            {
                questFinish(runningQuest, runningQuest.NextQuest);
            }
        }
    }

    private void questFinish(QuestBaseSO finishQuest, QuestList nextQuest)
    {
        runningQuest = null;
        finishQuest.QuestStatus = QuestStatus.Complete;
        _currentQuest.Remove(finishQuest);
        
        if (nextQuest != null)
        {
            for (int i = 0; i <= nextQuest.List.Count; i++) 
            {
                nextQuest.List[i].QuestStatus = QuestStatus.Running;
                if (nextQuest.List[i].QuestType == QuestType.DefaultDialogue)
                {
                    _defaultDialogue.Add((QuestDialogue)nextQuest.List[i]);
                    QuestDialogue hasDefaultDialogue = _defaultDialogue.Find(o => o.CharacterID == finishQuest.CharacterID);
                    if (hasDefaultDialogue)
                    {
                        hasDefaultDialogue.QuestStatus = QuestStatus.Complete;
                        _defaultDialogue.Remove(_defaultDialogue.Find(o => o.CharacterID == finishQuest.CharacterID));
                    }
                    return;
                }
                _currentQuest.Add(nextQuest.List[i]);
            }
        }

        /*if(nextQuest.DefaultDialogue)
        {
            _defaultDialogue.Add(nextQuest.DefaultDialogue);
            if (_defaultDialogue.Find(o => o.CharacterID == finishQuest.CharacterID))
            {
                _defaultDialogue.Remove(_defaultDialogue.Find(o => o.CharacterID == finishQuest.CharacterID));
            }
        }

        if (nextQuest.CharacterID != CharacterID.None)
        {
            _characterHasQuestEmitter.RaiseEvent(nextQuest.CharacterID);
        }*/
    }
}
