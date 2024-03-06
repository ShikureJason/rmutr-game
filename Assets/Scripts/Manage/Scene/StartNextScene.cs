using UnityEngine;

public class StartNextScene : MonoBehaviour
{
    [SerializeField] private SceneSO _startNextScene;

    [Header("Event Emitter")]
    [SerializeField] private SceneEvent _loadSceneEventEmitter;

    [Header("Event Listener")]
    [SerializeField] private VoidEvent _startNextSceneEmitter;

    private void OnEnable()
    {
        _startNextSceneEmitter.OnEventRaised += LoadSceneEvent;
    }
    private void OnDisable()
    {
        _startNextSceneEmitter.OnEventRaised -= LoadSceneEvent;
    }
    private void LoadSceneEvent()
    {
        _loadSceneEventEmitter.RaiseEvent(_startNextScene);
    }
}
