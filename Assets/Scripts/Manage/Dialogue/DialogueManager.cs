using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private CharacterSO _character;
    [Header("Event Emitter")]
    [SerializeField] private ShowDialogueEvent _showDialogueEmitter;
    [Header("Event Listener")]
    [SerializeField] private GenericEvent<DialogueSO> _sendDialogueListener;

    private DialogueSO dialogue;
    private int currentLine = 0;
    private int currentDialogue = 0;

    private void OnEnable()
    {
        _sendDialogueListener.OnEventRaised += getDialogueData;
    }

    private void OnDisable()
    {
        _sendDialogueListener.OnEventRaised -= getDialogueData;
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
        if (currentDialogue < dialogue.DialogueLine[currentLine].TextDialogue.Count) {
            _showDialogueEmitter.RaiseEvent(dialogue.DialogueLine[currentLine].TextDialogue[currentDialogue], _character.CharacterDetail.Find(name => name.CharacterID == dialogue.DialogueLine[currentLine].CharacterID));
            currentDialogue++;
        }else if (currentLine < dialogue.DialogueLine.Count)
        {
            _showDialogueEmitter.RaiseEvent(dialogue.DialogueLine[currentLine].TextDialogue[currentDialogue], _character.CharacterDetail.Find(name => name.CharacterID == dialogue.DialogueLine[currentLine].CharacterID));
            currentLine++;
        }
        
    }

    private void showChoice()
    {

    }
}
