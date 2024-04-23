using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "LoadSceneEvent", menuName = "Events/Action/LoadScene")]
public class LoadSceneEvent : ScriptableObject
{
    public UnityAction<SceneSO> OnEventRaised;

    public void RaiseEvent(SceneSO scene)
    {
        Debug.Log("Init...");
        if (OnEventRaised == null)
            Debug.Log("NULL");
        OnEventRaised?.Invoke(scene);
    }
}
