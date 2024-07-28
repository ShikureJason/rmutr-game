using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    internal static LoadSceneManager Instance;

    [Header("Event Emitter")]
    [SerializeField] private BoolEvent _loadingScreenEventEmitter;
    [SerializeField] private VoidEvent _sceneHasLoadedEventEmitter;
    [SerializeField] private SceneTypeEvent _switchInputEventEmitter;
    [SerializeField] private VoidEvent _sceneReadyEventEmitter;
    [SerializeField] private VoidEvent _startInitlizeSceneEventEmitter;

    [Header("Event Listener")]
    [SerializeField] private SceneEvent _loadSceneEventListener;
    [SerializeField] private SceneEvent _loadSceneEditEventListener;
    [SerializeField] private VoidEvent _initializeStartSceneHasLoadedListener;
    [SerializeField] private VoidEvent _introHasFinishListener;

    private AsyncOperationHandle<SceneInstance> loadingOperationHandle;
    private SceneSO currentLoadedScene;
    private SceneSO loadScene;
    private bool isLoading = false;
    private float waitTime = 2f;
    private bool sceneHasLoadFinish = false;
    private bool isIntroFinish = false;

    private void OnEnable()
    {
        _initializeStartSceneHasLoadedListener.OnEventRaised += setSceneHasLoadFinish;
        _loadSceneEventListener.OnEventRaised += LoadScene;
        _introHasFinishListener.OnEventRaised += introHasFinish;
#if UNITY_EDITOR
        _loadSceneEditEventListener.OnEventRaised += LoadSceneEdit;
#endif

    }

    private void OnDisable()
    {
        _initializeStartSceneHasLoadedListener.OnEventRaised -= setSceneHasLoadFinish;
        _loadSceneEventListener.OnEventRaised -= LoadScene;
        _introHasFinishListener.OnEventRaised -= introHasFinish;
#if UNITY_EDITOR
        _loadSceneEditEventListener.OnEventRaised -= LoadSceneEdit;
#endif
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

#if UNITY_EDITOR
    private void LoadSceneEdit(SceneSO sceneRef)
    {
        currentLoadedScene = sceneRef;
        _sceneHasLoadedEventEmitter.RaiseEvent();
        _switchInputEventEmitter.RaiseEvent(currentLoadedScene.SceneType);
    }
#endif

    private void LoadScene(SceneSO sceneRef)
    {
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
        GameManager.Instance.SetCurrentSceneType(currentLoadedScene.SceneType);
        Scene s = obj.Result.Scene;
        SceneManager.SetActiveScene(s);
        LightProbes.TetrahedralizeAsync();
        if (currentLoadedScene.SceneType != SceneType.Menu && currentLoadedScene.SceneType != SceneType.Manage)
        {
            GameManager.SaveData();
        }

        StartCoroutine(DelayLoadScene());

    }

    private IEnumerator DelayLoadScene()
    {
        _startInitlizeSceneEventEmitter.RaiseEvent();
        yield return new WaitUntil(() => isIntroFinish);
        yield return new WaitUntil(() => sceneHasLoadFinish);
        yield return new WaitForSecondsRealtime(waitTime);
        LoadSceneFInish();

    }

    private void LoadSceneFInish()
    {
        isLoading = false;
        setSceneHasLoadFinish();
        //_sceneHasLoadedEventEmitter.RaiseEvent();
        _switchInputEventEmitter.RaiseEvent(currentLoadedScene.SceneType);
        _sceneReadyEventEmitter.RaiseEvent();

        // Unsubscribe from the event to avoid potential memory leaks
        loadingOperationHandle.Completed -= OnNewSceneLoaded;
        _loadingScreenEventEmitter.RaiseEvent(false);
    }

    private void setSceneHasLoadFinish() => sceneHasLoadFinish = !sceneHasLoadFinish;

    private void introHasFinish()
    {
        isIntroFinish = true;
    }
}
