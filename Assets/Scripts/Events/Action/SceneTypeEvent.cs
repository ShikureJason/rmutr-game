using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SceneTypeEvent", menuName = "Events/Action/Scene Type Event")]
public class SceneTypeEvent : ScriptableObject
{
    public UnityAction<SceneType> OnEventRaised;

    public void RaiseEvent(SceneType data) => OnEventRaised?.Invoke(data);
}
