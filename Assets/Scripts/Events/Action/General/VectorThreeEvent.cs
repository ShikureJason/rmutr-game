using UnityEngine;
using UnityEngine.Events;

public class VectorThreeEvent : MonoBehaviour
{
    public UnityAction<Vector3> OnEventRaised;

    public void RaisedEvent(Vector3 vector) => OnEventRaised?.Invoke(vector);
}
