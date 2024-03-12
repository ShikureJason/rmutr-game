using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "LoadSceneEvent", menuName = "Events/LoadScene")]
public class LoadSceneEvent : ScriptableObject
{
    public UnityAction<SceneSO> OnEventRaised;

    public void RaiseEvent(SceneSO scene) => OnEventRaised?.Invoke(scene);
}
