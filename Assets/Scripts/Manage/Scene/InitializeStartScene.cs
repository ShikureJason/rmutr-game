using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class InitializeStartScene : MonoBehaviour
{
    [SerializeField] private SceneSO _localScene;
#if UNITY_EDITOR
    [SerializeField] private SceneSO _gameManageScene;

    [Header("Event Emitter")]
    [SerializeField] private SceneEvent _loadSceneEventEditorEmitter;
#endif
    [SerializeField] private VoidEvent _initializeStartSceneHasLoadedEmitter;
    [SerializeField] private SceneTypeEvent _switchInputEventEmitter;

    [Header("Event Listener")]
    [SerializeField] private VoidEvent _sceneHasLoadedEventListener = default;

    private bool _sceneManageHasLoaded = false;

    private void OnEnable()
    {
        _sceneHasLoadedEventListener.OnEventRaised += initializedStart;
    }

    private void OnDisable()
    {
        _sceneHasLoadedEventListener.OnEventRaised -= initializedStart;
    }

#if UNITY_EDITOR
    private void Start()
    {
        _gameManageScene.Scene.LoadSceneAsync(LoadSceneMode.Additive, true).Completed += LoadSceneEvent;
    }
#endif

    private void initializedStart()
    {
        _initializeStartSceneHasLoadedEmitter.RaiseEvent();
        _switchInputEventEmitter.RaiseEvent(_localScene.SceneType);
    }

    private void LoadSceneEvent(AsyncOperationHandle<SceneInstance> obj)
    {
        _loadSceneEventEditorEmitter.RaiseEvent(_localScene);
    }

    private void onStart()
    {
        _switchInputEventEmitter.RaiseEvent(_localScene.SceneType);
    }

}
