using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "DialogueEvent", menuName = "Events/Action/Dialogue Event")]
public class DialogueEvent : ScriptableObject
{
    public UnityAction<DialogueSO> OnEventRaised;

    public void RaiseEvent(DialogueSO data) => OnEventRaised?.Invoke(data);
}
