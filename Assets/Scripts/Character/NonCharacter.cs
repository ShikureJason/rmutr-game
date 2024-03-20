using UnityEngine;

public class NonCharacter : MonoBehaviour
{
    [SerializeField] private CharacterID _characterID;

    [Header("Event Emitter")]
    [SerializeField] private CharacterEvent _interactQuestEventEmitter;

    public void Interact()
    {
        _interactQuestEventEmitter.RaiseEvent(_characterID);
    }
}
