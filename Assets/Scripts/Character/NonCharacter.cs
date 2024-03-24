using UnityEngine;

public class NonCharacter : MonoBehaviour
{
    [SerializeField] private CharacterID _characterID = default;

    [Header("Event Emitter")]
    [SerializeField] private CharacterEvent _interactQuestEventEmitter = default;

    public void Interact()
    {
        _interactQuestEventEmitter.RaiseEvent(_characterID);
    }

}
