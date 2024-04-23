using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "StartDialogueEvent", menuName = "Events/Action/Send Dialogue")]
public class SendDialogueEvent : ScriptableObject
{
    public UnityAction<DialogueSO> OnEventRaised;

    public void RaiseEvent(DialogueSO dialogue) => OnEventRaised?.Invoke(dialogue);
}
