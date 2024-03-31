using UnityEngine;

public class ZoneTriggerDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask = default;
    [Header("Event Emitter")]
    [SerializeField] private TriggerDetectEvent _triggerDetectEventEmitter = default;


    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _layerMask) != 0)
        {
            _triggerDetectEventEmitter.RaiseEvent(true, other.gameObject);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (((1 << other.gameObject.layer) & _layerMask) != 0)
        {
            _triggerDetectEventEmitter.RaiseEvent(false, other.gameObject);
            
        }
    }
}
