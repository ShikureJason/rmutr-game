using UnityEngine;

public class NonCharacter : MonoBehaviour
{
    [SerializeField] private CharacterID _characterID;

    [Header("Event Emitter")]
    [SerializeField] private InteractQuestEvent _interactQuestEventEmitter;

    public void Interact()
    {
        _interactQuestEventEmitter.RaiseEvent(_characterID);
    }
}
