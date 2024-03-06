using UnityEngine;

public class ZoneTriggerDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask = default;
    [Header("Event Emitter")]
    [SerializeField] private TriggerDetectEvent _triggerDetectEvent = default;


    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _layerMask) != 0)
        {
            _triggerDetectEvent.RaiseEvent(true, other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (((1 << other.gameObject.layer) & _layerMask) != 0)
        {
            _triggerDetectEvent.RaiseEvent(false, other.gameObject);
        }
    }
}
