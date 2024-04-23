using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class Initializer : MonoBehaviour
{
    [SerializeField] private SceneSO _mangeScene;
    [SerializeField] private SceneSO _loadNextScene;

    [Header("Event Emitter")]
    [SerializeField] private SceneEvent _loadSceneEventEmitter;

    [Header("Event Listener")]
    [SerializeField] private VoidEvent _initailizeManageFinsihEventListener = default;

    private void OnEnable()
    {
        _initailizeManageFinsihEventListener.OnEventRaised += LoadSceneFinish;
    }
    private void OnDisable()
    {
        _initailizeManageFinsihEventListener.OnEventRaised -= LoadSceneFinish;
    }
    private void Start()
    {
        _mangeScene.Scene.LoadSceneAsync(LoadSceneMode.Additive, true).Completed += LoadSceneEvent;
    }

    private void LoadSceneEvent(AsyncOperationHandle<SceneInstance> obj)
    {
        SceneManager.UnloadSceneAsync(0);
    }

    private void LoadSceneFinish()
    {
        _loadSceneEventEmitter.RaiseEvent(_loadNextScene);
        Debug.Log("Send");
    }
}
