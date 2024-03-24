using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private CharacterSO _character = default;
    [Header("Event Emitter")]
    [SerializeField] private ShowDialogueEvent _showDialogueEventEmitter = default;
    [SerializeField] private VoidEvent _endDialogueEventEmitter = default;
    [Header("Event Listener")]
    [SerializeField] private SendDialogueEvent _sendDialogueEventListener = default;

    private DialogueSO dialogue;
    private int currentLine = 0;
    private int currentDialogue = 0;

    private void OnEnable()
    {
        _sendDialogueEventListener.OnEventRaised += getDialogueData;
    }

    private void OnDisable()
    {
        _sendDialogueEventListener.OnEventRaised -= getDialogueData;
    }

    private void getDialogueData(DialogueSO dialogue)
    {
        this.dialogue = dialogue;
        currentLine = 0;
        currentDialogue = 0;
        nextDialogue();
    }

    private void nextDialogue()
    {
        if (dialogue == null)
            return;

        if (currentDialogue < dialogue.DialogueLine[currentLine].TextDialogue.Count) 
        {
            _showDialogueEventEmitter.RaiseEvent(dialogue.DialogueLine[currentLine].TextDialogue[currentDialogue], _character.CharacterDetail.Find(name => name.CharacterID == dialogue.DialogueLine[currentLine].CharacterID).CharacterName);                       
            currentDialogue++;
        }
        else if (currentLine < dialogue.DialogueLine.Count)
        {
            _showDialogueEventEmitter.RaiseEvent(dialogue.DialogueLine[currentLine].TextDialogue[currentDialogue], _character.CharacterDetail.Find(name => name.CharacterID == dialogue.DialogueLine[currentLine].CharacterID).CharacterName);
            currentLine++;
        }
        else
        {
            _endDialogueEventEmitter.RaiseEvent();
        }
        
    }

    private void showChoice()
    {

    }
}
