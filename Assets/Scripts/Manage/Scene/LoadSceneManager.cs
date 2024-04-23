using System.Collections;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    [Header("Event Emitter")]
    [SerializeField] private BoolEvent _loadingScreenEventEmitter;
    [SerializeField] private VoidEvent _sceneHasLoadedEventEmitter;
    [Header("Event Listener")]
    [SerializeField] private SceneEvent loadSceneEventListener;
    [SerializeField] private SceneEvent loadSceneEditEventListener;

    private AsyncOperationHandle<SceneInstance> loadingOperationHandle;
    private SceneSO currentLoadedScene;
    private SceneSO loadScene;
    private bool isLoading = false;
    private float waitTime = 5f;

    private void OnEnable()
    {
        loadSceneEventListener.OnEventRaised += LoadScene;
#if UNITY_EDITOR
        loadSceneEditEventListener.OnEventRaised += LoadSceneEdit;
#endif

    }

    private void OnDisable()
    {
        loadSceneEventListener.OnEventRaised -= LoadScene;
#if UNITY_EDITOR
        loadSceneEditEventListener.OnEventRaised -= LoadSceneEdit;
#endif
    }

#if UNITY_EDITOR
    private void LoadSceneEdit(SceneSO sceneRef)
    {
        currentLoadedScene = sceneRef;
        _sceneHasLoadedEventEmitter.RaiseEvent();
    }
#endif

    private void LoadScene(SceneSO sceneRef)
    {
        Debug.Log("Load");
        if (isLoading)
            return;
        isLoading = true;
        loadScene = sceneRef;
        if (currentLoadedScene != null) //would be null if the game was started in Initialisation
        {
            if (currentLoadedScene.Scene.OperationHandle.IsValid())
            {
                //Unload the scene through its AssetReference, i.e. through the Addressable system
                currentLoadedScene.Scene.UnLoadScene();
            }
#if UNITY_EDITOR
            else
            {
                SceneManager.UnloadSceneAsync(currentLoadedScene.Scene.editorAsset.name);
            }
#endif
        }
        _loadingScreenEventEmitter.RaiseEvent(true);
        loadingOperationHandle = loadScene.Scene.LoadSceneAsync(LoadSceneMode.Additive, true, 5);
        loadingOperationHandle.Completed += OnNewSceneLoaded;
    }

    private void OnNewSceneLoaded(AsyncOperationHandle<SceneInstance> obj)
    {
        currentLoadedScene = loadScene;

        Scene s = obj.Result.Scene;
        SceneManager.SetActiveScene(s);
        LightProbes.TetrahedralizeAsync();
        StartCoroutine(DelayLoadScene());
    }

    private IEnumerator DelayLoadScene()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        isLoading = false;
        _loadingScreenEventEmitter.RaiseEvent(false);
        _sceneHasLoadedEventEmitter.RaiseEvent();
    }
}
