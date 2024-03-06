using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private List<QuestList> _questCharacterList;
    [Header("Event Emitter")]
    [SerializeField] private DialogueEvent _sendDialogueEventEmitter;

    [Header("Event Listener")]
    [SerializeField] private InteractQuestEvent _interactQuestEventListener;

    [Header("Data")]
    [SerializeField] private List<QuestSO> CurrentQuest;
    private QuestSO _quest;

    private void Awake()
    {



    }

    private void characterGetQuest(String GUID, CharacterID id)
    {
        _quest = _questCharacterList.Find(name => name.CharacterID == id).List.Find(id => id.GUID == GUID);
        //_sendDialogueEventEmitter.RaiseEvent();
    }
}
