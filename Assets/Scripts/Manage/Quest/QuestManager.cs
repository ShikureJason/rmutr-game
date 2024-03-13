using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private List<QuestBaseSO> _questList;
    [Header("Event Emitter")]
    [SerializeField] private DialogueEvent _sendDialogueEventEmitter;

    [Header("Event Listener")]
    [SerializeField] private InteractQuestEvent _interactQuestEventListener;
    [SerializeField] private QuestEvent _questEventListener;

    [Header("Data")]
    [SerializeField] private List<QuestBaseSO> _currentQuest;
    private QuestBaseSO _quest;

    private void Awake()
    {
        if(_currentQuest == null)
        {
            _currentQuest.Add(_questList.Find(e => e.FirstQuest == true));
        }
    }

    private void characterGetQuest(String GUID, CharacterID id)
    {
        //_sendDialogueEventEmitter.RaiseEvent();
    }

    private void questfindLocation()
    {

    }
}
