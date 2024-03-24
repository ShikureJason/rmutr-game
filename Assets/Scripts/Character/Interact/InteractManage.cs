using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManage : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReader = default;
    [Header("Event Emitter")]
    [SerializeField] private InteractEvent _interactEventEmitter = default;
    [Header("Event Listener")]
    [SerializeField] private TriggerDetectEvent _triggerDetectEventListener = default;

    private List<Interact> _interact = new List<Interact>();

    private void OnEnable()
    {
        _triggerDetectEventListener.OnEventRaised += OnDetectChange;
        _inputReader.InteractEvent += OnInteractButtonPress;
    }

    private void OnDisable()
    {
        _triggerDetectEventListener.OnEventRaised -= OnDetectChange;
        _inputReader.InteractEvent -= OnInteractButtonPress;
    }

    private void OnInteractButtonPress()
    {
        if (_interact.Count == 0)
        {
            return;
        }

        if (_interact[0].type == InteractType.Talk)
        {
            _interact[0].interactableObject.GetComponent<NonCharacter>().Interact();
        }
    }

    private void OnDetectChange(bool isDetect, GameObject obj)
    {
        if (isDetect)
        {
            AddInteraction(obj);
            Debug.Log("obj = " + obj);
        }
        else
        {
            RemoveInteraction(obj);
            Debug.Log("obj = " + obj);
        }
    }

    private void AddInteraction(GameObject obj)
    {
        Interact newInteract = new Interact(InteractType.None, obj);

        switch (obj.tag)
        {
            case "NPC":
                newInteract.type = InteractType.NPC;
                break;
            case "ItemPickup":
                newInteract.type = InteractType.ItemPickup;
                break;
            case "ItemColider":
                newInteract.type = InteractType.None;
                Destroy(obj);
                break;
            case "LocationPoint":
                newInteract.type = InteractType.None;
                newInteract.interactableObject.GetComponent<QuestFindLocationInterract>().QuestTrigger();
                break;
            default:
                newInteract.type = InteractType.None;
                break;
        }

        if (newInteract.type != InteractType.None)
        {
            _interact.Add(newInteract);
            _interactEventEmitter.OnEventRaised(_interact[0].type, true);
        }
    }

    private void RemoveInteraction(GameObject obj)
    {
        if (_interact.Count == 0)
            return;
        _interactEventEmitter.OnEventRaised(_interact[0].type, false);
        _interact.RemoveAll(interact => interact.interactableObject == obj);
    }
}
