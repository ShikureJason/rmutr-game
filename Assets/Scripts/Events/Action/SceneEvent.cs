using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SceneEvent", menuName = "Events/Action/Scene Event")]
public class SceneEvent : ScriptableObject
{
    public UnityAction<SceneSO> OnEventRaised;

    public void RaiseEvent(SceneSO data) => OnEventRaised?.Invoke(data);
}
