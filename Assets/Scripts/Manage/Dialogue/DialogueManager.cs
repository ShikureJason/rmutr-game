using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private CharacterSO _character = default;
    [SerializeField] private InputReaderSO _inputReader = default;
    [Header("Event Emitter")]
    [SerializeField] private ShowDialogueEvent _showDialogueWithNameEventEmitter = default;
    [SerializeField] private ObjLocalizeStringEvent _showDialogueWithoutNameEventEmitter = default;
    [SerializeField] private BoolEvent _dialogueEventEmitter = default;
    [SerializeField] private VoidEvent _endDialogueEventEmitter = default;
    [Header("Event Listener")]
    [SerializeField] private SendDialogueEvent _sendDialogueEventListener = default;

    private DialogueSO dialogue;
    private int currentLine = 0;
    private int currentDialogue = 0;

    private void OnEnable()
    {
        _sendDialogueEventListener.OnEventRaised += getDialogueData;
        _inputReader.NextDialogueEvent += nextDialogue;
    }

    private void OnDisable()
    {
        _sendDialogueEventListener.OnEventRaised -= getDialogueData;
        _inputReader.NextDialogueEvent -= nextDialogue;
    }

    private void getDialogueData(DialogueSO dialogue)
    {
        Debug.Log("Start");
        this.dialogue = dialogue;
        currentLine = 0;
        currentDialogue = 0;
        _dialogueEventEmitter.RaiseEvent(true);
        nextDialogue();
    }

    private void nextDialogue()
    {
        if (dialogue == null)
            return;

        Debug.Log(dialogue.DialogueLine.Count);
        if (currentDialogue < dialogue.DialogueLine[currentLine].TextDialogue.Count) 
        {
            if (dialogue.DialogueLine[currentLine].CharacterID == CharacterID.None)
            {
                _showDialogueWithoutNameEventEmitter.RaiseEvent(dialogue.DialogueLine[currentLine].TextDialogue[currentDialogue]);
            }
            else
            {
                _showDialogueWithNameEventEmitter.RaiseEvent(dialogue.DialogueLine[currentLine].TextDialogue[currentDialogue],
                                              _character.CharacterDetail.Find(name => name.CharacterID == dialogue.DialogueLine[currentLine].CharacterID).CharacterName);
            }
         
            currentDialogue++;
        }
        else if (currentLine < dialogue.DialogueLine.Count-1)
        {
            currentLine++;
            currentDialogue = 0;
            nextDialogue();
            //_showDialogueEventEmitter.RaiseEvent(dialogue.DialogueLine[currentLine].TextDialogue[currentDialogue], _character.CharacterDetail.Find(name => name.CharacterID == dialogue.DialogueLine[currentLine].CharacterID).CharacterName);
        }
        else
        {
            _endDialogueEventEmitter.RaiseEvent();
            _dialogueEventEmitter.RaiseEvent(false);
        }
        
    }

    private void showChoice()
    {

    }
}
