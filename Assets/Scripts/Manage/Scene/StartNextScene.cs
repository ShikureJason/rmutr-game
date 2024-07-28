using UnityEngine;

public class StartNextScene : MonoBehaviour
{
    [SerializeField] private SceneSO _startNextScene;

    [Header("Event Emitter")]
    [SerializeField] private SceneEvent _loadSceneEventEmitter;

    [Header("Event Listener")]
    [SerializeField] private VoidEvent _startNextSceneListener;

    private void OnEnable()
    {
        _startNextSceneListener.OnEventRaised += LoadSceneEvent;
    }
    private void OnDisable()
    {
        _startNextSceneListener.OnEventRaised -= LoadSceneEvent;
    }
    private void LoadSceneEvent()
    {
        Debug.Log("Next");
        GameData.Instance.CurrentSave.CurrentScene = _startNextScene;
        _loadSceneEventEmitter.RaiseEvent(_startNextScene);
    }
}
